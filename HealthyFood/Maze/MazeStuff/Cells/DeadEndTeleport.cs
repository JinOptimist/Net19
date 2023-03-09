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
        public override CellType CellType => CellType.DeadEndTeleport;

        public override bool TryToStep(ICharacter character)
        {
            return true;
        }
    }
}
