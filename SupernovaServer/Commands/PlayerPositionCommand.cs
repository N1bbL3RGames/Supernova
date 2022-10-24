using System;
using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;
using SupernovaServer.Managers;

namespace SupernovaServer.Commands
{
    class PlayerPositionCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playCon, List<PlayerAndConnection> players)
        {
            if (playCon != null)
            {
                managerLogger.AddLogMessage("Server", "Sending out new player position");

                var outmsg = server.netServer.CreateMessage();
                outmsg.Write((byte)PacketType.PlayerPosition);
                outmsg.WriteAllProperties(playCon.Player);

                server.netServer.SendToAll(outmsg, NetDeliveryMethod.ReliableOrdered);
            }
        }
    }
}
