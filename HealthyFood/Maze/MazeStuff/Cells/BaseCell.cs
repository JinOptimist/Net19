using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public abstract class BaseCell : IBaseCell
    {
        protected BaseCell(int x, int y, MazeLevel level)
        {
            X = x;
            Y = y;
            Level = level;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public MazeLevel Level { get; set; }

        public abstract CellType CellType { get; }
       
        public abstract bool TryToStep(ICharacter character);
    }
}
