using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupernovaLibrary;
using Lidgren.Network;

namespace SupernovaServer
{
    interface ICommand
    {
        void Run(ManagerLogger managerLogger, NetServer server, NetIncomingMessage inc, Player player, List<Player> players);
    }
}
