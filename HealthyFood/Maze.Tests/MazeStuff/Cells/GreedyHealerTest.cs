using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Maze.Tests.MazeStuff.Cells
{
    public class GreedyHealerTest
    {
        [Test]
        public void TryToStep_GreedyHealerTest()
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.SetupProperty(x => x.Coins);

            heroMock.Object.Hp = 5;
            heroMock.Object.Coins = 4;
            var greedyHealer = new GreedyHealer(1, 1, mazeMock.Object);

            //Step 2 Action
            var isStepPosible = greedyHealer.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(6, heroMock.Object.Hp);
            Assert.AreEqual(3, heroMock.Object.Coins);
        }

        [Test]
        [TestCase(10,11,5,4)]
        public void TryToStep_GreedyHealerTest(int hpAfter, int hpBefore, int coinsAfter, int coinsBefore)
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.SetupProperty(x => x.Coins);

            heroMock.Object.Hp = hpAfter;
            heroMock.Object.Coins = coinsAfter;
            var greedyHealer = new GreedyHealer(1, 1, mazeMock.Object);

            //Step 2 Action
            var isStepPosible = greedyHealer.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(hpBefore, heroMock.Object.Hp);
            Assert.AreEqual(coinsBefore, heroMock.Object.Coins);
        }
    }
}
