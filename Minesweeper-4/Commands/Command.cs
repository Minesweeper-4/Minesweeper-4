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
        internal MatrixDirector director;
        internal MatrixBuilder builder;
        internal Printer printer;
        internal Matrix matrix;
        internal Player player;

        public Command(Matrix matrix, Player player, MatrixDirector matrixDirector, MatrixBuilder matrixBuilder, Printer printer)
        {
            this.matrix = matrix;
            this.player = player;
            this.director = matrixDirector;
            this.builder = matrixBuilder;
            this.printer = printer;
        }

        public abstract void Execute(ICommandInfo commandInfo);

    }
}
