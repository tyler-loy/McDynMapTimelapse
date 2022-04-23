using McDynMapTimelapse;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = context.Configuration;

        var twc = new TimelapseWorkerConfig();
        config.Bind("TimelapseWorkerConfig", twc);

        services.AddSingleton(twc);

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();