namespace Minesweeper.Menu
{
    using System;

    public class CustomizeConsole
    {
        public const int Width = 89;
        public const int Height = 50;

        public static void Customize()
        {
            Console.BufferWidth = Console.WindowWidth = Width;
            Console.BufferHeight = Console.WindowHeight = Height;
            Console.CursorVisible = false;
            Console.Title = "Minesweeper";
        }
    }
}
