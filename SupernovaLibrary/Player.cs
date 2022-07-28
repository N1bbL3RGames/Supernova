using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework.Input;

namespace SupernovaLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }

        public Player(string name, int id, int posX, int posY)
        {
            Name = name;
            ID = id;
            PositionX = posX;
            PositionY = posY;
        }

        public Player() { }
    }
}
