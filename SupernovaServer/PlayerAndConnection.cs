using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupernovaLibrary;
using Lidgren.Network;

namespace SupernovaServer
{
    class PlayerAndConnection
    {
        public Player Player { get; set; }
        public NetConnection Connection { get; set; }

        public PlayerAndConnection(Player player, NetConnection connection)
        {
            Player = player;
            Connection = connection;
        }

        public PlayerAndConnection() { }
    }
}
