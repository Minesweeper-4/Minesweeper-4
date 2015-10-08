namespace Minesweeper.Commands
{
    using System;
    using Helpers;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Logic.Scores;
    using Minesweeper.Menu;

    /// <summary>
    /// Inherits the base Command Class and deals with the moves of the user
    /// </summary>
    public class TurnCommand : Command
    {
        private MinesweeperEngine engine;

        public TurnCommand(MinesweeperEngine engine, Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
        }

        /// <summary>
        /// Method for processing the user input
        /// </summary>
        /// <param name="commandInfo"></param>
        public override void Execute(ICommandInfo commandInfo)
        {
            if (!this.ValidateInput(commandInfo))
            {
                return;
            }

            int rowIndex = int.Parse(commandInfo.Params[0]);
            int colIndex = int.Parse(commandInfo.Params[1]);

            var currentCell = Matrix.Field[rowIndex, colIndex];
            currentCell.IsOpen = true;

            if (currentCell.IsBomb)
            {
                this.HandleGameOver();
                return;
            }
            else
            {
                this.Player.Score++;
                if (currentCell.NumberOfMines == 0)
                {
                    this.CheckForZeroMines(rowIndex, colIndex);
                }
            }

            this.Printer.PrintMatrix(this.Matrix, this.Player);
        }

        /// <summary>
        /// Method to handle the end of the game
        /// </summary>
        private void HandleGameOver()
        {
            this.Printer.PrintMatrix(this.Matrix, this.Player);
            Console.WriteLine("Game Over!");
            this.EnterScoreRecordHandler();
        }

        /// <summary>
        /// Method to add you score to the highscore table
        /// </summary>
        private void EnterScoreRecordHandler()
        {
            Console.Write("Enter your nickname: ");

            var nickname = Console.ReadLine();

            try
            {
                var playerProxy = new PlayerProxy(nickname, this.Player.Score);
                var scoresHandler = new ScoresHandler();
                scoresHandler.LoadFromFile(GlobalErrorMessages.SaveRecordstFileName);
                scoresHandler.AddReccord(playerProxy);
                scoresHandler.SaveToFile(GlobalErrorMessages.SaveRecordstFileName);
                Console.WriteLine("Press any key to continiue..");
                Console.ReadKey();
                MainMenu.PrintMenu(this.engine);
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The name should be between 2 and 10 characters");
                this.EnterScoreRecordHandler();
            }
        }

        private void CheckForZeroMines(int rowIndex, int colIndex)
        {
            var minRow = Math.Max(0, rowIndex - 1);
            var maxRow = Math.Min(rowIndex + 1, this.Matrix.Cols - 1);
            var minCol = Math.Max(0, colIndex - 1);
            var maxCol = Math.Min(colIndex + 1, this.Matrix.Cols - 1);

            for (int row = minRow; row <= maxRow; row++)
            {
                for (int col = minCol; col <= maxCol; col++)
                {
                    if (this.Matrix.Field[row, col].NumberOfMines == 0 && !this.Matrix.Field[row, col].IsOpen)
                    {
                        this.Player.Score++;
                        this.Matrix.Field[row, col].IsOpen = true;
                        this.CheckForZeroMines(row, col);
                    }
                    else if (!this.Matrix.Field[row, col].IsOpen)
                    {
                        this.Player.Score++;
                        this.Matrix.Field[row, col].IsOpen = true;
                    }
                }
            }
        }

        private bool ValidateInput(ICommandInfo command)
        {
            if (command.Params.Count != 2)
            {
                this.Printer.PrintLine("Invalid number of arguments!");
                return false;
            }

            int rowIndex;
            int colIndex;

            try
            {
                rowIndex = int.Parse(command.Params[0]);
                colIndex = int.Parse(command.Params[1]);
            }
            catch (Exception)
            {
                this.Printer.PrintLine("Invalid row and column!");
                return false;
            }

            int maxRow = this.Matrix.Rows;
            int maxCol = this.Matrix.Cols;

            bool isRowInRange = (0 <= rowIndex) && (rowIndex < maxRow);
            bool isColInRange = (0 <= colIndex) && (colIndex < maxCol);

            if (!(isRowInRange && isColInRange))
            {
                this.Printer.PrintLine("Row or column are outside of the range of the matrix");
                return false;
            }

            return true;
        }
    }
}
