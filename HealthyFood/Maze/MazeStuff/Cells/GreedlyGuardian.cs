using Maze.MazeStuff.Characters;
using Maze.MazeStuff.Enemies;

namespace Maze.MazeStuff.Cells
{
    public class GreedlyGuardian : BaseCell
    {
        public GreedlyGuardian(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.GreedlyGuardian;

        public override bool TryToStep(ICharacter character)
        {
            if (character.Coins > 0)
            {
                character.Coins--;
                return true;
            }
            if (character.Coins == 0 && character.Hp > 0)
            {
                character.Hp--;
                return false;
            }
            else return false;
        }
    }
}
