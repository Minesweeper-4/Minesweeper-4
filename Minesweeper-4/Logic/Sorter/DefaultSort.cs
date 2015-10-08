namespace Minesweeper.Logic.Sorter
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Implements the logic for sorting
    /// </summary>
    public class DefaultSort : SortStrategy // Without public access modifier can't access class in Test project?!?!
    {
        public override List<IPlayer> Sort(IList<IPlayer> list)
        {
            return list.OrderByDescending(x => x.Score).ThenBy(x => x.Nickname).ToList(); // adding sort by nickname
        }
    }
}
