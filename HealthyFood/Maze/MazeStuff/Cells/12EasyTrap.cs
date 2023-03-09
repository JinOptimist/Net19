using Maze.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeStuff.Cells
{
    public class EasyTrap : BaseCell
    {
        
        public override CellType CellType => CellType.EasyTrap;

        public override bool TryToStep(ICharacter Hero)
        {
            Hero.Hp--;
            return true;
        }
    }
}

