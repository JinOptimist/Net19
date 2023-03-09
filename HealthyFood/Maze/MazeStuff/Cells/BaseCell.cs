using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public abstract class BaseCell : IBaseCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract CellType CellType { get; }

        public abstract bool TryToStep(ICharacter character);
    }
}
