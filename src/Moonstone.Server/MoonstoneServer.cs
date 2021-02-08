using LiteNetwork.Protocol.Abstractions;
using LiteNetwork.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Moonstone.Server
{
    internal class MoonstoneServer : LiteServer<MoonstoneUser>
    {
        private readonly ILogger<MoonstoneServer>? _logger;

        public MoonstoneServer(LiteServerConfiguration configuration, ILitePacketProcessor packetProcessor, IServiceProvider? serviceProvider) 
            : base(configuration, packetProcessor, serviceProvider)
        {
            _logger = serviceProvider?.GetRequiredService<ILogger<MoonstoneServer>>();
        }

        protected override void OnAfterStart()
        {
            _logger?.LogInformation($"Moonstone server started and listening on port '{Configuration.Port}'");
        }
    }
}
