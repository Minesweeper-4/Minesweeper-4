namespace Minesweeper.Logic.Scores
{
    using System.Collections.Generic;
    using Interfaces;

    /// <summary>
    /// sets the obligatory properties, needed for storing a record
    /// </summary>
    public interface IScoresHandler
    {
        IList<IPlayer> Reccords { get; }

        void AddReccord(IPlayer player);

        void SaveToFile(string filePath);

        void LoadFromFile(string filePath);
    }
}
