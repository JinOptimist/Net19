

using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class GoldWall : BaseCell
    {
        public GoldWall(int x, int y, MazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.GoldWall;
        public override bool TryToStep(ICharacter character)
        {
            return true;
        }

    }
}
