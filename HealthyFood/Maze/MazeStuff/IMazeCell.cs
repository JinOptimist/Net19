using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff
{
    public interface IMazeCell
    {
        CellType CellType { get; }
        int X { get; set; }
        int Y { get; set; }

        bool TryToStep(ICharacter character);
    }
}