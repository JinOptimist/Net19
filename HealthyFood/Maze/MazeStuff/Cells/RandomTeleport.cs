using System;
using Maze.MazeStuff.Characters;
using static System.Net.Mime.MediaTypeNames;

namespace Maze.MazeStuff.Cells
{
    public class RandomTeleport : BaseCell
    {
        private MazeLevel maze;

        public RandomTeleport(int x, int y, MazeLevel maze) : base(x,y, maze)
        {

        }

        public override CellType CellType => CellType.RandomTelepot;

        public override bool TryToStep(ICharacter character)
        {
            var ground = new Ground(X, Y, maze);
            
            Random random = new Random();
            character.X = random.Next(ground.X);
            character.Y = random.Next(ground.Y);
            
            return false;
        }
    }
}

