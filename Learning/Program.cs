using System;
using HelloWorld.Game;

namespace HelloWorld
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameBoard game = new GameBoard();

            // game.DrawBoard();
            game.RunGameLoop();
        }
    }
}
