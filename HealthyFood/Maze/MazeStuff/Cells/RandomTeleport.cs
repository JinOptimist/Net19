using System;
using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class RandomTeleport : BaseCell
    {
        public override CellType CellType => CellType.RandomTelepot;

        public override bool TryToStep(ICharacter character)
        {
            var hero = new Hero();
            var ground = CellType.Ground;
            Random random = new Random();
            hero.X = random.Next();
            hero.Y = random.Next();
            return true;
        }
    }
}

