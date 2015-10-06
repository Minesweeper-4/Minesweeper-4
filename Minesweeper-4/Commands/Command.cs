using Minesweeper.Data;
using Minesweeper.Data.Player;
using Minesweeper.Logic.Draw;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Commands
{
    public abstract class Command
    {
        internal Printer printer;
        internal Matrix matrix;
        internal Player player;

        public Command(Matrix matrix, Player player, Printer printer)
        {
            this.matrix = matrix;
            this.player = player;
            this.printer = printer;
        }

        public abstract void Execute(ICommandInfo commandInfo);

    }
}
