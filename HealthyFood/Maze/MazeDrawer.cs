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
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            foreach (var enemy in maze.Enemies)
            {
                Console.SetCursorPosition(enemy.X, enemy.Y);
                Console.Write(GetCellSymbol(enemy.CellType));
            }

            var hero = maze.Hero;
            Console.SetCursorPosition(hero.X, hero.Y);
            Console.Write(GetCellSymbol(hero.CellType));
            Console.SetCursorPosition(hero.X, hero.Y);

            Console.SetCursorPosition(0, maze.Height + 2);
            Console.WriteLine($"Hero HP: {hero.Hp} Coins: {hero.Coins} Exp: {hero.Experience}");
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
                case CellType.GreedyHealer:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "H";
                case CellType.HardTrap:
                    return "*";
                case CellType.GreedlyGuardian:
                    Console.ForegroundColor = ConsoleColor.Red;
                    return "&";
                case CellType.GoodHealer:
                    return "+";
                case CellType.PileOfCoins:
                    return "G";
                case CellType.Goblin:
                    return "g";
                default:
                    throw new Exception($"Unknown cell type {cellType}");
            }
        }
    }
}
