using Confluent.Kafka;

namespace AzagraTransport.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConsumer<string, string> _consumer;

        public Worker(
            ILogger<Worker> logger,
            IConsumer<string, string> consumer)
        {
            _logger = logger;
            _consumer = consumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("events");

            while (!stoppingToken.IsCancellationRequested)
            {
                var consumeResult = _consumer.Consume();
                Console.WriteLine($"kafka, message got: {consumeResult.Message.Value}");

                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
