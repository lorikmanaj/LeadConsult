using IceSync.DomainModel;
using IceSync.Infrastructure.Repo;
using IceSync.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IceSync.Website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowsController : ControllerBase
    {
        readonly string baseURL = "https://api-test.universal-loader.com/";
        private IWorkflowRepository _workflowRepository;
        private ITokenService _tokenService;
        private HttpClient _httpClient;
        public WorkflowsController(
            IWorkflowRepository workflowRepository,
            ITokenService tokenService)
        {
            _workflowRepository = workflowRepository;
            _tokenService = tokenService;
            CreateHttpClient();
        }

        // GET: api/Workflows
        [HttpGet]
        public ActionResult<IEnumerable<Workflow>> GetWorkflows()
        {
            return Ok(_workflowRepository.FindAll());
        }

        // GET: api/Workflows/5
        [HttpGet("{id}")]
        public ActionResult<Workflow> GetWorkflow(int id)
        {
            return _workflowRepository.FindById(id);
        }

        // POST: api/Workflows/RunWorkflow/5
        [HttpPost("{id}")]
        public async Task<string> RunWorkflow([FromForm] int id)
        {
            var response = await _httpClient.PostAsync($"{baseURL}Workflows/{id}/run", null);
            return response.IsSuccessStatusCode ? "True" : "False";
        }

        // POST: api/Workflows
        [HttpPost]
        public ActionResult<Workflow> PostWorkflow(Workflow workflow)
        {
            return _workflowRepository.Insert(workflow) ?
                BadRequest() : CreatedAtAction("GetWorkflow", new { id = workflow.WorkflowId }, workflow);
        }

        // DELETE: api/Workflows/5
        [HttpDelete("{id}")]
        public IActionResult DeleteWorkflow(int id)
        {
            return _workflowRepository.Delete(id) ? NotFound() : NoContent();
        }

        private void CreateHttpClient()
        {
            var token = _tokenService.GetToken();

            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.Result);
        }
    }
}
