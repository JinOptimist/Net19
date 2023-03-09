using Maze.MazeStuff.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.MazeStuff.Cells
{
    public class Guardian : BaseCell
    {
        public override CellType CellType => CellType.Guardian;

        public override bool TryToStep(ICharacter character)
        {
            if(character.Hp >= 0 && character.Coins > 0)
            {
                character.Coins--;
                return true;
            }
            if(character.Coins == 0 && character.Hp > 0)
            {
                character.Hp--;
                return false;
            }
            else return false;
        }
    }
}
