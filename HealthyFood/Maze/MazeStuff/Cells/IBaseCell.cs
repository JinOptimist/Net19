using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public interface IBaseCell
    {
        CellType CellType { get; }
        int X { get; set; }
        int Y { get; set; }
      
        bool TryToStep(ICharacter character);
    }
}