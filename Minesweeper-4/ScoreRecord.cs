namespace Minesweeper
{
    using System;

    public class ScoreRecord
    {
        private string personName;
        private int scorePoints;

        public ScoreRecord()
        {
        }

        public ScoreRecord(string personName, int points)
        {
            this.personName = personName;
            this.scorePoints = points;
        }

        public string PersonName
        {
            get
            {
                return this.personName;
            }

            set
            {
                this.personName = value;
            }
        }

        public int ScorePoints
        {
            get
            {
                return this.scorePoints;
            }

            set
            {
                this.scorePoints = value;
            }
        }
    }
}
