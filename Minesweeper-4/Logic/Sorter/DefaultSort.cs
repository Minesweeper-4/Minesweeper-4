namespace Minesweeper.Logic.Sorter
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Implements the logic for sorting
    /// </summary>
    public class DefaultSort : SortStrategy
    {
        /// <summary>
        /// Sorts player by score and by name
        /// </summary>
        /// <param name="list">List of players</param>
        /// <returns>List of sorted players</returns>
        public override List<IPlayer> Sort(IList<IPlayer> list)
        {
            return list.OrderByDescending(x => x.Score).ThenBy(x => x.Nickname).ToList();
        }
    }
}
