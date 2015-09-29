using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Commands
{
    public interface ICommandFactory
    {
        Command GetCommand(CommandInfo commandInfo);
    }
}
