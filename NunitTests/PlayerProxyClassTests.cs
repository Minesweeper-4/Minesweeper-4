using NUnit.Framework;
using Minesweeper.Data.Player;

namespace NunitTests
{
    [TestFixture]
    public class PlayerProxyClassTests
    {
        [Test]
        public void PlayerProxyConstructorAndPropertriesGetterAndSetterWorksProper()
        {
            string expectedNickName = "Pesho";
            int expectedScore = 15;

            PlayerProxy proxy = new PlayerProxy(expectedNickName, expectedScore);

            Assert.AreEqual(expectedNickName, proxy.Nickname, "Expected and actual PlayerProxy Nickname are not equal");
            Assert.AreEqual(expectedScore, proxy.Score, "Expected and actual PlayerProxy Score are not equal");
        }
    }
}