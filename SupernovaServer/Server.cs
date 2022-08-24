using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using SupernovaLibrary;
using Lidgren.Network;
using SupernovaServer.Commands;
using SupernovaServer.Managers;
using SupernovaServer.EventArguments;
using Microsoft.Xna.Framework.Input;

namespace SupernovaServer
{
    class Server
    {
        public event EventHandler<NewPlayerEventArgs> newPlayer;
        private readonly ManagerLogger managerLogger;
        private List<PlayerAndConnection> players;
        private NetPeerConfiguration config;
        public NetServer netServer { get; private set; }

        public Server(ManagerLogger ml)
        {
            managerLogger = ml;
            players = new List<PlayerAndConnection>();
            config = new NetPeerConfiguration("networkGame")
            {
                Port = 1500 
            };

            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            netServer = new NetServer(config);
        }

        public void Run()
        {
            netServer.Start();
            managerLogger.AddLogMessage("Server", "Server started...");

            while (true)
            {
                NetIncomingMessage inc;
                if ((inc = netServer.ReadMessage()) == null)
                    continue;

                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.ConnectionApproval:
                        var login = new LoginCommand();
                        login.Run(managerLogger, this, inc, null, players);
                        break;
                    case NetIncomingMessageType.Data:
                        Data(inc);
                        break;
                }
            }
        }

        private void Data(NetIncomingMessage inc)
        {
            var packetType = (PacketType)inc.ReadByte();
            var command = PacketFactory.GetCommand(packetType);
            command.Run(managerLogger, this, inc, null, players);
        }

        public void SendNewPlayerEvent(string username, int userID)
        {
            if (newPlayer != null)
                newPlayer(this, new NewPlayerEventArgs(username, userID));
        }

        public void KickPlayer(int playerIndex)
        {
            var command = PacketFactory.GetCommand(PacketType.Kick);
            command.Run(managerLogger, this, null, players[playerIndex], players);
        }
    }
}
