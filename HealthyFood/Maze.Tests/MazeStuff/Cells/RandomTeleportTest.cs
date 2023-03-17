using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class RandomTeleportTest
    {
        private Mock<ICharacter> _heroMock;
        private Mock<IMazeLevel> _mazeMock;

        [SetUp]
        public void SetUpTest()
        {
            _heroMock = new Mock<ICharacter>();
            _mazeMock = new Mock<IMazeLevel>();
        }

        [Test]
        public void TryToStep_CellIsStepable()
        {
            //Step 1 Prepare
            var cells = new List<BaseCell>();
            var wall = new Wall(3, 6, _mazeMock.Object);
            var ground = new Ground(2, 5, _mazeMock.Object);
            cells.Add(wall);
            cells.Add(ground);

            _mazeMock.Setup(x => x.Cells).Returns(cells);
            var randomTeleport = new RandomTeleport(1, 3, _mazeMock.Object);

            //Step 2 Action
            var isStepPosible = randomTeleport.TryToStep(_heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(false, isStepPosible, "Random teleport must be unstepable");
        }

        [Test]
        [TestCase(5, 7)] 
        [TestCase(2, 5)] /*Negative case: the coordinates of the hero match the coordinates of the only cell of the ground*/
        public void TryToStep_HeroCoordinationsChanges(int XBeforeTeleport, int YBeforeTeleport)
        {
            //Step 1 Prepare
            _heroMock.SetupProperty(x => x.X);
            _heroMock.SetupProperty(x => x.Y);

            _heroMock.Object.X = XBeforeTeleport;
            _heroMock.Object.Y = YBeforeTeleport;

            var cells = new List<BaseCell>();
            var wall = new Wall(3, 6, _mazeMock.Object);
            var ground = new Ground(2, 5, _mazeMock.Object);
            cells.Add(wall);
            cells.Add(ground);

            _mazeMock.Setup(x => x.Cells).Returns(cells);

            var randomTeleport = new RandomTeleport(1, 8, _mazeMock.Object);

            //Step 2 Action
            var isCoordinatesChanges = randomTeleport.TryToStep(_heroMock.Object);

            //Step 3 Assert
            Assert.IsTrue(XBeforeTeleport != _heroMock.Object.X || YBeforeTeleport != _heroMock.Object.Y);
        }

        [Test]
        [TestCase(2, 6)]
        [TestCase(3, 5)]
        [TestCase(2, 5)] /*Negative case: the coordinates of the hero match the coordinates of the only cell of the ground*/
        public void TryToStep_HeroGoToGround(int XBeforeTeleport, int YBeforeTeleport)
        {
            //Step 1 Prepare
            _heroMock.SetupProperty(x => x.X);
            _heroMock.SetupProperty(x => x.Y);

            _heroMock.Object.X = XBeforeTeleport;
            _heroMock.Object.Y = YBeforeTeleport;

            var cells = new List<BaseCell>();
            var wall = new Wall(3, 6, _mazeMock.Object);
            var ground = new Ground(2, 5, _mazeMock.Object);
            cells.Add(wall);
            cells.Add(ground);

            _mazeMock.Setup(x => x.Cells).Returns(cells);

            var randomTeleport = new RandomTeleport(1, 8, _mazeMock.Object);

            //Step 2 Action
            randomTeleport.TryToStep(_heroMock.Object);

            //Step 3 Assert
            Assert.IsTrue((_heroMock.Object.X != XBeforeTeleport || _heroMock.Object.Y != YBeforeTeleport) 
                && (_heroMock.Object.X == ground.X || _heroMock.Object.Y == ground.Y));
        }

        [Test]
        [TestCase(2, 6)]
        [TestCase(3, 5)]
        public void TryToStep_HeroDoNotGoToWall(int XBeforeTeleport, int YBeforeTeleport)
        {
            //Step 1 Prepare
            _heroMock.SetupProperty(x => x.X);
            _heroMock.SetupProperty(x => x.Y);

            _heroMock.Object.X = XBeforeTeleport;
            _heroMock.Object.Y = YBeforeTeleport;

            var cells = new List<BaseCell>();
            var wall = new Wall(3, 6, _mazeMock.Object);
            var ground = new Ground(2, 5, _mazeMock.Object);
            cells.Add(wall);
            cells.Add(ground);

            _mazeMock.Setup(x => x.Cells).Returns(cells);

            var randomTeleport = new RandomTeleport(1, 8, _mazeMock.Object);

            //Step 2 Action
            randomTeleport.TryToStep(_heroMock.Object);

            //Step 3 Assert
            Assert.IsTrue((_heroMock.Object.X != wall.X || _heroMock.Object.Y != wall.Y));
        }
    }
}
