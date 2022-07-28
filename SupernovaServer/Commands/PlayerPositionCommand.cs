using System;
using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;

namespace SupernovaServer
{
    class PlayerPositionCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, NetServer server, NetIncomingMessage inc, Player player, List<Player> players)
        {
            managerLogger.AddLogMessage("Server", "Sending out new player position");

            var outmsg = server.CreateMessage();
            outmsg.Write((byte)PacketType.PlayerPosition);
            outmsg.WriteAllProperties(player);

            server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
