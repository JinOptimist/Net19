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
        [TestCase(1,2)]
        [TestCase(5,6)]
        public void TryToStep_GoldWall(int coinsBefore, int coinsafter)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
           
            heroMock.SetupProperty(x => x.Coins);
            heroMock.Object.Coins = coinsBefore;
            var goldmin = new GoldWall(1, 1, mazeMock.Object);

            goldmin.TryToStep(heroMock.Object);
           
            Assert.AreEqual(coinsafter, heroMock.Object.Coins);
        }
    }
}

