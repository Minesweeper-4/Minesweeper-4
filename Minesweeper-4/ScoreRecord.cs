namespace Minesweeper
{
    using System;

    public class ScoreRecord
    {
        string personName;
        int scorePoints;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }
        public int ScorePoints
        {
            get
            {
                return scorePoints;


            }
            set { scorePoints = value; }
        }

        public ScoreRecord() { }

        public ScoreRecord(string personName, int points)
        {
            this.personName = personName;
            this.scorePoints = points;
        }
    }
}
