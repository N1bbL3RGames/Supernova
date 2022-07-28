using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lidgren.Network;
using SupernovaLibrary;
using Microsoft.Xna.Framework.Input;

namespace Supernova
{
    internal class ManagerNetwork
    {
        private NetClient client;
        public List<Player> Players { get; set; }
        public string Username { get; set; }
        public int UserID { get; set; }
        public bool Active { get; set; }

        public ManagerNetwork()
        {
            Players = new List<Player>();
        }

        public bool Start()
        {
            client = new NetClient(new NetPeerConfiguration("networkGame"));
            client.Start();

            Username = "Name";

            var outmsg = client.CreateMessage();
            outmsg.Write((byte)PacketType.Login);
            outmsg.Write(Username);

            client.Connect("127.0.0.1", 1500, outmsg);
            return EstablishInfo();
        }

        private bool EstablishInfo()
        {
            var time = DateTime.Now;
            NetIncomingMessage inc;

            while (true)
            {
                if (DateTime.Now.Subtract(time).Seconds > 5)
                    return false;

                if ((inc = client.ReadMessage()) == null)
                    continue;

                switch (inc.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        var data = inc.ReadByte();

                        if (data == (byte)PacketType.Login)
                        {
                            Active = inc.ReadBoolean();

                            if (Active)
                                ReceiveAllPlayers(inc);

                            return Active;
                        }

                        return false;
                }
            }
        }

        public void Update()
        {
            NetIncomingMessage inc;
            while((inc = client.ReadMessage()) != null)
            {
                if (inc.MessageType != NetIncomingMessageType.Data)
                    continue;

                var packetType = (PacketType)inc.ReadByte();
                switch(packetType)
                {
                    case PacketType.PlayerPosition:
                        ReadPlayer(inc);
                        break;
                    case PacketType.AllPlayers:
                        ReceiveAllPlayers(inc);
                        break;
                    case PacketType.Login:
                        Active = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void ReceiveAllPlayers(NetIncomingMessage inc)
        {
            var count = inc.ReadInt32();
            UserID = count - 1;

            for (int a = 0; a < count; a++)
                ReadPlayer(inc);
        }

        private void ReadPlayer(NetIncomingMessage inc)
        {
            var player = new Player();
            inc.ReadAllProperties(player);

            if (Players.Any(p => p.ID == player.ID))
            {
                var oldPlayer = Players.FirstOrDefault(p => p.ID == player.ID);
                oldPlayer.PositionX = player.PositionX;
                oldPlayer.PositionY = player.PositionY;
            }
            else
                Players.Add(player);
        }

        public void SendInput(Keys key)
        {
            var outmsg = client.CreateMessage();
            outmsg.Write((byte)PacketType.Input);
            outmsg.Write((byte)key);
            outmsg.Write(UserID);

            client.SendMessage(outmsg, NetDeliveryMethod.ReliableOrdered);
        }
    }
}
