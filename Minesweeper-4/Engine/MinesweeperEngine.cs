namespace Minesweeper.Engine
{
    using Menu;
    using Minesweeper.Commands;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;
    using System;

    public class MinesweeperEngine : IMinesweeperEngine
    {
        private static MinesweeperEngine mineSweeperEngineInstance;
        private static object locker = new object();

        private Printer printer = new StandardPrinter();
        private MatrixDirector director = new MatrixDirector();
        private readonly MatrixBuilder builder = new BigMatrixBuilder();
        private Player player = new Player();
        private ICommandParser commandParser = new CommandParser();
        private MatrixFactory matrixFactory = new MatrixFactory();
        private Matrix matrix;

        private MinesweeperEngine()
        {
        }

        public static MinesweeperEngine Instance
        {
            get
            {

                if (mineSweeperEngineInstance == null)
                {
                    lock (locker)
                    {
                        if (mineSweeperEngineInstance == null)
                        {

                            mineSweeperEngineInstance = new MinesweeperEngine();

                        }
                    }
                }

                return mineSweeperEngineInstance;
            }
        }

        public void Start()
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();

            ExecuteCommand(command);
        }

        public void ExecuteCommand(string command)
        {
            CommandInfo commandInfo = (CommandInfo)commandParser.Parse(command);
            Command currentCommand = null;

            switch (commandInfo.Name)
            {
                case "start":
                    currentCommand = new StartCommand(this, this.matrix, player, this.director, this.builder, this.printer);
                    break;

                case "turn":
                    currentCommand = new TurnCommand(this, this.matrix, this.player, this.printer);
                    break;

                case "menu":
                    MainMenu.PrintMenu(this);
                    break;

                case "exit":
                    currentCommand = new ExitCommand(this.matrix, this.player, this.printer);
                    break;

                case "save":
                    currentCommand = new SaveCommand(this.matrix, this.player, this.printer);
                    break;

                case "load":
                    currentCommand = new LoadCommand(this.matrix, this.player, this.printer);
                    break;

                case "mode":
                    currentCommand = new ChangeModeCommand(this, this.matrix, this.player, this.printer);
                    break;

                case "highscore":
                    currentCommand = new HighScoreCommand(this, this.matrix, this.player, this.printer);
                    break;

                default:
                    currentCommand = new InvalidCommand(this.matrix, this.player, this.printer);
                    break;
            }

            currentCommand.Execute(commandInfo);
            this.printer.PrintMatrix(this.matrix, this.player);
            this.Start();
        }


        public void CreateMatrix(MatrixTypes type)
        {
            this.matrix = (Matrix)(new MatrixFactory().CreateMatrix(type));
            //this.printer.PrintMatrix(matrix, player);
        }
    }
}
