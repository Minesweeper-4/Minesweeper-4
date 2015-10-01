namespace Minesweeper.Menu
{
    using System;

    internal class PrintLogo
    {
        private static string[] title =
       {
            "   _   _   _   _   __   ____   ____  __      __  ____   ____   ____   ____   _____ ",
            "  | \\_/ | | | | | // | | ___| | ___| \\ \\    / / | ___| | ___| | __ | | ___| | ___ |",
            "  |  _  | | | | |//| | | ___| |___ |  \\ \\/\\/ /  | ___| | ___| |  __| | ___| |  ___|",
            "  |_| |_| |_| |_ / |_| |____| |____|   \\_/\\_/   |____| |____| |_|    |____| |_|\\_\\   ",
            "                                       ",
        };

        internal static void Print()
        {
            if (title[0].Length <= Console.WindowWidth)
            {
                foreach (var str in title)
                {
                    Console.WriteLine(new string(' ', (Console.WindowWidth - title[0].Length) / 2) + str);
                }
            }
        }
    }
}
