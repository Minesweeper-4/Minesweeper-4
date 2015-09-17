namespace Minesweeper.Logic.Scores
{
    using Minesweeper.Data.Player;
    using System.Collections.Generic;

    interface IScoresHandler
    {
        IList<Player> Reccords { get; }
        void AddReccord(Player player);
        void SaveToFile();
        void LoadFromFile();
    }
}
