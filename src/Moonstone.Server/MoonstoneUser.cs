using LiteNetwork.Protocol.Abstractions;
using LiteNetwork.Server;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Moonstone.Server
{
    internal class MoonstoneUser : LiteServerUser
    {
        private readonly ILogger<MoonstoneUser> _logger;

        public MoonstoneUser(ILogger<MoonstoneUser> logger)
        {
            _logger = logger;
        }

        public override Task HandleMessageAsync(ILitePacketStream incomingPacketStream)
        {
            return base.HandleMessageAsync(incomingPacketStream);
        }

        protected override void OnConnected()
        {
            _logger.LogInformation($"New client connected ({Id})");
        }

        protected override void OnDisconnected()
        {
            _logger.LogInformation($"Client {Id} disconnected");
        }
    }
}
