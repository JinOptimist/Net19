using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff
{
    public abstract class MazeCell
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract CellType CellType { get; }

        public abstract bool TryToStep(ICharacter character);
    }
}
