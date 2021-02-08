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
    }
}
