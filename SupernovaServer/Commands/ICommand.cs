using System.Collections.Generic;
using SupernovaLibrary;
using Lidgren.Network;
using SupernovaServer.Managers;

namespace SupernovaServer.Commands
{
    interface ICommand
    {
        void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playCon, List<PlayerAndConnection> players);
    }
}
