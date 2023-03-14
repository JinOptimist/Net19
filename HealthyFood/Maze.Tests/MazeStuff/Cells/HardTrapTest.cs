using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class HardTrapTest
    {
        [Test]
        public void TryToStep_CellIsStepable()
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            var hardTrap = new HardTrap(1, 1, mazeMock.Object);

            //Step 2 Action
            var isStepPosible = hardTrap.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(true, isStepPosible, "Hard trap must be stepable");
        }


        [Test]
        [TestCase(10, 8)]
        [TestCase(5, 3)]
        [TestCase(-2, -2)]
        public void TryToStep_HeroHpChanges(int hpBeforeTrap, int hpAfterTrap)
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            
            heroMock.SetupProperty(x => x.Hp);

            heroMock.Object.Hp = hpBeforeTrap;

            var hardTrap = new HardTrap(1, 1, mazeMock.Object);

            //Step 2 Action
            hardTrap.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(hpAfterTrap, heroMock.Object.Hp);
        }
    }
}
