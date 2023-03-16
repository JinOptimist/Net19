using System;
using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
	public class GoldWallTest
	{
        private int maxMoney;
        [Test]
        [TestCase(1,2,3,2,1)]
        public void TryToStep_CoinWall(int coinBefore, int coinafter, int currentMoney)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            maxMoney = currentMoney;
            heroMock.SetupProperty(x => x.Coins);
            heroMock.Object.Coins = coinafter;
            var replace = new Wall(1, 1, mazeMock.Object);
            var stepCellsWall = new GoldWall(1, 1, mazeMock.Object);
            
            Assert.AreEqual(replace, heroMock.Object.Coins);
        }
    }
}

