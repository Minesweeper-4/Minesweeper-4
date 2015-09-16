namespace Minesweeper.Data.Player
{
    using Minesweeper.Interfaces;

    public class Player : IPlayer
    {
        private int score;
        private string nickname;

        public Player(string nickName, int scores)
        {
            this.Nickname = nickName;
            this.Score = scores;
        }

        public string Nickname
        {
            get
            {
                return this.nickname;
            }
            set
            {
                this.nickname = value;
            }
        }

        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }
    }
}
