using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupernovaLibrary;
using SupernovaServer.Managers;
using Lidgren.Network;

namespace SupernovaServer.Commands
{
    class KickPlayerCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playCon, List<PlayerAndConnection> players)
        {
            managerLogger.AddLogMessage("Server", string.Format("Kicking {0}", playCon.Player.Name));

            var outmsg = server.netServer.CreateMessage();
            outmsg.Write((byte)PacketType.Kick);
            outmsg.Write(playCon.Player.ID);

            server.netServer.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
            playCon.Connection.Disconnect("Kicked by server host");
        }
    }
}
