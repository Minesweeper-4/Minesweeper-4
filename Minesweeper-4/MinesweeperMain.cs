namespace Minesweeper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Minesweeper.Engine;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;

    public class MinesweeperMain
    {
        static int width = 69;
        static int height = 50;
        private const ConsoleColor TITLE_COLOR = ConsoleColor.White;
        private static string[] title =
        {
            "   _                                    ",
            "  | |     ____   _____   ____  ",
            "  | |__  | _  | |   __  |  _ | ",
            "  |____| |____| |_____| |____| ",
            "                                       ",
        };
        static int inputChoice = 0;
        static int secondChoice = 0;
        private static string[] menuItems = { "New Game".ToUpper(), "View High Scores".ToUpper(), "Choose Game Mode".ToUpper(), "Exit".ToUpper() };
        private static string[] secMenuItems = { "RETURN", "EXIT" };

        static void Main()
        {
            CustomizeConsole();
            //Front page
            PrintName();
            Thread.Sleep(1000);
            MainMenu();
            if (inputChoice == 3 || secondChoice == 1)
            {
                return;
            }

            // Demonstrating thread-safe implementation
            //Parallel.For(0, 23, x => MinesweeperEngine.Instance.PrintThreadNumber(x));
        }

        private static void CustomizeConsole()
        {
            Console.BufferWidth = Console.WindowWidth = width;
            Console.BufferHeight = Console.WindowHeight = height;
            Console.OutputEncoding = Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.CursorVisible = false;
            Console.Title = "Minesweeper";

        }
        private static void PrintName()
        {
            Console.ForegroundColor = TITLE_COLOR;

            if (title[0].Length <= Console.WindowWidth)
            {
                foreach (var str in title)
                {
                    Console.WriteLine(new string(' ', ((Console.WindowWidth - title[0].Length) / 2)) + str);
                }

            }
        }
        private static void MainMenu()
        {
            Console.WriteLine("\n\n");
            int indexForPrint = width / 2 - ("MAIN MENU:".Length / 2);
            Console.SetCursorPosition(indexForPrint, 9);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("MAIN MENU:");

            Console.ForegroundColor = ConsoleColor.Green;
            while (true)
            {
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(width / 2 - (menuItems[i].Length / 2), 10 + i + 1);
                    if (inputChoice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    Console.WriteLine(menuItems[i]);
                }
                if (Console.KeyAvailable)
                {
                    for (int i = 0; i < menuItems.Length - 1; i++)
                    {
                        Console.SetCursorPosition(width / 2 - (menuItems[i].Length / 2), 10 + i + 1);
                        if (inputChoice == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                        }
                        Console.WriteLine(menuItems[i]);
                    }
                    ConsoleKeyInfo choice = Console.ReadKey();
                    if (choice.Key == ConsoleKey.DownArrow)
                    {
                        inputChoice = (inputChoice + 1) % 4;

                    }
                    if (choice.Key == ConsoleKey.UpArrow)
                    {
                        inputChoice = (inputChoice - 1 + 4) % 4;

                    }
                    if (choice.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }
            #region Process Input
            //int inputChoice = int.Parse(Console.ReadLine());
            if (inputChoice == 0)
            {
                Console.ForegroundColor = ConsoleColor.White;
                var game = MinesweeperEngine.Instance;
                game.Start();
            }
            #region input = 1
            else if (inputChoice == 1)
            {
                try
                {
                    Console.Clear();
                    PrintName();
                    Console.SetCursorPosition((width / 2) - 10, 10);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("- HIGH SCORES -\n");

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    List<string> playerName = new List<string>();
                    using (StreamReader reader = new StreamReader(@"..\..\records.xml"))
                    {
                        string line = reader.ReadLine();
                        while (line != null)
                        {
                            playerName.Add(line); //Add name and score to the list
                            line = reader.ReadLine();
                        }
                    }
                    string[] playersArr = playerName.ToArray();
                    while (playerName.Count > 10)
                    {
                        playerName.RemoveAt(playerName.Count - 1);
                    }

                    //string newEntry = points + "\t" + nameOfPlayer;
                    //playerName.Add(newEntry);
                    int counter = 0;
                    for (int i = playersArr.Length - 1, j = 0; i >= playersArr.Length - 13; i--, j++)
                    {
                        Console.SetCursorPosition((width / 2) - 10, 12 + j);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        playerName = playersArr.ToList();
                        Console.WriteLine(playersArr[i]);
                    }
                    using (var writer = new StreamWriter(@"..\..\records.xml"))
                    {
                        for (int i = playersArr.Length - 1; i >= 0; i--)
                        {
                            writer.WriteLine(playerName[i]); //Writes name and score supposedly
                        }
                    }
                }
                catch (FileNotFoundException)
                {
                    Console.Error.WriteLine("\tCannot find 'records.xml'.");
                }

                secondChoiseOfMenus();
            }

            #endregion

            #region input 2
            else if (inputChoice == 2)
            {
                // print table with ponts / instructions
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                PrintName();
                Console.SetCursorPosition(20, 9);
                Console.WriteLine("Choosing options to implement....");


                secondChoiseOfMenus();
            }
            #endregion
            else if (inputChoice == 3)
            {
                return;
            }
            #endregion
        }

        private static void secondChoiseOfMenus()
        {
            while (true)
            {
                for (int i = 0; i < secMenuItems.Length; i++)
                {
                    if (secondChoice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.SetCursorPosition(25 + (10 * i), 27);
                    Console.WriteLine(secMenuItems[i]);
                    //Console.ResetColor();
                }
                if (Console.KeyAvailable)
                {
                    for (int i = 0; i < secMenuItems.Length; i++)
                    {
                        if (secondChoice == i)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        Console.SetCursorPosition(25 + (10 * i), 27);
                        Console.WriteLine(secMenuItems[i]);
                        //Console.ResetColor();
                    }

                    ConsoleKeyInfo pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        secondChoice = (secondChoice - 1 + 2) % 2;
                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        secondChoice = (secondChoice + 1) % 2;
                    }
                    if (pressedKey.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            }

            if (secondChoice == 0)
            {
                Console.Clear();
                PrintName();
                MainMenu();
            }
            else if (secondChoice == 1)
            {
                return;
            }
            //TODO: return to main menu, or exit game
        }
    }
}
