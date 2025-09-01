var builder = DistributedApplication.CreateBuilder(args);

var kafka = builder
    .AddKafka("kafka")
    .WithKafkaUI();

var consumer = builder.AddProject<Projects.AzagraTransport_Consumer>("consumer")
    .WithReference(kafka).WaitFor(kafka);

var producer = builder.AddProject<Projects.AzagraTransport_Producer>("producer")
    .WithReference(kafka).WaitFor(kafka);

builder.Build().Run();
