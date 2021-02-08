using LiteNetwork.Server;

namespace Moonstone.Server
{
    internal class MoonstoneServer : LiteServer<MoonstoneUser>
    {
        public MoonstoneServer(LiteServerConfiguration configuration) 
            : base(configuration)
        {
        }

        protected override void OnAfterStart()
        {
        }
    }
}
