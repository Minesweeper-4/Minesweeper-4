namespace Minesweeper.Menu
{
    using Engine;
    using System;

    public class SecondMenu
    {
        private static int secondChoice = 0;

        internal static void SecondChoiseOfMenus(MinesweeperEngine game)
        {
            string[] secMenuItems = new string[Enum.GetNames(typeof(SecondMenuOptions)).Length];
            var indexer = 0;
            foreach (SecondMenuOptions option in Enum.GetValues(typeof(SecondMenuOptions)))
            {
                secMenuItems[indexer] = option.ToString();
                indexer++;
            }

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
                PrintLogo.Print();
                MainMenu.PrintMenu(game);
            }
            else if (secondChoice == 1)
            {
                return;
            }
        }
    }
}
