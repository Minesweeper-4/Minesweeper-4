namespace Minesweeper.Logic.Sorter
{
    using Minesweeper.Data.Player;
    using Minesweeper.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    class DefaultSort : SortStrategy
    {
        public override List<Player> Sort(IList<Player> list)
        {
            return list.OrderByDescending(x => x.Score).ToList();
        }
    }
}
