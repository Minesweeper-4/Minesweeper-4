﻿using Minesweeper.Commands;
using Minesweeper.Data;
using Minesweeper.Data.Player;
using Minesweeper.Engine;
using Minesweeper.Interfaces;
using Minesweeper.Logic.Draw;
using NUnit.Framework;
using System.Collections.Generic;
using System;

using Minesweeper.Logic.Draw;

namespace NunitTests
{
    [TestFixture]
    public class StartCommandTests
    {
        private Matrix matrix = new Matrix();
        private Player player = new Player();
        private Printer printer = new StandardPrinter();
        [Test]
        public void ShouldThrowWhenInvalidMatrixTypeIsPassed()
        {
            

            var startCommand = new StartCommand(MinesweeperEngine.Instance, matrix,
                player, new MatrixDirector(), new MediumMatrixBuilder(), printer);

            ICommandInfo command = new CommandInfo("", new List<string>() { "invalid type" });

            Assert.Throws(typeof(ArgumentOutOfRangeException), () => startCommand.Execute(command));
        }

        [Test]
        public void ShouldBeAbleToCreateMatrixOfDifferentTypes()
        {

        }
    }
}
