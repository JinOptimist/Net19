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
        [TestCase(10, 9, 0)]
        [TestCase(1, 0, 1)]
        [TestCase(-1, -2, 1)]
        public void TryToStepHpGoblinHpChangeAndHeroExpChange(int hp, int hpAfterOneMove, int expOfHero)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            mazeMock.Setup(x => x.Enemies).Returns(new List<BaseEnemy>());
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = 9;
            heroMock.SetupProperty(x => x.Experience);
            heroMock.Object.Experience = 0;
            var goblin = new Goblin(hp, 1, 1, mazeMock.Object);
            goblin.TryToStep(heroMock.Object);
            Assert.AreEqual(hpAfterOneMove, goblin.Hp);
            Assert.AreEqual(expOfHero, heroMock.Object.Experience);
        }
    }
}
