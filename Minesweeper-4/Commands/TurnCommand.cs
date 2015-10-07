namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Logic.Scores;
    using Minesweeper.Menu;
    using System;

    public class TurnCommand : Command
    {
        private MinesweeperEngine engine;

        public TurnCommand(MinesweeperEngine engine, Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
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

            // When the serializer is fixed we need to use PlayerProxy class
            var nickname = Console.ReadLine();
            var playerProxy = new PlayerProxy(nickname, this.player.Score);

            var scoresHandler = new ScoresHandler();
            scoresHandler.LoadFromFile();
            scoresHandler.AddReccord(playerProxy);
            scoresHandler.SaveToFile();
            Console.WriteLine("Press any key to continiue..");
            Console.ReadKey();
            MainMenu.PrintMenu(engine);
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
                        base.player.Score++;
                        this.matrix.Field[row, col].IsOpen = true;
                        CheckForZeroMines(row, col);
                    }
                    else if (!this.matrix.Field[row, col].IsOpen)
                    {
                        base.player.Score++;
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
