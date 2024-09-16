using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Consumer;

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
                
                services.AddMassTransit(config =>
                {
                    config.SetKebabCaseEndpointNameFormatter();
                    // Configuration for RabbitMQ
                    config.AddConsumers(Assembly.GetExecutingAssembly());

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

        await host.RunAsync();
    }
}