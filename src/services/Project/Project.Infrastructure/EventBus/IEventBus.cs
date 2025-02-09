using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Project.Infrastructure.EventBus;
public interface IEventBus
{
    Task PublishAsync<T>(T @event) where T : class;
}

public abstract class EventBus : IEventBus
{
    private readonly ILogger<EventBus> _logger;

    protected EventBus(ILogger<EventBus> logger)
    {
        _logger = logger;
    }

    public async Task PublishAsync<T>(T @event) where T : class
    {
        var eventName = @event.GetType().Name;
        var payload = JsonSerializer.Serialize(@event);

        _logger.LogInformation($"Publishing event: {eventName}, Payload: {payload}");

        await PublishInternalAsync(eventName, payload);
    }

    protected abstract Task PublishInternalAsync(string eventName, string payload);
}