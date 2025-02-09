using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using System.Text;

namespace Project.Infrastructure.EventBus;
public class RabbitmqEventBus:EventBus
{
    private readonly IModel _channel;

    public RabbitmqEventBus(ILogger<RabbitmqEventBus> logger):base(logger)
    {
        var factory = new ConnectionFactory { HostName = "localhost" };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();
    }

    protected override Task PublishInternalAsync(string eventName, string payload)
    {
        _channel.QueueDeclare(queue: eventName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        var body = Encoding.UTF8.GetBytes(payload);
        _channel.BasicPublish(exchange: "", routingKey: eventName, basicProperties: null, body: body);

        return Task.CompletedTask;
    }
}
