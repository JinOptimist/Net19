using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using Maze.MazeStuff.Enemies;

namespace Maze.MazeStuff
{
    public class MazeLevel : IMazeLevel
    {
        public int Widht { get; set; }
        public int Height { get; set; }

        public ICharacter Hero { get; set; }
        public ICharacter GreedyHealer { get; set; }

        public List<BaseCell> Cells { get; set; } = new List<BaseCell>();

        public List<BaseEnemy> Enemies { get; set; } = new List<BaseEnemy>();

        public void ReplaceToGround(BaseCell currentCell)
        {
            Cells.Remove(currentCell);
            var ground = new Ground(currentCell.X, currentCell.Y, this);
            Cells.Add(ground);
        }

        public void ReplaceCell(BaseCell newCell)
        {
            var oldCell = Cells.Single(oldCell => oldCell.X == newCell.X && oldCell.Y == newCell.Y);
            Cells.Remove(oldCell);
            Cells.Add(newCell);
        }

        public void ReplaceCellByType(BaseCell currentCell, CellType cellType, BaseCell linkCell = null)
        {
            BaseCell cell;
            Cells.Remove(currentCell);

            switch(cellType)
            {
                case CellType.Ground:
                    cell = new Ground(currentCell.X, currentCell.Y, this);
                    break;
                case CellType.TwoWayTeleport:
                    cell = new TwoWayTeleport(currentCell.X, currentCell.Y, this, linkCell);
                    break;
                case CellType.Wall:
                    cell = new Wall(currentCell.X, currentCell.Y, this);
                    break;
                default:
                    throw new Exception();
            }

            cell.X = currentCell.X;
            cell.Y = currentCell.Y;

            Cells.Add(cell);
        }
    }
}
