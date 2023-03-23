using System;
using Maze.MazeStuff.Characters;
using static System.Net.Mime.MediaTypeNames;

namespace Maze.MazeStuff.Cells
{
    public class RandomTeleport : BaseCell
    {

        private Random _random = new Random();
        public RandomTeleport(int x, int y, IMazeLevel maze) : base(x,y, maze)
        {

        }

        public override CellType CellType => CellType.RandomTelepot;

        public override bool TryToStep(ICharacter character)
        {
            var allGround = Level.Cells.Where(x => x.CellType == CellType.Ground).ToList();
            var randomIndexGround = _random.Next(allGround.Count);
            var randomGround = allGround[randomIndexGround];
            character.X = randomGround.X;
            character.Y = randomGround.Y;

            return false;
        }
    }
}

