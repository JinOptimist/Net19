
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff
{
    public class MazeLevel
    {
        public int Widht { get; set; }
        public int Height { get; set; }

        public ICharacter Hero { get; set; }
        public List<MazeCell> Cells { get; set; } = new List<MazeCell>();

        public void ReplaceToGround(MazeCell oldCell)
        {
            var ground = new Ground()
            {
                X = oldCell.X,
                Y = oldCell.Y
            };
            ReplaceCell(ground);
        }

        public void ReplaceCell(MazeCell newCell)
        {
            var oldCell = Cells.Single(cell => cell.X == newCell.X && cell.Y == newCell.Y);
            Cells.Remove(oldCell);
            Cells.Add(newCell);
        }
    }
}
