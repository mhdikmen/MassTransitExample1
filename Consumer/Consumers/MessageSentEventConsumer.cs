using Common.Events;
using MassTransit;

namespace Consumer.Consumers;

public class MessageSentEventConsumer : IConsumer<MessageSentEvent>
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

public class MessageSentEventConsumerDefinition :
	ConsumerDefinition<MessageSentEventConsumer>
{
	protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<MessageSentEventConsumer> consumerConfigurator, IRegistrationContext context)
	{
        endpointConfigurator.DiscardFaultedMessages();
		base.ConfigureConsumer(endpointConfigurator, consumerConfigurator, context);
	}
}