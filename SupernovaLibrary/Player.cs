using System.Xml;

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
