namespace Minesweeper.Menu
{
    using System;

    /// <summary>
    /// Set the dimensions of the console
    /// </summary>
    public class CustomizeConsole
    {
        public const int Width = 89;
        public const int Height = 50;

        /// <summary>
        /// Customize console Width and Height properties
        /// </summary>
        public static void Customize()
        {
            Console.BufferWidth = Console.WindowWidth = Width;
            Console.BufferHeight = Console.WindowHeight = Height;
            Console.CursorVisible = false;
            Console.Title = "Minesweeper";
        }
    }
}
