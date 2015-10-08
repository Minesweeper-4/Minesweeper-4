namespace Minesweeper.Data.Player
{
    using System;
    using System.Xml.Serialization;
    using Minesweeper.Interfaces;

    /// <summary>
    /// Implements the Serializer design pattern. Set the details of the player
    /// </summary>
    [Serializable]
    public class Player : IPlayer
    {
        private int score;
        private string nickname;

        public Player() // The Serializer needs empty constructor !!!
        {
        }

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
