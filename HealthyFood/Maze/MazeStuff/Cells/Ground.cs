using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Ground : BaseCell
    {
        public Ground(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.Ground;

        public override bool TryToStep(ICharacter character)
        {
            return true;
        }
    }
}
