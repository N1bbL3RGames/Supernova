using System;
using System.Collections.Generic;
using System.Linq;
using SupernovaLibrary;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SupernovaServer.Managers;

namespace SupernovaServer.Commands
{
    class InputCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, Server server, NetIncomingMessage inc, PlayerAndConnection playCon, List<PlayerAndConnection> players)
        {
            managerLogger.AddLogMessage("Server", "Received new input");

            var key = (Keys)inc.ReadByte();
            var id = inc.ReadInt32();
            playCon = players.FirstOrDefault(p => p.Player.ID == id);

            if (playCon == null)
            {
                managerLogger.AddLogMessage("Server", string.Format("Could not find player with connection ID: {0}", id));
                return;
            }

            int x = 0;
            int y = 0;

            switch (key)
            {
                case Keys.Down:
                    y++;
                    break;
                case Keys.Up:
                    y--;
                    break;
                case Keys.Left:
                    x--;
                    break;
                case Keys.Right:
                    x++;
                    break;
            }

            var player = playCon.Player;
            if (!ManagerCollision.CheckCollision(new Rectangle(player.PositionX + x, player.PositionY + y, 50, 50), player.ID, players.Select(p => p.Player).ToList()))
            {
                player.PositionX += x;
                player.PositionY += y;
            }

            var command = new PlayerPositionCommand();
            command.Run(managerLogger, server, inc, playCon, players);
        }
    }
}
