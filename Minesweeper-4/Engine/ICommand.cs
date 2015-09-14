using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Engine
{
    interface ICommand
    {
        string Name { get; }

        IList<int> Parameters { get; }
    }
}
