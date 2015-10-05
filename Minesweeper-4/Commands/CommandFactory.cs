using Minesweeper.Data;
using Minesweeper.Data.Player;
using Minesweeper.Engine;
using Minesweeper.Logic.Draw;
using System;
namespace Minesweeper.Commands
{
    public class CommandFactory : ICommandFactory
    {
        private StartCommand startCommand;
        private TurnCommand turnCommand;

        private Matrix matrix;
        private Player player;
        private MatrixDirector matrixDirector;
        private MatrixBuilder matrixBuilder;
        private Printer printer;
        private MinesweeperEngine engine;

        public CommandFactory(MinesweeperEngine engine, Matrix matrix, Player player, MatrixDirector matrixDirector, MatrixBuilder matrixBuilder, Printer printer)
        {
            this.engine = engine;
            this.matrix = matrix;
            this.player = player;
            this.matrixDirector = matrixDirector;
            this.matrixBuilder = matrixBuilder;
            this.printer = printer;
        }

        public Command GetCommand(CommandInfo commadInfo)
        {
            if (commadInfo.Name == "start")
            {
                if (this.startCommand == null)
                {
                    this.startCommand = new StartCommand(this.engine, this.matrix, this.player, this.matrixDirector, this.matrixBuilder, this.printer);
                }

                return this.startCommand;
            }
            if (commadInfo.Name == "turn")
            {
                if (this.turnCommand == null)
                {
                    this.turnCommand = new TurnCommand(this.matrix, this.player, this.matrixDirector, this.matrixBuilder, this.printer);
                }

                return this.turnCommand;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
