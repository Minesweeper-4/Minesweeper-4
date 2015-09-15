namespace Minesweeper.Engine
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Logic;

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
                    var matrixLogic = new MatrixLogic();
                    var matrix = new Matrix(5, 10).Field;
                    matrixLogic.InitBoard(matrix);

                    int boardRows = matrix.GetLength(0);
                    int boardColumns = matrix.GetLength(1);
                    Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
                    Console.WriteLine("   ---------------------");

                    for (int i = 0; i < boardRows; i++)
                    {
                        Console.Write("{0} | ", i);
                        for (int j = 0; j < boardColumns; j++)
                        {
                            Console.Write(string.Format("{0} ", matrix[i, j].CurrentSymbol));
                        }
                        Console.Write("|");
                        Console.WriteLine();
                    }
                    Console.WriteLine("   ---------------------\n");

                    break;
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
                case "mode":
                    if (command.Parameters.Count != 1)
                    {
                        Console.WriteLine("Invalid mode!");
                    }

                    if (command.Parameters[0] == "standard")
                    {
                        // TODO
                    }
                    else if (command.Parameters[0] == "fancy")
                    {
                        // TODO
                    }
                    else
                    {
                        Console.WriteLine("Invalid mode!");
                    }

                    break;
                default:
                    Console.WriteLine("\nIllegal move!\n");
                    break;

            }
        }
    }
}
