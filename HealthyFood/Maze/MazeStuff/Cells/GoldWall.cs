

using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class GoldWall : BaseCell
    {
        public override CellType CellType => CellType.GoldWall;
        public override bool TryToStep(ICharacter character)
        {
            return true;
        }

    }
}
