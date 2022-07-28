using System;
using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;

namespace SupernovaServer
{
    class AllPlayersCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, NetServer server, NetIncomingMessage inc, Player player, List<Player> players)
        {
            managerLogger.AddLogMessage("Server", "Sending full player list");

            var outmsg = server.CreateMessage();
            outmsg.Write((byte)PacketType.AllPlayers);
            outmsg.Write(players.Count);

            foreach (var p in players)
                outmsg.WriteAllProperties(p);

            server.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
