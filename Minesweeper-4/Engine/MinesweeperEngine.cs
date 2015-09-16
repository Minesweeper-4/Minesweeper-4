namespace Minesweeper.Engine
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Logic;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Interfaces;
    using Minesweeper.Data.Player;

    public class MinesweeperEngine
    {
        private readonly Printer printer = new StandardPrinter();
        private readonly MatrixDirector director = new MatrixDirector();
        private readonly SmallMatrixBuilder builder = new SmallMatrixBuilder();
        private IPlayer player;

        private Matrix matrix;

        public MinesweeperEngine()
        {

        }

        public void Start()
        {
            var playerCreator = new PlayerCreator();
            player = playerCreator.CreateNewPlayer();

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
                    printer.PrintLine("Top");
                    break;
                case "start":
                    HandleSrartCommand(command);
                    break;
                case "restart":
                    HandleRestartCommand(command);
                    break;
                case "exit":
                    printer.PrintLine("Good bye");
                    break;
                case "turn":
                    HandleTurnCommand(command);
                    break;
                case "mode":
                    if (command.Parameters.Count != 1)
                    {
                        printer.PrintLine("Invalid mode!");
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
                        printer.PrintLine("Invalid mode!");
                    }

                    break;
                default:
                    printer.PrintLine("\nIllegal move!\n");
                    break;

            }
        }

        private void HandleSrartCommand(Command command)
        {
            director.Construct(builder);
            matrix = builder.GetMatrix();
            printer.PrintMatrix(matrix, player);
        }

        private void HandleRestartCommand(Command command)
        {
            throw new NotImplementedException();
        }

        private void HandleTurnCommand(Command command)
        {
            if (!ValidateInput(command))
            {
                return;
            }
            int rowIndex = int.Parse(command.Parameters[0]);
            int colIndex = int.Parse(command.Parameters[1]);

            var currentCell = matrix.Field[rowIndex, colIndex];
            currentCell.IsOpen = true;


            if (currentCell.IsBoomb)
            {                
                HandleGameOver();
            }
            else
            {
                this.player.Score++;
            }

            printer.PrintMatrix(matrix, player);
        }

        private void HandleGameOver()
        {
            printer.PrintMatrix(matrix, player);
            Console.WriteLine("Game Over!");
            throw new NotImplementedException();
        }

        private bool ValidateInput(Command command)
        {
            if (command.Parameters.Count != 2)
            {
                printer.PrintLine("Invalid number of arguments!");
                return false;
            }

            int rowIndex;
            int colIndex;

            try
            {
                rowIndex = int.Parse(command.Parameters[0]);
                colIndex = int.Parse(command.Parameters[1]);
            }
            catch (Exception)
            {
                printer.PrintLine("Invalid row and column!");
                return false;
            }

            int maxRow = matrix.Rows;
            int maxCol = matrix.Cols;

            bool isRowInRange = (0 <= rowIndex) && (rowIndex < maxRow);
            bool isColInRange = (0 <= colIndex) && (colIndex < maxCol);

            if (!(isRowInRange && isColInRange))
            {
                printer.PrintLine("Row or column are outside of the range of the matrix");
                return false;
            }
            

            return true;
        }
    }
}
