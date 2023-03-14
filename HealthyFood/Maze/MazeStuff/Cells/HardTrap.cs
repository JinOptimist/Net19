using Maze.MazeStuff.Characters;


namespace Maze.MazeStuff.Cells
{
    public class HardTrap : BaseCell
    {
        public HardTrap(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.HardTrap;

        public override bool TryToStep(ICharacter character)
        {
            if (character.Hp > 0)
            {
                character.Hp -= 2;
            }
            return true;
        }
    }
}
