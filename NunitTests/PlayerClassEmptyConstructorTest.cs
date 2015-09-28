using Minesweeper.Data.Player;
using NUnit.Framework;
namespace NunitTests
{
    [TestFixture]
    public class PlayerClassEmptyConstructorTest
    {
        [Test]
        public void PlayerClassEmptyConstructorMustConstructInstance()
        {
            Player player = new Player();

            Assert.IsInstanceOfType(typeof(Player), player, "Memento instance doesn't exist");
        }
    }
}