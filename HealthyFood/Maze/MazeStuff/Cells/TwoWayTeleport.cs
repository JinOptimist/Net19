using Maze.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeStuff.Cells
{
    public class TwoWayTeleport : BaseCell
    {
        BaseCell LinkCell;
        public TwoWayTeleport(int x, int y, MazeLevel level, BaseCell linkCell) : base(x, y, level)
        {
            LinkCell = linkCell;
        }

        public override CellType CellType => CellType.TwoWayTeleport;

        public override bool TryToStep(ICharacter character)
        {
            character.X = LinkCell.X; 
            character.Y = LinkCell.Y;

            return false;
        }
    }
}
