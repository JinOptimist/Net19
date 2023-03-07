using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Ground : MazeCell
    {
        public override CellType CellType => CellType.Ground;

        public override bool TryToStep(ICharacter character)
        {
            return true;
        }
    }
}
