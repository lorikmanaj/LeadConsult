using IceSync.Infrastructure;
using IceSync.Infrastructure.Repo;
using IceSync.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IceSync.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    object p = services.AddDbContext<WorkflowsDBContext>(options =>
                        options.UseSqlServer(
                            hostContext.Configuration.GetConnectionString("WorkFlowsDefault"),
                            x => x.MigrationsAssembly("IceSync.Infrastructure")),
                            ServiceLifetime.Singleton);

                    services.AddScoped<IWorkflowRepository, WorkflowRepository>();
                    services.AddSingleton<IMemoryCache, MemoryCache>();
                    services.AddSingleton<ITokenService, TokenService>();

                    services.AddHostedService<Worker>();
                });
    }
}
