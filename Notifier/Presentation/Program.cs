
using rabbitmq_backgroundservice;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<IPublisher, RabbitMQPublisher>();
    })
    .Build();

await host.RunAsync();