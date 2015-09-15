namespace Minesweeper.Engine
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Logic;
    using Minesweeper.Logic.Draw;

    public class MinesweeperEngine
    {
        private readonly MatrixLogic matrixLogic = new MatrixLogic();
        private readonly Printer printer = new StandardPrinter();
        private readonly MatrixDirector director = new MatrixDirector();
        private readonly SmallMatrixBuilder builder = new SmallMatrixBuilder();
        private Matrix matrix; // = new Matrix();

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
                    director.Construct(builder);
                    matrix = builder.GetMatrix();
                    printer.Print(matrix);
                    break;
                case "restart":
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

                    matrixLogic.MakeAMove(matrix.Field, rowIndex, colIndex);
                    printer.Print(matrix);

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
