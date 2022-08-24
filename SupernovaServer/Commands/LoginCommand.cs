using System;
using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;
using SupernovaServer.Managers;

namespace SupernovaServer.Commands
{
    class LoginCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playCon, List<PlayerAndConnection> players)
        {
            managerLogger.AddLogMessage("Server", "New connection...");
            var data = inc.ReadByte();

            if (data == (byte)PacketType.Login)
            {
                managerLogger.AddLogMessage("Server", "...Connection accepted.");

                playCon = CreatePlayer(inc, players);
                inc.SenderConnection.Approve();

                var outmsg = server.netServer.CreateMessage();
                outmsg.Write((byte)PacketType.Login);
                outmsg.Write(true);
                outmsg.Write(players.Count);

                for (int a = 0; a < players.Count; a++)
                    outmsg.WriteAllProperties(players[a].Player);

                server.netServer.SendMessage(outmsg, inc.SenderConnection, NetDeliveryMethod.ReliableOrdered, 0);

                var command = new PlayerPositionCommand();
                command.Run(managerLogger, server, inc, playCon, players);

                server.SendNewPlayerEvent(playCon.Player.Name, playCon.Player.ID);
            }
            else
                inc.SenderConnection.Deny("Failed to send correct information.");
        }

        private PlayerAndConnection CreatePlayer(NetIncomingMessage inc, List<PlayerAndConnection> players)
        {
            var playCon = new PlayerAndConnection
            {
                Player = new Player
                {
                    Name = inc.ReadString(),
                    ID = players.Count,
                    PositionX = 0,
                    PositionY = 0
                },
                Connection = inc.SenderConnection
            };

            players.Add(playCon);
            return playCon;
        }
    }
}
