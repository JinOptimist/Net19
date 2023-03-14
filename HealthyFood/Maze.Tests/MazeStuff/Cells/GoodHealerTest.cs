using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    internal class GoodHealerTest
    {
        [Test]
        public void TryToStep_CellIsStepable()
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            var goodHealer = new GoodHealer(1, 1, mazeMock.Object);

            var isStepPosible = goodHealer.TryToStep(heroMock.Object);

            Assert.AreEqual(true, isStepPosible, "Hard trap must be stepable");
        }


        [Test]
        [TestCase(10, 11)]
        [TestCase(5, 6)]
        [TestCase(4, 5)]
        public void TryToStep_HeroHpChanges(int hpBeforeTrap, int hpAfterTrap)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            heroMock.SetupProperty(x => x.Hp);

            heroMock.Object.Hp = hpBeforeTrap;

            var goodHealer = new GoodHealer(1, 1, mazeMock.Object);

            goodHealer.TryToStep(heroMock.Object);

            Assert.AreEqual(hpAfterTrap, heroMock.Object.Hp);
        }

        [Test]
        public void TryToStep_CellReplaceToGround()
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            var goodHealer = new PileOfCoins(1, 1, mazeMock.Object);

            goodHealer.TryToStep(heroMock.Object);

            mazeMock.Verify(x => x.ReplaceToGround(goodHealer), Times.Once());
        }
    }
}
