using Maze.MazeStuff;

namespace Maze
{
    public class MazeDrawer
    {
        public void Draw(MazeLevel maze)
        {
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Widht; x++)
                {
                    var cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);
                    Console.Write(GetCellSymbol(cell.CellType));
                }
                Console.WriteLine();
            }
        }

        private string GetCellSymbol(CellType cellType)
        {
            switch (cellType)
            {
                case CellType.Ground:
                    return ".";
                case CellType.Wall:
                    return "#";
                case CellType.Exit:
                    return "E";
                default:
                    throw new Exception("BAD");
            }
        }
    }
}
