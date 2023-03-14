using Maze.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeStuff.Cells
{
    public class GoodHealer : BaseCell
    {
        public GoodHealer(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.GoodHealer;

        public override bool TryToStep(ICharacter character)
        {
            character.Hp++;
            Level.ReplaceToGround(this);
            return true;
        }
    }
}
