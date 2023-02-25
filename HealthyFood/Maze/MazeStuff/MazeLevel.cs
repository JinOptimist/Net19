
namespace Maze.MazeStuff
{
    public class MazeLevel
    {
        public int Widht { get; set; }
        public int Height { get; set; }

        public List<MazeCell> Cells { get; set; } = new List<MazeCell>();
    }
}
