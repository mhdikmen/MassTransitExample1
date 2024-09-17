using Common.Events;
using MassTransit;

namespace Consumer.Consumers;

public class MessageSentEventConsumerFaultConsumer : IConsumer<Fault<MessageSentEvent>>
{
    public Task Consume(ConsumeContext<Fault<MessageSentEvent>> context)
    {
        // Handle failed messages
        Console.WriteLine($"Message failed: {context.Message.Message.Title}");
        return Task.CompletedTask;
    }
}