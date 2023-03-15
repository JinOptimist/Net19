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
        [TestCase(10,11,5,4)]
        [TestCase(5, 6, 4, 3)]
        public void TryToStep_GreedyHealerTest(int hpAfter, int hpBefore, int coinsAfter, int coinsBefore)
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            heroMock.SetupProperty(x => x.Hp);
            heroMock.SetupProperty(x => x.Coins);
            heroMock.Object.Hp = hpAfter;
            heroMock.Object.Coins = coinsAfter;
            var greedyHealer = new GreedyHealer(1, 1, mazeMock.Object);
            var isStepPosible = greedyHealer.TryToStep(heroMock.Object);
            Assert.AreEqual(hpBefore, heroMock.Object.Hp);
            Assert.AreEqual(coinsBefore, heroMock.Object.Coins);
        }
        [Test]
        public void TryToPossibleStep_GreedyHealerTest()
        {
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();
            var greedyHealerRich = new GreedyHealer(1, 1, mazeMock.Object);
            var greedyHealer = new GreedyHealer(2, 3, mazeMock.Object);
            heroMock.SetupProperty(x => x.Hp);
            heroMock.SetupProperty(x => x.Coins);
            greedyHealerRich.Coins = -5;
            greedyHealer.Coins = -1;
            var isStepPosibleRich = greedyHealerRich.TryToStep(heroMock.Object);
            var isStepPosible = greedyHealer.TryToStep(heroMock.Object);
            Assert.AreEqual(false, isStepPosibleRich, "You're have money");
            Assert.AreEqual(false, isStepPosible, "You're not have money");
        }
    }
}
