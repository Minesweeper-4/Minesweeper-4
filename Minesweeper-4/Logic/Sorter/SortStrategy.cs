namespace Minesweeper.Logic.Sorter
{
    using Minesweeper.Interfaces;
    using System.Collections.Generic;
    
    /// <summary>
    /// Set the obligatory property for sorting the records
    /// </summary>
    public abstract class SortStrategy
    {
        /// <summary>
        /// Abstract Sort method
        /// </summary>
        /// <param name="list">List of players</param>
        /// <returns>List of sorted players</returns>
        public abstract List<IPlayer> Sort(IList<IPlayer> list);
    }
}
