
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff
{
    public class MazeLevel
    {
        public int Widht { get; set; }
        public int Height { get; set; }

        public ICharacter Hero { get; set; }
        public IBaseCell RandomTeleport { get; set; }

        public List<BaseCell> Cells { get; set; } = new List<BaseCell>();

        public void ReplaceToGround(BaseCell currentCell)
        {
            Cells.Remove(currentCell);
            var ground = new Ground()
            {
                X = currentCell.X,
                Y = currentCell.Y,
            };
            Cells.Add(ground);
        }

        public void ReplaceCell(BaseCell newCell)
        {
            var oldCell = Cells.Single(oldCell => oldCell.X == newCell.X && oldCell.Y == newCell.Y);
            Cells.Remove(oldCell);
            Cells.Add(newCell);
        }
    }
}
