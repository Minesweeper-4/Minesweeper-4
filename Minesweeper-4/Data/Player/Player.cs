namespace Minesweeper.Data.Player
{
    using Minesweeper.Interfaces;
    using System;
    using System.Xml.Serialization;

    [Serializable()]
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
                //TODO Idea for implementing Proxy for validation
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
