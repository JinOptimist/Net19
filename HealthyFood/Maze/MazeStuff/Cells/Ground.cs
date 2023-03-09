using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Ground : BaseCell
    {
        public override CellType CellType => CellType.Ground;

        public override bool TryToStep(ICharacter character)
        {
            return true;
        }
    }
}
