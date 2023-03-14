using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff.Enemies;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Enemies
{
    public class GoblinTest
    {
        [Test]
        [TestCase(10, 9)]
        [TestCase(1, 0)]
        public void TryToStepTestChange(int hp, int hpAfterOneMove)
        {
            var mazeMock = new Mock<IMazeLevel>();
            mazeMock.Setup(x => x.Enemies).Returns(new List<BaseEnemy>());
            var heroMock = new Mock<ICharacter>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = 9;
            var goblin = new Goblin(hp, 1, 1, mazeMock.Object);
            goblin.TryToStep(heroMock.Object);
            Assert.AreEqual(hpAfterOneMove, goblin.Hp);
        }

    }
}
