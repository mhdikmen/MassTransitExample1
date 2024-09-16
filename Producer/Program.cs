using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Producer.Services;

namespace Producer;

public class Program
{
    protected Program()
    {

    }
    public static async Task Main(string[] args)
    {
        var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddScoped<MessageService>();
                services.AddMassTransit(config =>
                {
                    config.SetKebabCaseEndpointNameFormatter();

                    config.UsingRabbitMq((context, configurator) =>
                    {
                        configurator.Host("localhost", host =>
                        {
                            host.Username("guest");
                            host.Password("guest");
                        });
                        configurator.ConfigureEndpoints(context);
                    });
                });
            })
            .Build();
        var messageService = host.Services.GetRequiredService<MessageService>();

        string title = "MassTransit";
        string message = "MassTransit is free software/open-source .NET-based Enterprise Service Bus software that helps .NET developers route messages over RabbitMQ, Azure Service Bus, SQS, and ActiveMQ service busses. It supports multicast, versioning, encryption, sagas, retries, transactions, distributed systems and other features.";

        await messageService.CreateMessageAsync(title, string.Empty);

        await host.RunAsync();
    }
}