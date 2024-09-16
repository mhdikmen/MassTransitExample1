using Common.Events;
using MassTransit;

namespace Consumer.Consumers;

public partial class MessageSentEventConsumer : IConsumer<MessageSentEvent>
{
    public async Task Consume(ConsumeContext<MessageSentEvent> context)
    {
        try
        {
            if (string.IsNullOrEmpty(context.Message.Content))
            {
                throw new ArgumentNullException(nameof(context.Message.Content), " content is required");
            }

            Console.WriteLine($"Processing message: {context.Message.Title}");
            await Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error occurred while processing message: {ex.Message}");
            throw;
        }
    }
}