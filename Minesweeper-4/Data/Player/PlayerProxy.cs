namespace Minesweeper.Data.Player
{
    using Minesweeper.Helpers;
    using Minesweeper.Interfaces;

    public class PlayerProxy : IPlayer
    {
        private IPlayer player;

        public PlayerProxy(string nickname, int score)
        {
            this.player = new Player();
            this.Nickname = nickname;
            this.Score = score;
        }

        public string Nickname
        {
            get
            {
                return this.player.Nickname;
            }
            set
            {
                Validator.ValidateStringLength(value, 2, 10, "Player nickname");
                this.player.Nickname = value;
            }
        }

        public int Score
        {
            get
            {
                return this.player.Score;
            }
            set
            {
                Validator.ValidateNonNegativeInt(value);
                this.player.Score = value;
            }
        }
    }
}
