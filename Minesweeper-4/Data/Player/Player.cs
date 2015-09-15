namespace Minesweeper.Data.Player
{
    using Minesweeper.Interfaces;

    public class Player : IPlayer
    {
        public Player(string nickName, int scores = 0)
        {
            this.Nickname = nickName;
            this.Scores = scores;
        }

        public string Nickname
        {
            get
            {
                return this.Nickname;
            }
            set
            {
                this.Nickname = value;
            }
        }

        public int Scores
        {
            get
            {
                return this.Scores;
            }
            set
            {
                this.Scores = value;
            }
        }
    }
}
