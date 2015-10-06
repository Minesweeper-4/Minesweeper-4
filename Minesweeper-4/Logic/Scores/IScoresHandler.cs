namespace Minesweeper.Logic.Scores
{
    using Minesweeper.Data.Player;
    using Interfaces;
    using System.Collections.Generic;

    interface IScoresHandler
    {
        IList<IPlayer> Reccords { get; }
        void AddReccord(IPlayer player);
        void SaveToFile();
        void LoadFromFile();
    }
}
