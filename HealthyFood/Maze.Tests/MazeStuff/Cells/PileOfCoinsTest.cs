using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class PileOfCoinsTest
    {
        [Test]
        public void TryToStep_CellReplaceToGround()
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            var pileOfCoins = new PileOfCoins(1, 1, mazeMock.Object);

            //Step 2 Action
            pileOfCoins.TryToStep(heroMock.Object);

            //Step 3 Assert
            mazeMock.Verify(x => x.ReplaceToGround(pileOfCoins), Times.Once());
            //mazeMock.Verify(x => x.ReplaceToGround(It.IsAny<BaseCell>()), Times.Once());
        }
    }
}
