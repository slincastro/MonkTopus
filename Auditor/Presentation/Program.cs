using rabbitmq_backgroundservice;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var mongoDbSettings = hostContext.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
                services.AddSingleton(mongoDbSettings);
                
        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();