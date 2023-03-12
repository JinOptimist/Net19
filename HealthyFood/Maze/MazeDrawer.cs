using Maze.MazeStuff;
using Maze.MazeStuff.Cells;

namespace Maze
{
    public class MazeDrawer
    {
        public void Draw(MazeLevel maze)
        {
            Console.Clear();
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Widht; x++)
                {
                    var cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);
                    Console.Write(GetCellSymbol(cell.CellType));
                }
                Console.WriteLine();
            }

            var hero = maze.Hero;
            Console.SetCursorPosition(hero.X, hero.Y);
            Console.Write(GetCellSymbol(hero.CellType));
            Console.SetCursorPosition(hero.X, hero.Y);

            Console.SetCursorPosition(0, maze.Height + 2);
            Console.WriteLine($"Hero HP: {hero.Hp} Coins: {hero.Coins}");
            var mazecountwall = maze.Cells.Where(x => x.CellType == CellType.Wall).Count();
            var mazecountground = maze.Cells.Where(x => x.CellType == CellType.Ground).Count();
            var mazecountgoodhealer = maze.Cells.Where(x => x.CellType == CellType.GoodHealer).Count();
            Console.WriteLine($"Ground Cell = {mazecountground} \nWall Cell = {mazecountwall} \nGood Healer = {mazecountgoodhealer}");
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
                case CellType.Hero:
                    return "@";
                case CellType.GoodHealer:
                    return "+";
                default:
                    throw new Exception("BAD");
            }
        }
    }
}
