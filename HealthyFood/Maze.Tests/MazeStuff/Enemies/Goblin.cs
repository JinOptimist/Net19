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
        private Mock<IMazeLevel> _mazeMock;
        private Mock<ICharacter> _heroMock;
        //private Goblin _goblin;
        private int hp = 0;

        [SetUp]
        public void InIt()
        {

            _mazeMock = new Mock<IMazeLevel>();
            _heroMock = new Mock<ICharacter>();
            //_goblin = new Goblin(hp, 1, 1, _mazeMock.Object);
        }

        [Test]
        [TestCase(10, 9)]
        [TestCase(1, 0)]
        public void TryToStepHpGoblinChange(int hp, int hpAfterOneMove)
        {

            _mazeMock.Setup(x => x.Enemies).Returns(new List<BaseEnemy>());
            _heroMock.SetupProperty(x => x.Hp);
            _heroMock.Object.Hp = 9;
            var goblin = new Goblin(hp, 1, 1, _mazeMock.Object);
            goblin.TryToStep(_heroMock.Object);
            Assert.AreEqual(hpAfterOneMove, goblin.Hp);
        }

        [Test]
        [TestCase(10, 0)]
        [TestCase(1, 1)]
        [TestCase(-1, 1)]
        public void TryToStepExpHero(int hp, int expOfHero)
        {
            _mazeMock.Setup(x => x.Enemies).Returns(new List<BaseEnemy>());
            _heroMock.SetupProperty(x => x.Experience);
            _heroMock.Object.Experience = 0;
            var goblin = new Goblin(hp, 1, 1, _mazeMock.Object);
            goblin.TryToStep(_heroMock.Object);
            Assert.AreEqual(expOfHero, _heroMock.Object.Experience);
        }

    }
}
