using System.Collections.Generic;
using Lidgren.Network;
using SupernovaLibrary;

namespace SupernovaServer
{
    class Server
    {
        private readonly ManagerLogger managerLogger;
        private List<Player> players;
        private NetPeerConfiguration config;
        private NetServer server;

        public Server(ManagerLogger ml)
        {
            managerLogger = ml;
            players = new List<Player>();
            config = new NetPeerConfiguration("networkGame")
            {
                Port = 1500 
            };

            config.EnableMessageType(NetIncomingMessageType.ConnectionApproval);
            server = new NetServer(config);
        }

        public void Run()
        {
            server.Start();
            managerLogger.AddLogMessage("Server", "Server started...");

            while (true)
            {
                NetIncomingMessage inc;
                if ((inc = server.ReadMessage()) == null)
                    continue;

                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.ConnectionApproval:
                        var login = new LoginCommand();
                        login.Run(managerLogger, server, inc, null, players);
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
            command.Run(managerLogger, server, inc, null, players);
        }
    }
}
