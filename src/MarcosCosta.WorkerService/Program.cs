using MarcosCosta.WorkerService;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<Worker>();
        Worker.ConfigureService(services);
    })
    .ConfigureLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddDebug();
        loggingBuilder.AddConsole();
        loggingBuilder.AddEventLog();
        loggingBuilder.AddFilter<EventLogLoggerProvider>(level => level != LogLevel.None);
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();