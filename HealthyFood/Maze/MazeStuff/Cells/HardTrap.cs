using Maze.MazeStuff.Characters;


namespace Maze.MazeStuff.Cells
{
    internal class HardTrap : BaseCell
    {
        public override CellType CellType => CellType.HardTrap;

       

        public override bool TryToStep(ICharacter character)
        {
            return true;
        }
    }
}
