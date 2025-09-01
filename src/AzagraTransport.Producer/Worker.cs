using Confluent.Kafka;

namespace AzagraTransport.Producer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IProducer<string, string> _producer;

        public Worker(
            ILogger<Worker> logger,
            IProducer<string, string> producer)
        {
            _logger = logger;
            _producer = producer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _producer.Produce("events", new Message<string, string> { Value = "hell"} );
                Console.WriteLine("kafka, Message sent");

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
