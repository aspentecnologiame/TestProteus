using MarcosCosta.CrossCutting;
using MarcosCosta.Domain.Interfaces.Services;
using MarcosCosta.WorkerService.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MarcosCosta.WorkerService
{
    public class Worker : BackgroundService
    {
        private static IConfiguration Configuration { get; set; }
        public static ServiceProvider ServiceProvider { get; set; }

        private readonly ILogger<Worker> _logger;
        private readonly ImportFeedRDFJob _importFeedRDFJob;
        public Worker(ILogger<Worker> logger, IConfiguration configuration, ImportFeedRDFJob importFeedRDFJob)
        {
            _logger = logger;
            Configuration = configuration;
            _importFeedRDFJob = importFeedRDFJob;
        }

        public static void ConfigureService(IServiceCollection serviceCollection)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location))
                .AddJsonFile("appsettings.json")
                .Build();

            serviceCollection.AddLogging(loggingBuilder => loggingBuilder.SetMinimumLevel(LogLevel.Information));

            serviceCollection.AddSingleton<ImportFeedRDFJob>();
            serviceCollection.AddServices(Configuration);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Deseja realmente iniciar o processo de importação do Feed RDF? (S):(N)");
            var ck = Console.ReadKey();

            if (ck.Key == ConsoleKey.S) await _importFeedRDFJob.ImportFeeds();

            Console.WriteLine("Deseja realmente obter Microsoft SQL Server Build Versions List? (S):(N)");
            var cks = Console.ReadKey();

            //TODO: Implementar serviço de coleta do SQL Build
            if (ck.Key == ConsoleKey.S) Console.WriteLine("Implementar serviço de coleta de build!");

            await Task.Delay(1000, stoppingToken);
            Environment.Exit(0);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Parando o Serviço do Face ++");
            await base.StopAsync(cancellationToken);
        }
    }
}
