namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Logic.Scores;
    using System;

    class TurnCommand : Command
    {
        public TurnCommand( Matrix matrix, Player player, MatrixDirector matrixDirector, MatrixBuilder matrixBuilder, Printer printer)
            : base(matrix, player, matrixDirector, matrixBuilder, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            if (!ValidateInput(commandInfo))
            {
                return;
            }

            int rowIndex = int.Parse(commandInfo.Params[0]);
            int colIndex = int.Parse(commandInfo.Params[1]);

            var currentCell = matrix.Field[rowIndex, colIndex];
            currentCell.IsOpen = true;


            if (currentCell.IsBomb)
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

            // When the serializer is fixed we need to use PlayerProxy class
            //var nickname = Console.ReadLine();
            //var playerProxy = new PlayerProxy(nickname, this.player.Score);

            var scoresHandler = new ScoresHandler("records.xml");
            scoresHandler.LoadFromFile();
            scoresHandler.AddReccord(this.player);
            scoresHandler.SaveToFile();
        }

        private void CheckForZeroMines(int rowIndex, int colIndex)
        {
            var minRow = Math.Max(0, rowIndex - 1);
            var maxRow = Math.Min(rowIndex + 1, this.matrix.Cols - 1);
            var minCol = Math.Max(0, colIndex - 1);
            var maxCol = Math.Min(colIndex + 1, this.matrix.Cols - 1);

            for (int row = minRow; row <= maxRow; row++)
            {
                for (int col = minCol; col <= maxCol; col++)
                {

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

        private bool ValidateInput(ICommandInfo command)
        {
            if (command.Params.Count != 2)
            {
                printer.PrintLine("Invalid number of arguments!");
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
