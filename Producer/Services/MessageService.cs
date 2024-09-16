using Common.Events;
using MassTransit;

namespace Producer.Services;

public class MessageService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MessageService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task CreateMessageAsync(string title, string content)
    {
        var messageSentEvent = new MessageSentEvent
        {
            Title = title,
            Content = content
        };


        await _publishEndpoint.Publish(messageSentEvent);

        Console.WriteLine($"Message with {title} was published.");
    }
}