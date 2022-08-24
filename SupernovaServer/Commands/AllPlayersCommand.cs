using System;
using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;
using SupernovaServer.Managers;

namespace SupernovaServer.Commands
{
    class AllPlayersCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playCon, List<PlayerAndConnection> players)
        {
            managerLogger.AddLogMessage("Server", "Sending full player list");

            var outmsg = server.netServer.CreateMessage();
            outmsg.Write((byte)PacketType.AllPlayers);
            outmsg.Write(players.Count);

            foreach (var p in players)
                outmsg.WriteAllProperties(p.Player);

            server.netServer.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
