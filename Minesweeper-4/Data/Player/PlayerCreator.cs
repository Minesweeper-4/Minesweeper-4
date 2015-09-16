namespace Minesweeper.Data.Player
{
    using Minesweeper.Interfaces;
    using System;

    class PlayerCreator
    {
        private const int InitialPlayerScores = 0;

        public IPlayer CreateNewPlayer(string nickname = "Guest")
        {
            return new Player(nickname, InitialPlayerScores);
        }

        public IPlayer CreatePlayer(string nickname, int scores)
        {
            return new Player(nickname, scores);
        }
    }
}
