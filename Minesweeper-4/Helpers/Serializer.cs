namespace Minesweeper.Helpers
{
    using Minesweeper.Data;
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public class Serializer
    {
        public Serializer()
        {
        }

        public void Serialize(object memento, string fileName)
        {

            var writer = new FileStream(fileName, FileMode.Open);

            BinaryFormatter mySerializer = new BinaryFormatter();

            mySerializer.Serialize(writer, memento);
            writer.Position = 0;

            writer.Close();
        }

        public object Deserialize(string fileName)
        {
            var writer = new FileStream(fileName, FileMode.Open);

            BinaryFormatter mySerializer = new BinaryFormatter();

            var memento = mySerializer.Deserialize(writer);

            writer.Close();

            return memento;
        }
    }
}
