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


        private Mock<IMazeLevel> _maze;
        [SetUp]
        public void InPut()
        {
            _maze = new Mock<IMazeLevel>();
        }
        [Test]
        [TestCase(10, 9, 0, 8)]
        [TestCase(1, 0, 1, 8)]
        [TestCase(-1, -2, 1, 8)]
        public void TryToStepHpGoblinHpChangeAndHeroExpChange(int hpGoblin, int hpGoblinAfterMove, int expOfHero, int hpHeroAfterOneMove)
        {
            //var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            _maze.Setup(x => x.Enemies).Returns(new List<BaseEnemy>());
            heroMock.SetupProperty(x => x.Hp);
            heroMock.Object.Hp = 9;
            heroMock.SetupProperty(x => x.Experience);
            heroMock.Object.Experience = 0;

            var goblin = new Goblin(hpGoblin, 1, 1, _maze.Object);

            goblin.TryToStep(heroMock.Object);
            Assert.AreEqual(hpGoblinAfterMove, goblin.Hp);
            Assert.AreEqual(expOfHero, heroMock.Object.Experience);
            Assert.AreEqual(hpHeroAfterOneMove, heroMock.Object.Hp);

        }

        //[Test]
        //[TestCase(2, 2)]
        //[TestCase(4, 7)]
        //public void EndTurnActivityTest(int x, int y)
        //{
        //    _maze.Setup(x => x.Cells).Returns(new List<BaseCell>());

        //    var goblin = new Goblin(1, 1, 1, _maze.Object);
            
           
        //    goblin.EndTurnActivity();
        //    Assert.AreNotEqual(x, goblin.X);
        //    Assert.AreNotEqual(y, goblin.Y);
        //}
    }
}

