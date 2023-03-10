
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff
{
    public class MazeLevel
    {
        public int Widht { get; set; }
        public int Height { get; set; }

        public ICharacter Hero { get; set; }
        public ICharacter GreedyHealer { get; set; }

        public List<BaseCell> Cells { get; set; } = new List<BaseCell>();

        public void ReplaceToGround(BaseCell currentCell)
        {
            Cells.Remove(currentCell);
            var ground = new Ground(currentCell.X, currentCell.Y, this);
            Cells.Add(ground);
        }

        //public void ReplaceToGreedyHealer(BaseCell currentCell)
        //{
        //    Cells.Remove(currentCell);
        //    var greedyHealer = new GreedyHealer(currentCell.X, currentCell.Y, this);
        //    Cells.Add(greedyHealer);
        //}

        public void ReplaceCell(BaseCell newCell)
        {
            var oldCell = Cells.Single(oldCell => oldCell.X == newCell.X && oldCell.Y == newCell.Y);
            Cells.Remove(oldCell);
            Cells.Add(newCell);
        }
    }
}
