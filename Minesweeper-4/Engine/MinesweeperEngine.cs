﻿namespace Minesweeper.Engine
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

    public class MinesweeperEngine
    {
        private static MinesweeperEngine mineSweeperEngineInstance;
        private static object locker = new object();

        private  Printer printer = new StandardPrinter();
        private readonly MatrixDirector director = new MatrixDirector();
        private readonly MatrixBuilder builder = new BigMatrixBuilder();
        private Player player;

        private Matrix matrix;

        private MinesweeperEngine()
        {
        }

        public static MinesweeperEngine Instance
        {
            get {

                if(mineSweeperEngineInstance == null){

                    lock(locker){

                        if(mineSweeperEngineInstance == null){

                            mineSweeperEngineInstance = new MinesweeperEngine();

                        }
                    }
                }

                return mineSweeperEngineInstance;
            }
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
                case "save":
                    Console.WriteLine("saved");
                    HandleSaveCommand();
                    break;
                case "load":
                    HandleLoadCommand();
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

                    if (command.Parameters[0] == "light")
                    {
                        var lightPrinter = new PrinterLightTheme();
                        lightPrinter.SetPrinter(this.printer);
                        lightPrinter.ApplyLightTheme();
                        lightPrinter.PrintMatrix(this.matrix, this.player);
                        this.printer = lightPrinter;
                    }
                    else if (command.Parameters[0] == "standard")
                    {
                        // TODO to be implemented
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
            director.Construct(builder); //Here comes the Builder
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
                return;
            }
            else
            {
                this.player.Score++;
                if (currentCell.NumberOfMines == 0)
                {
                    CheckForZeroMines(rowIndex, colIndex);
                }
            }

            printer.PrintMatrix(matrix, player);
        }


        private void HandleSaveCommand()
        {
            var memento = matrix.SaveMemento(); // Here comes memento

            var writer = new FileStream("save.dat", FileMode.Open);

            BinaryFormatter mySerializer = new BinaryFormatter();


            mySerializer.Serialize(writer, memento);
            writer.Position = 0;

            writer.Close();
        }

        private void HandleLoadCommand()
        {
            var writer = new FileStream("save.dat", FileMode.Open);

            BinaryFormatter mySerializer = new BinaryFormatter();

            var memento = mySerializer.Deserialize(writer) as MatrixMemento;
            matrix.RestoreMemento(memento);
            writer.Close();

            printer.PrintMatrix(matrix, player);
        }

        private void CheckForZeroMines(int rowIndex, int colIndex)
        {
            var minRow = Math.Max(0, rowIndex - 1);
            var maxRow = Math.Min(rowIndex + 1, this.matrix.Cols - 1);
            var minCol = Math.Max(0, colIndex - 1);
            var maxCol = Math.Min(colIndex + 1, this.matrix.Cols - 1);
            
            for (int row = minRow; row <= maxRow; row++)
            {
                for (int col = minCol; col <= maxCol; col++)                {
                    
                    if (this.matrix.Field[row, col].NumberOfMines == 0 && !this.matrix.Field[row, col].IsOpen)
                    {
                        this.matrix.Field[row, col].IsOpen = true;
                        CheckForZeroMines(row, col);                        
                    }
                    else
                    {
                        this.matrix.Field[row, col].IsOpen = true;
                    }
                }
            }
        }

        private bool HasZeroMinesNeighbour(int rowIndex, int colIndex)
        {
            var minRow = Math.Max(0, rowIndex - 1);
            var maxRow = Math.Min(rowIndex + 1, this.matrix.Cols - 1);
            var minCol = Math.Max(0, colIndex - 1);
            var maxCol = Math.Min(colIndex + 1, this.matrix.Cols - 1);

            for (int row = minRow; row <= maxRow; row++)
            {
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (this.matrix.Field[row, col].NumberOfMines == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void HandleGameOver()
        {
            printer.PrintMatrix(matrix, player);
            Console.WriteLine("Game Over!");
            EnterScoreRecordHandler();
        }

        private void EnterScoreRecordHandler()
        {
            Console.Write("Enter your nickname: ");
            this.player.Nickname = Console.ReadLine();

            var scoresHandler = new ScoresHandler("records.xml");
            scoresHandler.LoadFromFile();
            scoresHandler.AddReccord(this.player);
            scoresHandler.SaveToFile();
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
