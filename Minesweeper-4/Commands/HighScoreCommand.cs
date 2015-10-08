namespace Minesweeper.Commands
{
    using System.Collections.Generic;
    using Helpers;
    using Interfaces;
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Logic.Scores;
    using Minesweeper.Menu;

    /// <summary>
    /// Inherits the Command abstract class and implments the logic for the displaying the records
    /// </summary>
    public class HighScoreCommand : Command
    {
        private MinesweeperEngine engine;

        public HighScoreCommand(MinesweeperEngine engine, Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
        }

        /// <summary>
        /// Method that loads the records from a file, and displays them
        /// </summary>
        /// <param name="commandInfo">HIGHSCORE Command needed</param>
        public override void Execute(ICommandInfo commandInfo)
        {
            var scoresHandler = new ScoresHandler();
            scoresHandler.LoadFromFile(GlobalErrorMessages.SaveRecordstFileName);
            List<IPlayer> records = (List<IPlayer>)scoresHandler.Reccords;

            foreach (var record in records)
            {
                var recordToString = string.Format("{0} - {1}", record.Nickname, record.Score);
                this.Printer.PrintLine(recordToString);
            }

            Navigation.ReturnExitNavigation(this.engine, new SecondMenuOptions());
        }
    }
}
