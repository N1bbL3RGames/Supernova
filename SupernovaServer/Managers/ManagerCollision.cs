using System.Collections.Generic;
using SupernovaLibrary;
using Microsoft.Xna.Framework;

namespace SupernovaServer.Managers
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
