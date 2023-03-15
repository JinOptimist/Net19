using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Tests.MazeStuff.Cells
{
    public class Greedy_Guardian_Test
    {
        private Mock<IMazeLevel> _mazeMock;
        private Mock<ICharacter> _heroMock;

        [SetUp]
        public void SetupTest()
        {
            _mazeMock = new Mock<IMazeLevel>();
            _heroMock = new Mock<ICharacter>();
        }

        [Test]
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        [TestCase(0, 0)]
        [TestCase(-1, 0)]
        public void TryToStep_HeroCoinsChanges(int coinsBeforeChanges, int coinsAfterChanges)
        {
            //Step 1 Prepare
            _heroMock.SetupProperty(x => x.Coins);

            _heroMock.Object.Coins = coinsBeforeChanges;

            var hardTrap = new GreedlyGuardian(1, 1, _mazeMock.Object);

            //Step 2 Action
            hardTrap.TryToStep(_heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(coinsAfterChanges, _heroMock.Object.Coins);
        }

        [Test]
        [TestCase(0, 9, 10, 9)]
        [TestCase(0, 7, 8, 7)]
        [TestCase(-5, -9, -10, -9)]
        [TestCase(0, 0, -1, 0)]
        public void TryToStep_CanTheHeroStepOnGreedlyGuardian(int coinsBeforeChanges, int coinsAfterChanges, int HpBeforeChanges, int HpAfterChanges)
        {
            //Step 1 Prepare
            _heroMock.SetupProperty(x => x.Coins);
            _heroMock.SetupProperty(x => x.Hp);

            _heroMock.Object.Coins = coinsBeforeChanges;
            _heroMock.Object.Hp = HpBeforeChanges;

            var hardTrap = new GreedlyGuardian(1, 1, _mazeMock.Object);

            //Step 2 Action
            hardTrap.TryToStep(_heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(coinsAfterChanges, _heroMock.Object.Hp);
            Assert.AreEqual(HpAfterChanges, _heroMock.Object.Hp);
        }
    }
}
