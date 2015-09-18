namespace Minesweeper.Data.Player
{
    using Minesweeper.Interfaces;
    using System;

    public class PlayerCreator
    {
        private const int InitialPlayerScores = 0;

        public Player CreateNewPlayer(string nickname = "Guest")
        {
            return new Player(nickname, InitialPlayerScores);
        }

        public Player CreatePlayer(string nickname, int scores)
        {
            return new Player(nickname, scores);
        }
    }
}
