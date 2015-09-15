using System.Collections.Generic;

namespace Minesweeper.Interfaces
{
    public interface ICommand
    {
        string Name { get; }

        IList<string> Parameters { get; }
    }
}
