using IceSync.DomainModel;
using IceSync.Infrastructure.Repo;
using IceSync.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IceSync.Console
{
    public class Worker : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly ILogger<Worker> _logger;
        private IWorkflowRepository _workflowRepository;
        private ITokenService _tokenService;
        public Worker(
            ILogger<Worker> logger,
            IServiceScopeFactory serviceScopeFactory
            )
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            CreateRepository();
            CreateTokenService();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Inserting items that are not in db.");
                GetItemsThatAreNotInDb();

                _logger.LogInformation("Deleting items that are in db but not in api.");
                GetItemsThatAreOnlyInDb();

                _logger.LogInformation("Updating common items.");
                UpdateCommonItems();

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                _logger.LogInformation("Next run at:{time}", DateTimeOffset.Now.AddMinutes(30));

                await Task.Delay(30 * 60 * 1000, stoppingToken);
            }
        }

        private void GetItemsThatAreNotInDb()
        {
            var itemsToInsert = GetWorkflows(PickType.OnlyApi);

            _workflowRepository.Insert(itemsToInsert);
        }

        private async void GetItemsThatAreOnlyInDb()
        {
            var items = GetWorkflows(PickType.OnlyDb);

            _workflowRepository.Delete(items.Select(x => x.WorkflowId));
        }

        private void UpdateCommonItems()
        {
            var itemsToUpdate = GetWorkflows(PickType.Both);

            _workflowRepository.Update(itemsToUpdate);
        }

        private IEnumerable<Workflow> GetItemsFromApi()
        {
            var token = _tokenService.GetToken().Result;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
               new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = httpClient
                .GetAsync("https://api-test.universal-loader.com/Workflows");

            var content = response.Result.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<List<Workflow>>(content.Result);
        }

        private void CreateRepository()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            _workflowRepository = scope.ServiceProvider.GetRequiredService<IWorkflowRepository>();
        }

        private void CreateTokenService()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            _tokenService = scope.ServiceProvider.GetRequiredService<ITokenService>();
        }

        private IEnumerable<Workflow> GetWorkflows(PickType pickType)
        {
            var apiItems = GetItemsFromApi();
            var ids = apiItems.Select(x => x.WorkflowId).Distinct().ToList();

            var dbItems = _workflowRepository.FindAll();
            var dbIds = dbItems.Select(x => x.WorkflowId).Distinct().ToList();

            switch (pickType)
            {
                case PickType.OnlyApi:
                    var onlyApi = ids.Except(dbIds);
                    return apiItems.Where(x => onlyApi.Contains(x.WorkflowId));

                case PickType.OnlyDb:
                    var onlyDb = dbIds.Except(ids);
                    return dbItems.Where(x => onlyDb.Contains(x.WorkflowId));

                case PickType.Both:
                    var common = ids.Where(x => dbIds.Contains(x));
                    return apiItems.Where(x => common.Contains(x.WorkflowId));

                default:
                    return null;
            }
        }

        enum PickType
        {
            OnlyApi,
            OnlyDb,
            Both
        }
    }
}
