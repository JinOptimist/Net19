using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class EasyTrapTest
    {
        private Mock<IMazeLevel> _mazeMock;
        private Mock<ICharacter> _heroMock;

        [SetUp]
        public void SetupTest()
        {
            _mazeMock = new Mock<IMazeLevel>();
            _heroMock = new Mock<ICharacter>();
        }


        [Test]
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        public void TryToStep_HeroHpChanges(int hpBeforeTrap, int hpAfterTrap)
        {
            _heroMock.SetupProperty(x => x.Hp);

            _heroMock.Object.Hp = hpBeforeTrap;

            var easyTrap = new EasyTrap(1, 1, _mazeMock.Object);

            easyTrap.TryToStep(_heroMock.Object);

            Assert.AreEqual(hpAfterTrap, _heroMock.Object.Hp);
        }

        [Test]
        [TestCase(-2, false)]
        [TestCase(72, true)]
        public void TryToStep_CellIsStepable(int hp, bool tryingToStep)
        {
            _heroMock.SetupProperty(x => x.Hp);

            _heroMock.Object.Hp = hp;

            var easyTrap = new EasyTrap(1, 1, _mazeMock.Object);

            var isStepPosible = easyTrap.TryToStep(_heroMock.Object);

            Assert.AreEqual(tryingToStep, isStepPosible, "Easy trap must be stepable");
        }

        [Test]
        public void TryToStep_CellReplaceToGround()
        {

            var easyTrap = new EasyTrap(1, 1, _mazeMock.Object);
            _heroMock.SetupProperty(x => x.Hp);

            _heroMock.Object.Hp = 10;

            easyTrap.TryToStep(_heroMock.Object);

            _mazeMock.Verify(x => x.ReplaceToGround(easyTrap), Times.Once());
        }
    }
}
