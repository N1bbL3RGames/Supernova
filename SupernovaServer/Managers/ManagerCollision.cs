using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupernovaLibrary;
using Microsoft.Xna.Framework;

namespace SupernovaServer
{
    class ManagerCollision
    {
        public static bool CheckCollision(Rectangle rec, int userID, List<Player> players)
        {
            foreach(var player in players)
                if(player.ID != userID)
                {
                    var playerRec = new Rectangle(player.PositionX, player.PositionY, 50, 50);
                    if (playerRec.Intersects(rec))
                        return true;
                }

            return false;
        }
    }
}
