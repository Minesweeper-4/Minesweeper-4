namespace Minesweeper.Menu
{
    using System;
    using Minesweeper.Engine;

    public class Navigation
    {
        private static int inputChoice = 0;

        public static void MainMenuNavigation(string[] mainMenuItems, MinesweeperEngine game)
        {
            while (true)
            {
                for (int i = 0; i < mainMenuItems.Length; i++)
                {
                    Console.SetCursorPosition((CustomizeConsole.Width / 2) - (mainMenuItems[i].Length / 2), 10 + i + 1);
                    if (inputChoice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }

                    Console.WriteLine(mainMenuItems[i]);
                }

                if (Console.KeyAvailable)
                {
                    for (int i = 0; i < mainMenuItems.Length; i++)
                    {
                        Console.SetCursorPosition((CustomizeConsole.Width / 2) - (mainMenuItems[i].Length / 2), 10 + i + 1);
                        if (inputChoice == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }

                        Console.WriteLine(mainMenuItems[i]);
                    }

                    ConsoleKeyInfo choice = Console.ReadKey();
                    if (choice.Key == ConsoleKey.DownArrow)
                    {
                        inputChoice = (inputChoice + 1) % mainMenuItems.Length;
                    }

                    if (choice.Key == ConsoleKey.UpArrow)
                    {
                        inputChoice = (inputChoice - 1 + mainMenuItems.Length) % mainMenuItems.Length;
                    }

                    if (choice.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }

            ///process input
            if (inputChoice == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                game.ExecuteCommand("start");
            }
            else if (inputChoice == 1)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("- HIGH SCORES -\n");

                SecondMenu.SecondChoiseOfMenus(game);
            }
            else if (inputChoice == 2)
            {
                Console.Clear();
                PrintLogo.Print();
                Console.SetCursorPosition((CustomizeConsole.Width / 2) - 10, 10);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("- CHOOSE MODE TO PLAY -\n\n");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\t\t\t\tLIGHT\n");
                Console.WriteLine("\t\t\t\tDARK");

                SecondMenu.SecondChoiseOfMenus(game);
            }
            else if (inputChoice == 3)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                PrintLogo.Print();
                Console.SetCursorPosition(20, 9);
                Console.WriteLine(" - HOW TO PLAY - ");

                SecondMenu.SecondChoiseOfMenus(game);
            }
            else if (inputChoice == 4)
            {
                game.ExecuteCommand("exit");
                return;
            }
        }
    }
}
