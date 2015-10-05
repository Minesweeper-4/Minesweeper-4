using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Commands
{
    public interface ICommandInfo
    {
        string Name { get; }
        IList<string> Params { get; }
    }
}
