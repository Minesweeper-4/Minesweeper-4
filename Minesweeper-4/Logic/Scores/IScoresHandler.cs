using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minesweeper.Interfaces;
using Minesweeper.Data.Player;

namespace Minesweeper.Logic.Scores
{
    interface IScoresHandler
    {
        IList<Player> Reccords { get; }
        void AddReccord(Player player);
        void SaveToFile();
        void LoadFromFile();
    }
}
