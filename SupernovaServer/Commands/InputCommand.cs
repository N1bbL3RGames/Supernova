using System;
using System.Collections.Generic;
using System.Linq;
using SupernovaLibrary;
using Lidgren.Network;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SupernovaServer
{
    class InputCommand : ICommand
    {
        public void Run(ManagerLogger managerLogger, NetServer server, NetIncomingMessage inc, Player player, List<Player> players)
        {
            managerLogger.AddLogMessage("Server", "Received new input");

            var key = (Keys)inc.ReadByte();
            var id = inc.ReadInt32();
            player = players.FirstOrDefault(p => p.ID == id);

            if (player == null)
            {
                managerLogger.AddLogMessage("Server", String.Format("Could not find player with connection ID: {0}", id));
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
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if(!ManagerCollision.CheckCollision(new Rectangle(player.PositionX + x, player.PositionY + y, 50, 50), player.ID, players))
            {
                player.PositionX += x;
                player.PositionY += y;
            }

            var command = new PlayerPositionCommand();
            command.Run(managerLogger, server, inc, player, players);
        }
    }
}
