using LiteNetwork.Protocol;
using Moonstone.Protocol.Abstractions;

namespace Moonstone.Protocol
{
    public class FFPacket : LitePacketStream, IFFPacket
    {
        public FFPacket()
            : base()
        {
        }

        public FFPacket(byte[] buffer)
            : base(buffer)
        {
        }
    }
}
