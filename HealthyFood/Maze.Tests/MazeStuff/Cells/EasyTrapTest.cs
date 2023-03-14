using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class EasyTrapTest
    {
        [Test]
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        public void TryToStep_HeroHpChanges(int hpBeforeTrap, int hpAfterTrap)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            heroMock.SetupProperty(x => x.Hp);

            heroMock.Object.Hp = hpBeforeTrap;

            var easyTrap = new EasyTrap(1, 1, mazeMock.Object);

            easyTrap.TryToStep(heroMock.Object);

            Assert.AreEqual(hpAfterTrap, heroMock.Object.Hp);
        }

        [Test]
        [TestCase(-2, false)]
        [TestCase(72, true)]
        public void TryToStep_CellIsStepable(int hp, bool tryingToStep)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            heroMock.SetupProperty(x => x.Hp);

            heroMock.Object.Hp = hp;

            var easyTrap = new EasyTrap(1, 1, mazeMock.Object);

            var isStepPosible = easyTrap.TryToStep(heroMock.Object);

            Assert.AreEqual(tryingToStep, isStepPosible, "Easy trap must be stepable");
        }

        [Test]
        public void TryToStep_CellReplaceToGround()
        {
        
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            var easyTrap = new EasyTrap(1, 1, mazeMock.Object);
            heroMock.SetupProperty(x => x.Hp);

            heroMock.Object.Hp = 10;

            easyTrap.TryToStep(heroMock.Object);

            mazeMock.Verify(x => x.ReplaceToGround(easyTrap), Times.Once());
        }
    }
}
