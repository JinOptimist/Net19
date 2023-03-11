using Maze.MazeStuff.Characters;


namespace Maze.MazeStuff.Cells
{
    public class HardTrap : BaseCell
    {
        public override CellType CellType => CellType.HardTrap;

        public override bool TryToStep(ICharacter character)
        {
            character.Hp= character.Hp-2;
            return false;
        }
    }
}
