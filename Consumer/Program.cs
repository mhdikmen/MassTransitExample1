using Common.Extentions;
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
                services.AddCustomMassTransit(Assembly.GetExecutingAssembly());
            })
            .Build();

        await host.RunAsync();
    }
}