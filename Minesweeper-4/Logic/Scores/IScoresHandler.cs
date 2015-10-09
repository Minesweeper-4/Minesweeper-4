namespace Minesweeper.Logic.Scores
{
    using Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// sets the obligatory properties, needed for storing a record
    /// </summary>
    public interface IScoresHandler
    {
        /// <summary>
        /// Gets the reccords for the player
        /// </summary>
        IList<IPlayer> Reccords { get; }

        /// <summary>
        /// Add records to player
        /// </summary>
        /// <param name="player">Input player</param>
        void AddReccord(IPlayer player);

        /// <summary>
        /// Save records to file
        /// </summary>
        /// <param name="filePath">File path</param>
        void SaveToFile(string filePath);

        /// <summary>
        /// Load records form file
        /// </summary>
        /// <param name="filePath">File path</param>
        void LoadFromFile(string filePath);
    }
}
