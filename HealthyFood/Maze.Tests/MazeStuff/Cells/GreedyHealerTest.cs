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
        private Mock<IMazeLevel> _mazeMock;
        private Mock<ICharacter> _heroMock;
        [SetUp]
        public void In()
        {
            _mazeMock = new Mock<IMazeLevel>();
            _heroMock = new Mock<ICharacter>();

        }
        [Test]
        [TestCase(10,11,5,4)]
        [TestCase(5, 6, 4, 3)]
        public void TryToStep_AddHpLoseCoins(int hpAfter, int hpBefore, int coinsAfter, int coinsBefore)
        {
            _heroMock.SetupProperty(x => x.Hp);
            _heroMock.SetupProperty(x => x.Coins);
            _heroMock.Object.Hp = hpAfter;
            _heroMock.Object.Coins = coinsAfter;
            var greedyHealer = new GreedyHealer(1, 1, _mazeMock.Object);
            Assert.AreEqual(hpBefore, _heroMock.Object.Hp);
            Assert.AreEqual(coinsBefore, _heroMock.Object.Coins);
        }
        [Test]
        public void TryToStep_PosibleStep()
        {
            var greedyHealer = new GreedyHealer(1, 1, _mazeMock.Object);
            var isStepPosible = greedyHealer.TryToStep(_heroMock.Object);
            Assert.AreEqual(false, isStepPosible, "You're not have money");
        }
    }
}
