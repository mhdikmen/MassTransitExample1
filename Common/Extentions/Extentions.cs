using System.Reflection;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Extentions;

public static class Extentions
{
	public static void AddCustomMassTransit(this IServiceCollection serviceCollection, Assembly? assembly = null)
	{
		serviceCollection.AddMassTransit(config =>
		{
			config.SetKebabCaseEndpointNameFormatter();

			// Configuration for RabbitMQ
			if (assembly != null)
				config.AddConsumers(assembly);

			config.UsingRabbitMq((context, configurator) =>
			{
				configurator.Host("localhost", host =>
				{
					host.Username("guest");
					host.Password("guest");
				});

				configurator.ReceiveEndpoint(configure =>
				{
					configure.DiscardFaultedMessages();
				});

				configurator.ConfigureEndpoints(context);
			});
		});
	}
}
