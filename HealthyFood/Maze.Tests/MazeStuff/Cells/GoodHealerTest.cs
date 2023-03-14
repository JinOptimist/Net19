using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class GoodHealerTest
    {
        private Mock<IMazeLevel> _mazeMock;
        private Mock<ICharacter> _heroMock;

        [SetUp]
        public void SetupTest()
        {
            _mazeMock= new Mock<IMazeLevel>();
            _heroMock= new Mock<ICharacter>();
        }

        [Test]
        public void TryToStep_CellIsStepable()
        {
            var goodHealer = new GoodHealer(1, 1, _mazeMock.Object);

            var isStepPosible = goodHealer.TryToStep(_heroMock.Object);

            Assert.AreEqual(true, isStepPosible, "Good Healer must be stepable");
        }


        [Test]
        [TestCase(10, 11)]
        [TestCase(5, 6)]
        [TestCase(4, 5)]
        public void TryToStep_HeroHpChanges(int hpBeforeTrap, int hpAfterTrap)
        {
            _heroMock.SetupProperty(x => x.Hp);

            _heroMock.Object.Hp = hpBeforeTrap;

            var goodHealer = new GoodHealer(1, 1, _mazeMock.Object);

            goodHealer.TryToStep(_heroMock.Object);

            Assert.AreEqual(hpAfterTrap, _heroMock.Object.Hp);
        }

        [Test]
        public void TryToStep_CellReplaceToGround()
        {
            var goodHealer = new GoodHealer(1, 1, _mazeMock.Object);

            goodHealer.TryToStep(_heroMock.Object);

            _mazeMock.Verify(x => x.ReplaceToGround(goodHealer), Times.Once());
        }
    }
}
