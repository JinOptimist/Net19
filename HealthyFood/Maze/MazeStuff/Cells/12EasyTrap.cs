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
        private BaseCell randomEasyTrap;

        public EasyTrap(BaseCell randomEasyTrap)
        {
            this.randomEasyTrap = randomEasyTrap;
        }

        public override CellType CellType => CellType.EasyTrap;

        public override bool TryToStep(ICharacter Hero)
        {
            Hero.Hp--;
            return true;
        }
    }
}

