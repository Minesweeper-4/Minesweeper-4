namespace Minesweeper.Logic.Scores
{
    using Minesweeper.Data.Player;
    using Minesweeper.Helpers;
    using Minesweeper.Logic.Sorter;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;

    public class ScoresHandler : IScoresHandler
    {
        private List<Player> records;
        private string storingPath;
        private SortStrategy sortStrategy = new DefaultSort();
        private Serializer serializer = new Serializer();

        public ScoresHandler(string storingPath)
        {
            this.StoringPath = storingPath;
            this.records = new List<Player>();
        }

        public IList<Player> Reccords
        {
            get { return this.records; } // changed for making it testable. Was NotImplemented
        }

        public string StoringPath
        {
            get
            {
                return this.storingPath;
            }

            private set
            {
                Validator.ValidateNonEmptyString(value, "StoringPath");

                this.storingPath = value;
            }
        }

        public void AddReccord(Player player)
        {
            int lastRecordScore = 0;

            if (this.Reccords.Count != 0) // added to make the method testable
            {
                lastRecordScore = this.records.Last().Score;
            }            

            if (this.records.Count < 10 || player.Score > lastRecordScore)
            {
                this.records.Add(player);
            }

            SortRecords();
        }

        public void SaveToFile()
        {
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));

            //using (StreamWriter streamWriter = System.IO.File.CreateText(this.StoringPath))
            //{
            //    xmlSerializer.Serialize(streamWriter, this.records);
            //}

            this.serializer.Serialize(this.records, GlobalErrorMessages.SaveRecordstFileName);
        }

        public void LoadFromFile()
        {
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Player>));

            //using (StreamReader streamReader = new System.IO.StreamReader(this.StoringPath))
            //{
            //    this.records = xmlSerializer.Deserialize(streamReader) as List<Player>;
            //}

            var fileInfo = new FileInfo(GlobalErrorMessages.SaveRecordstFileName);

            if (fileInfo.Length == 0)
            {
                this.records = new List<Player>();
            }

            else
            {
                this.records = this.serializer.Deserialize(GlobalErrorMessages.SaveRecordstFileName) as List<Player>;
            }
        }

        private void SortRecords()
        {
            this.records = this.sortStrategy.Sort(this.records);
        }
    }
}