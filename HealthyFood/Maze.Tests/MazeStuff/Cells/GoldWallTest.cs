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
        [Test]
        public void TryToStep_CoinWall(int coinBedore, int coinafter)
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            heroMock.SetupProperty(x => x.Coins);

            heroMock.Object.Coins = coinBedore;

            var hardTrap = new HardTrap(1, 1, mazeMock.Object);

            //Step 2 Action
            hardTrap.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(coinafter, heroMock.Object.Hp);
        }
    }
}

