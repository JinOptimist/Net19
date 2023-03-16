using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class RandomTeleportTest
    {
        [Test]
        public void TryToStep_CellIsStepable()
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            var randomTeleport = new RandomTeleport(1, 1, mazeMock.Object);

            //Step 2 Action
            var isStepPosible = randomTeleport.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(false, isStepPosible, "Random teleport must be unstepable");
        }

        [Test]
        [TestCase(5, 7)]
        public void TryToStep_HeroCoordinationsChanges(int XBeforeTeleport, int YBeforeTeleport)
        {
            //Step 1 Prepare
            //var mazeMock = new Mock<IMazeLevel>();
            //mazeMock.SetupProperty(x => x.Cells);
            var mazeBuilderMock = new MazeBuilder();
            var maze = mazeBuilderMock.Build(10,5);

            var heroMock = new Mock<ICharacter>();

            heroMock.SetupProperty(x => x.X);
            heroMock.SetupProperty(x => x.Y);

            heroMock.Object.X = XBeforeTeleport;
            heroMock.Object.Y = YBeforeTeleport;

            var randomTeleport = new RandomTeleport(1, 1, maze);

            //Step 2 Action
            randomTeleport.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.IsTrue(XBeforeTeleport != heroMock.Object.X || YBeforeTeleport != heroMock.Object.Y);
        }

        //[Test]
        //public void TryToStep_HeroGoToGround()
        //{
        //    var mazeBuilderMock = new MazeBuilder();
        //    var maze = mazeBuilderMock.Build(10, 5);
        //    //var mazeMock = new Mock<IMazeLevel>();
        //    var heroMock = new Mock<ICharacter>();

        //    var randomTeleport = new RandomTeleport(1, 1, maze);

        //    //Step 2 Action
        //    randomTeleport.TryToStep(heroMock.Object);


        //    //Step 3 Assert
        //    Assert.
        //}
    }
}
