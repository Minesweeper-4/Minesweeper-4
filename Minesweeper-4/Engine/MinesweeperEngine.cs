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
                    Console.WriteLine("Top");
                    break;
                case "start":
                    HandleSrartCommand(command);
                    break;
                case "restart":
                    HandleRestartCommand(command);
                    break;
                case "exit":
                    Console.WriteLine("Good bye!");
                    break;
                case "turn":
                    HandleTurnCommand(command);
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

        private void HandleSrartCommand(Command command)
        {
            director.Construct(builder);
            matrix = builder.GetMatrix();
            printer.Print(matrix, player);
        }

        private void HandleRestartCommand(Command command)
        {
            throw new NotImplementedException();
        }

        private void HandleTurnCommand(Command command)
        {
            if (command.Parameters.Count != 2)
            {
                Console.WriteLine("Invalid number of arguments!");
                return;
            }
            int rowIndex;
            int colIndex;
            bool rowIsProvided = int.TryParse(command.Parameters[0], out rowIndex);
            bool columnIsProvided = int.TryParse(command.Parameters[1], out colIndex);

            if (!(rowIsProvided && columnIsProvided))
            {
                Console.WriteLine("Invalid row and column!");
                return;
            }

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

            printer.Print(matrix, player);
        }

        private void HandleGameOver()
        {
            printer.Print(matrix, player);
            Console.WriteLine("Game Over!");
            throw new NotImplementedException();
        }
    }
}
