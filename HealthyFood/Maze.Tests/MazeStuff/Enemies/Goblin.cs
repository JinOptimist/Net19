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
        [TestCase(10, 9, 0, 8)]
        [TestCase(1, 0, 1, 8)]
        [TestCase(-1, -2, 1, 8)]
        public void TryToStepHpGoblinHpChangeAndHeroExpChange(int hpGoblin, int hpGoblinAfterMove, int expOfHero, int hpHeroAfterOneMove)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            mazeMock.Setup(x => x.Enemies).Returns(new List<BaseEnemy>());
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = 9;
            heroMock.SetupProperty(x => x.Experience);
            heroMock.Object.Experience = 0;

            var goblin = new Goblin(hpGoblin, 1, 1, mazeMock.Object);
          
            goblin.TryToStep(heroMock.Object);
            Assert.AreEqual(hpGoblinAfterMove, goblin.Hp);           
            Assert.AreEqual(expOfHero, heroMock.Object.Experience);
            Assert.AreEqual(hpHeroAfterOneMove, heroMock.Object.Hp);

        }
    }
}
