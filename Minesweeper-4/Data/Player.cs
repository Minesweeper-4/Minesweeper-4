namespace Minesweeper.Data
{
    using Minesweeper.Interfaces;

    class Player : IPlayer
    {
        public Player(string nickName)
        {
            this.NickName = nickName;
            this.Scores = 0;
        }

        public string NickName
        {
            get
            {
                return this.NickName;
            }
            private set
            {
                this.NickName = value;
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
