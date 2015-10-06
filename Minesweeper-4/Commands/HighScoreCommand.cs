namespace Minesweeper.Commands
{
    using Minesweeper.Data;
    using Minesweeper.Data.Player;
    using Minesweeper.Engine;
    using Interfaces;
    using Minesweeper.Logic.Draw;
    using Minesweeper.Logic.Scores;
    using System;
    using System.Collections.Generic;
    using Minesweeper.Menu;

    public class HighScoreCommand : Command
    {
        private MinesweeperEngine engine;

        public HighScoreCommand(MinesweeperEngine engine, Matrix matrix, Player player, Printer printer)
            : base(matrix, player, printer)
        {
            this.engine = engine;
        }

        public override void Execute(ICommandInfo commandInfo)
        {
            var scoresHandler = new ScoresHandler();
            scoresHandler.LoadFromFile();
            List<IPlayer> records = (List<IPlayer>)scoresHandler.Reccords;

            foreach (var record in records)
            {
                var recordToString = string.Format("{0} - {1}", record.Nickname, record.Score);
                printer.PrintLine(recordToString);
            }

            Console.WriteLine("Press any key to continiue..");
            Console.ReadKey();
            MainMenu.PrintMenu(this.engine);
        }
    }
}
