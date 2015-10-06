namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Logic.Scores;
    using System;
    using System.Collections.Generic;

    public class HighScoreCommand : Command
    {
        public HighScoreCommand(Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            var scoresHandler = new ScoresHandler();
            scoresHandler.LoadFromFile();
            List<Player> records = (List<Player>)scoresHandler.Reccords;

            foreach (var record in records)
            {
                var recordToString = string.Format("{0} - {1}", record.Nickname, record.Score);
                printer.PrintLine(recordToString);
            }

            Console.WriteLine("Press any key to continiue..");
            Console.ReadLine();
        }
    }
}
