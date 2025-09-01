using AzagraTransport.Consumer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddKafkaConsumer<string, string>(
    "kafka",
    static settings =>
    {
        settings.Config.GroupId = Guid.NewGuid().ToString();
    });

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
