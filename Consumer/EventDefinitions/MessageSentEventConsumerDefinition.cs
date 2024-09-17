using Consumer.Consumers;
using MassTransit;

namespace Consumer.EventDefinitions;

public class MessageSentEventConsumerDefinition :
    ConsumerDefinition<MessageSentEventConsumer>
{
    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<MessageSentEventConsumer> consumerConfigurator, IRegistrationContext context)
    {
        endpointConfigurator.DiscardFaultedMessages();
        base.ConfigureConsumer(endpointConfigurator, consumerConfigurator, context);
    }
}