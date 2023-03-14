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

namespace Maze
{
    public class WallTest
    {
        [Test]

        public void TryToStep_CellIsUnstepable()
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            var Wall = new Wall(1, 1, mazeMock.Object);

            //Step 2 Action
            var isSteImposible = Wall.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(false, isSteImposible, "Wall must be unstepable");
        }


        [Test]
        [TestCase(10, 9)]
        [TestCase(5, 4)]
        public void TryToStep_HeroHpChanges(int hpBeforeWall, int hpAfterWall)
        {
            //Step 1 Prepare
            var mazeMock = new Mock<IMazeLevel>();
            var heroMock = new Mock<ICharacter>();

            heroMock.SetupProperty(x => x.Hp);

            heroMock.Object.Hp = hpBeforeWall;

            var Wall = new Wall(1, 1, mazeMock.Object);

            //Step 2 Action
            Wall.TryToStep(heroMock.Object);

            //Step 3 Assert
            Assert.AreEqual(hpAfterWall, heroMock.Object.Hp);
        }
    }
}
