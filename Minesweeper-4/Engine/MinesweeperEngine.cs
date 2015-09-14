namespace Minesweeper.Engine
{
    using System;

    public class MinesweeperEngine
    {
        public MinesweeperEngine()
        {

        }

        public void Start()
        {
            // TODO Builder

            do
            {
                var command = new Command(Console.ReadLine());
                ReadCommand(command);
            } while (true);
        }

        private void ReadCommand(Command command)
        {
            switch (command.Name)
            {
                case "top":
                    Console.WriteLine("Top");
                    break;
                case "start":
                case "restart":
                    //playground = CreateWhiteBoard();
                    //boomBoard = CreateBombBoard();
                    //PrintBoard(playground);
                    //boomed = false;
                    //welcomeFlag = false;
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    break;
                case "turn":
                    if (command.Parameters.Count != 2)
                    {
                        Console.WriteLine("Invalid number of arguments!");
                        break;
                    }
                    int rowIndex;
                    int colIndex;
                    bool rowIsProvided = int.TryParse(command.Parameters[0], out rowIndex);
                    bool columnIsProvided = int.TryParse(command.Parameters[1], out colIndex);

                    if (!(rowIsProvided && columnIsProvided))
                    {
                        Console.WriteLine("Invalid row and column!");
                        break;
                    }

                    Console.WriteLine(rowIndex + " " + colIndex);

                    //if (boomBoard[rowIndex, columnIndex] != '*')
                    //{
                    //    if (boomBoard[rowIndex, columnIndex] == '-')
                    //    {
                    //        MakeAMove(playground, boomBoard, rowIndex, columnIndex);
                    //        counter++;
                    //    }
                    //    if (MAX_REVEALED_CELLS == counter)
                    //    {
                    //        flag = true;
                    //    }
                    //    else
                    //    {
                    //        PrintBoard(playground);
                    //    }
                    //}
                    //else
                    //{
                    //    boomed = true;


                    //}
                    break;
                default:
                    Console.WriteLine("\nIllegal move!\n");
                    break;

            }
        }
    }
}
