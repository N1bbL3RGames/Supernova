using System;
using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;

namespace SupernovaServer
{
    class LoginCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, NetServer server, NetIncomingMessage inc, Player player, List<Player> players)
        {
            managerLogger.AddLogMessage("Server", "New connection...");
            var data = inc.ReadByte();

            if (data == (byte)PacketType.Login)
            {
                managerLogger.AddLogMessage("Server", "...Connection accepted.");

                player = CreatePlayer(inc, players);
                inc.SenderConnection.Approve();

                var outmsg = server.CreateMessage();
                outmsg.Write((byte)PacketType.Login);
                outmsg.Write(true);
                outmsg.Write(players.Count);

                for (int a = 0; a < players.Count; a++)
                    outmsg.WriteAllProperties(players[a]);

                server.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);

                var command = new PlayerPositionCommand();
                command.Run(managerLogger, server, inc, player, players);
            }
            else
                inc.SenderConnection.Deny("Failed to send correct information.");
        }

        private Player CreatePlayer(NetIncomingMessage inc, List<Player> players)
        {
            var player = new Player
            {
                Name = inc.ReadString(),
                ID = players.Count,
                PositionX = 0,
                PositionY = 0
            };

            players.Add(player);
            return player;
        }
    }
}
