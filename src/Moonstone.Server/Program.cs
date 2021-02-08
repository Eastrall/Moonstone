using LiteNetwork.Common;
using LiteNetwork.Server.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Moonstone.Common.Configuration;
using Moonstone.Protocol;
using System;
using System.Threading.Tasks;

namespace Moonstone.Server
{
    public class Program
    {
        public static Task Main()
        {
            var host = new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.SetBasePath("/opt/moonstone/config"); // TODO: move this to a constant
                    builder.AddYamlFile("server.yml", optional: false, reloadOnChange: true);
                    builder.AddEnvironmentVariables();
                })
                .ConfigureLogging(builder =>
                {
                    builder.AddFilter("LiteNetwork", LogLevel.Warning);
                    builder.SetMinimumLevel(LogLevel.Trace);
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddOptions();
                    services.Configure<ServerConfiguration>(context.Configuration.GetSection("server"));
                    services.Configure<GameConfiguration>(context.Configuration.GetSection("game"));
                })
                .UseLiteServer<MoonstoneServer, MoonstoneUser>((hostContext, options) =>
                {
                    var serverConfiguration = hostContext.Configuration.GetSection("server").Get<ServerConfiguration>();

                    if (serverConfiguration is null)
                    {
                        throw new InvalidProgramException($"Failed to load server settings.");
                    }

                    options.Host = serverConfiguration.Ip;
                    options.Port = serverConfiguration.Port;
                    options.PacketProcessor = new FFPacketProcessor();
                    options.ReceiveStrategy = ReceiveStrategyType.Queued;
                })
                .UseConsoleLifetime()
                .Build();

            return host.RunAsync();
        }
    }
}
