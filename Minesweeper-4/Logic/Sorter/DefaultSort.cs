namespace Minesweeper.Logic.Sorter
{
    using Minesweeper.Data.Player;
    using System.Collections.Generic;
    using System.Linq;

    public class DefaultSort : SortStrategy // Without public access modifier can't access class in Test project?!?!
    {
        public override List<Player> Sort(IList<Player> list)
        {
            return list.OrderByDescending(x => x.Score).ThenBy(x => x.Nickname).ToList(); // adding sort by nickname
        }
    }
}
