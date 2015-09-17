namespace Minesweeper.Logic.Scores
{
    using Minesweeper.Data.Player;
    using Minesweeper.Logic.Sorter;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    class ScoresHandler : IScoresHandler
    {
        private List<Player> records;
        private string storingPath;
        private SortStrategy sortStrategy = new DefaultSort();

        public ScoresHandler(string storingPath)
        {
            this.StoringPath = storingPath;
            this.records = new List<Player>();
        }

        public IList<Player> Reccords
        {
            get { throw new NotImplementedException(); }
        }

        public string StoringPath
        {
            get
            {
                return this.storingPath;
            }

            private set
            {
                this.storingPath = value;
            }
        }

        public void AddReccord(Player player)
        {
            var lastRecordScore = this.records.Last().Score;

            if (this.records.Count < 10 || player.Score > lastRecordScore)
            {
                this.records.Add(player);
            }

            SortRecords();
        }

        public void SaveToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));

            using (StreamWriter streamWriter = System.IO.File.CreateText(this.StoringPath))
            {
                xmlSerializer.Serialize(streamWriter, this.records);
            }
        }

        public void LoadFromFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));

            using (StreamReader streamReader = new System.IO.StreamReader(this.StoringPath))
            {
                this.records = xmlSerializer.Deserialize(streamReader) as List<Player>;
            }
        }

        private void SortRecords()
        {
            this.records = this.sortStrategy.Sort(this.records);
        }
    }
}