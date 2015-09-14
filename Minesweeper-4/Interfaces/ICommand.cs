using System.Collections.Generic;

namespace Minesweeper.Interfaces
{
    interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
