using Minesweeper.Helpers;
using NUnit.Framework;
using System;
using System.IO;

namespace NunitTests
{
    [TestFixture]
    public class SerializerTests
    {
        [Test]
        public void ExpectSerializeMethodToCreateFileIfTheFileDoesntExist()
        {
            var fileName = "testFile.txt";
            var testObjectToSerialize = new Object();
            var serializer = new Serializer();

            serializer.Serialize(testObjectToSerialize, fileName);

            Assert.True(File.Exists(fileName));
            File.Delete(fileName);
        }

        [Test]
        public void ExpectDeserializeMethodToReturnObjectWhenFileExist()
        {
            var fileName = "testFile.txt";
            var testObjectToSerialize = new Object();
            var serializer = new Serializer();

            serializer.Serialize(testObjectToSerialize, fileName);

            var deserializedObject = serializer.Deserialize(fileName);

            Assert.NotNull(deserializedObject);

            File.Delete(fileName);
        }
    }
}
