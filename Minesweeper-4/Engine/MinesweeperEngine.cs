namespace Minesweeper.Engine
{
    using System;
    using Menu;
    using Minesweeper.Commands;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;

    /// <summary>
    /// Sets the core functions of the matrix and player commands
    /// </summary>
    public class MinesweeperEngine : IMinesweeperEngine
    {
        private static MinesweeperEngine mineSweeperEngineInstance;
        private static object locker = new object();
        private readonly MatrixBuilder builder = new BigMatrixBuilder();

        private Printer printer = new StandardPrinter();
        private MatrixDirector director = new MatrixDirector();
        private Player player = new Player();
        private ICommandParser commandParser = new CommandParser();
        private MatrixFactory matrixFactory = new MatrixFactory();
        private Matrix matrix;

        private MinesweeperEngine()
        {
        }

        /// <summary>
        /// Returns instance of the game engine. Cannot have more than one instances.
        /// </summary>
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

        /// <summary>
        /// Method which builds game and sets game fields.
        /// </summary>
        public void Start()
        {
            Console.Write("Enter command: ");
            string command = Console.ReadLine();

            this.ExecuteCommand(command);
        }

        /// <summary>
        /// Method which process input commands
        /// </summary>
        /// <param name="command">inut command</param>
        public void ExecuteCommand(string command)
        {
            CommandInfo commandInfo = (CommandInfo)this.commandParser.Parse(command);
            Command currentCommand = null;

            switch (commandInfo.Name)
            {
                case "start":
                    currentCommand = new StartCommand(this, this.matrix, this.player, this.director, this.builder, this.printer);
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
                    currentCommand.Execute(commandInfo);
                    this.Start();
                    return;
            }

            currentCommand.Execute(commandInfo);
            this.printer.PrintMatrix(this.matrix, this.player);
            this.Start();
        }

        /// <summary>
        /// Method for creating the game matrix.
        /// </summary>
        /// <param name="type">Matrix type</param>
        public void CreateMatrix(MatrixTypes type)
        {
            this.matrix = (Matrix)new MatrixFactory().CreateMatrix(type);
        }
    }
}
