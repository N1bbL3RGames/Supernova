﻿namespace Supernova
{
    public class Program
    {
        [STAThread]

        static void Main(string[] args)
        {
            using(var game = new Game1())
            {
                game.Run();
            }
        }
    }
}