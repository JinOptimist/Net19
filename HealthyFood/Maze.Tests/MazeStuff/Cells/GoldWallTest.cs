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
        private int MaxMoney = 3;
        [Test]
        //[TestCase(5,6,3,2)]
        public void TryToStep_CoinWall(int coinBefore, int coinafter)
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            var currentCash = 3;
            heroMock.SetupProperty(x => x.Coins);

            heroMock.Object.Coins = coinafter;
            var hardTrap = new HardTrap(1, 1, mazeMock.Object);
            Assert.AreEqual(coinBefore, heroMock.Object.Coins);

            ////Step 2 Action
            //hardTrap.TryToStep(heroMock.Object);

            ////Step 3 Assert
            //Assert.AreEqual(coinafter, heroMock.Object.Hp);
        }
        //[Test]
        //public void TryToPossiblestep_Goldwall()
        //{
        //    var mazeMock = new Mock<IMazeLevel>();
        //    var heroMock = new Mock<ICharacter>();
        //    var goldWall = new GoldWall(1, 1, mazeMock.Object);
        //    var isStepPosible = goldWall.TryToStep(heroMock.Object);
        //    Assert.AreEqual(false, isStepPosible, "puk");
        //}
    }
}

