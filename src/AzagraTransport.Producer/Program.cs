using AzagraTransport.Producer;

var builder = Host.CreateApplicationBuilder(args);

builder.AddKafkaProducer<string, string>("kafka");

builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
