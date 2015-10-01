namespace Minesweeper.Engine
{
    using System;
    using Minesweeper.Data;
    using Minesweeper.Logic;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Interfaces;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Scores;
    using System.IO;
    using System.Xml.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Threading;
    using Minesweeper.Helpers;
    using Minesweeper.Commands;

    public class MinesweeperEngine
    {
        private static MinesweeperEngine mineSweeperEngineInstance;
        private static object locker = new object();

        private Printer printer = new StandardPrinter();
        private MatrixDirector director = new MatrixDirector();
        private readonly MatrixBuilder builder = new BigMatrixBuilder();
        private Player player = new Player();
        private ICommandParser commandParser = new CommandParser();
        private Matrix matrix;
        ICommandFactory commandFactory;
        private MatrixFactory matrixFactory = new MatrixFactory();

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
            CommandInfo commandInfo;
            Command currentCommand;
            commandFactory = new CommandFactory(this.matrix, player, director, builder, printer);

            do
            {
                commandInfo = (CommandInfo)commandParser.Parse(Console.ReadLine());
                currentCommand = this.commandFactory.GetCommand(commandInfo);
                currentCommand.Execute(commandInfo);

            } while (commandInfo.Name != "exit");
        }

        //private void ReadCommand(Command command)
        //{
        //    switch (command.Name)
        //    {
        //        case "top":
        //            printer.PrintLine("Top");
        //            break;
        //        case "start":

        //            break;
        //        case "restart":
        //            HandleRestartCommand(command);
        //            break;
        //        case "save":
        //            Console.WriteLine("saved");
        //            HandleSaveCommand();
        //            break;
        //        case "load":
        //            HandleLoadCommand();
        //            break;
        //        case "exit":
        //            printer.PrintLine("Good bye");
        //            break;
        //        case "turn":
        //            HandleTurnCommand(command);
        //            break;
        //        case "mode":
        //            if (command.Parameters.Count != 1)
        //            {
        //                printer.PrintLine("Invalid mode!");
        //            }

        //            if (command.Parameters[0] == "light")
        //            {
        //                var printerLightMode = new PrinterLightMode();
        //                printerLightMode.SetPrinter(this.printer);
        //                printerLightMode.Apply();
        //                printerLightMode.PrintMatrix(this.matrix, this.player);
        //                this.printer = printerLightMode;
        //            }
        //            else if (command.Parameters[0] == "dark")
        //            {
        //                var printerDarkMode = new PrinterDarkMode();
        //                printerDarkMode.SetPrinter(this.printer);
        //                printerDarkMode.Apply();
        //                printerDarkMode.PrintMatrix(this.matrix, this.player);
        //                this.printer = printerDarkMode;
        //            }
        //            else
        //            {
        //                printer.PrintLine("Invalid mode!");
        //            }

        //            break;
        //        default:
        //            printer.PrintLine("\nIllegal move!\n");
        //            break;

        //    }
        //}

        //private void HandleSrartCommand(Command command)
        //{
        //    director.Construct(builder); //Here comes the Builder
        //    matrix = builder.GetMatrix();
        //    printer.PrintMatrix(matrix, player);
        //}

        //private void HandleRestartCommand(Command command)
        //{
        //    throw new NotImplementedException();
        //}

        //private void HandleTurnCommand(Command command)
        //{
        //    if (!ValidateInput(command))
        //    {
        //        return;
        //    }
        //    int rowIndex = int.Parse(command.Parameters[0]);
        //    int colIndex = int.Parse(command.Parameters[1]);

        //    var currentCell = matrix.Field[rowIndex, colIndex];
        //    currentCell.IsOpen = true;


        //    if (currentCell.IsBomb)
        //    {
        //        HandleGameOver();
        //        return;
        //    }
        //    else
        //    {
        //        this.player.Score++;
        //        if (currentCell.NumberOfMines == 0)
        //        {
        //            CheckForZeroMines(rowIndex, colIndex);
        //        }
        //    }

        //    printer.PrintMatrix(matrix, player);
        //}


        //private void HandleSaveCommand()
        //{
        //    var memento = matrix.SaveMemento(); // Here comes memento
        //    var serializer = new Serializer();

        //    serializer.Serialize(memento, GlobalErrorMessages.SaveMatrixFileName);
        //}

        //private void HandleLoadCommand()
        //{
        //    var serializer = new Serializer();
        //    var memento = serializer.Deserialize(GlobalErrorMessages.SaveMatrixFileName);

        //    matrix.RestoreMemento(memento as MatrixMemento);
        //    printer.PrintMatrix(matrix, player);
        //}

        //private void CheckForZeroMines(int rowIndex, int colIndex)
        //{
        //    var minRow = Math.Max(0, rowIndex - 1);
        //    var maxRow = Math.Min(rowIndex + 1, this.matrix.Cols - 1);
        //    var minCol = Math.Max(0, colIndex - 1);
        //    var maxCol = Math.Min(colIndex + 1, this.matrix.Cols - 1);

        //    for (int row = minRow; row <= maxRow; row++)
        //    {
        //        for (int col = minCol; col <= maxCol; col++)
        //        {

        //            if (this.matrix.Field[row, col].NumberOfMines == 0 && !this.matrix.Field[row, col].IsOpen)
        //            {
        //                this.matrix.Field[row, col].IsOpen = true;
        //                CheckForZeroMines(row, col);
        //            }
        //            else
        //            {
        //                this.matrix.Field[row, col].IsOpen = true;
        //            }
        //        }
        //    }
        //}

        //private bool HasZeroMinesNeighbour(int rowIndex, int colIndex)
        //{
        //    var minRow = Math.Max(0, rowIndex - 1);
        //    var maxRow = Math.Min(rowIndex + 1, this.matrix.Cols - 1);
        //    var minCol = Math.Max(0, colIndex - 1);
        //    var maxCol = Math.Min(colIndex + 1, this.matrix.Cols - 1);

        //    for (int row = minRow; row <= maxRow; row++)
        //    {
        //        for (int col = minCol; col <= maxCol; col++)
        //        {
        //            if (this.matrix.Field[row, col].NumberOfMines == 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }

        //    return false;
        //}

        //private void HandleGameOver()
        //{
        //    printer.PrintMatrix(matrix, player);
        //    Console.WriteLine("Game Over!");
        //    EnterScoreRecordHandler();
        //}

        //private void EnterScoreRecordHandler()
        //{
        //    Console.Write("Enter your nickname: ");
        //    this.player.Nickname = Console.ReadLine();

        //    // When the serializer is fixed we need to use PlayerProxy class
        //    //var nickname = Console.ReadLine();
        //    //var playerProxy = new PlayerProxy(nickname, this.player.Score);

        //    var scoresHandler = new ScoresHandler("records.xml");
        //    scoresHandler.LoadFromFile();
        //    scoresHandler.AddReccord(this.player);
        //    scoresHandler.SaveToFile();
        //}

        //private bool ValidateInput(Command command)
        //{
        //    if (command.Parameters.Count != 2)
        //    {
        //        printer.PrintLine("Invalid number of arguments!");
        //        return false;
        //    }

        //    int rowIndex;
        //    int colIndex;

        //    try
        //    {
        //        rowIndex = int.Parse(command.Parameters[0]);
        //        colIndex = int.Parse(command.Parameters[1]);
        //    }
        //    catch (Exception)
        //    {
        //        printer.PrintLine("Invalid row and column!");
        //        return false;
        //    }

        //    int maxRow = matrix.Rows;
        //    int maxCol = matrix.Cols;

        //    bool isRowInRange = (0 <= rowIndex) && (rowIndex < maxRow);
        //    bool isColInRange = (0 <= colIndex) && (colIndex < maxCol);

        //    if (!(isRowInRange && isColInRange))
        //    {
        //        printer.PrintLine("Row or column are outside of the range of the matrix");
        //        return false;
        //    }


        //    return true;
        //}

        //// Method just to test thread-safe implementation of the singleton
        //public void PrintThreadNumber(int number)
        //{
        //    for (int i = 0; i < 10000000; i++)
        //    {
        //        var chislo = i * i;
        //    }

        //    Console.WriteLine("This is thread number {0}", number);
        //}

        //public Command commandInfo { get; set; }
    }
}
