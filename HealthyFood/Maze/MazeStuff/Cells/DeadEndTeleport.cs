using Maze.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeStuff.Cells
{
    public class DeadEndTeleport : BaseCell
    {
        public DeadEndTeleport(int x, int y, MazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.DeadEndTeleport;

        public override bool TryToStep(ICharacter character)
        {
            if (X == 0 && Y == 0)
            {
                character.X = Level.Widht - 1;
                character.Y = Level.Height - 1;

                return false;
            }
            else if (X == Level.Widht - 1 && Y == Level.Height - 1)
            {
                character.X = 0;
                character.Y = 0;

                return false;
            }

            return true;
        }
    }
}
