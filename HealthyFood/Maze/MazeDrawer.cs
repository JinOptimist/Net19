using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

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

            var hero = maze.Hero;
            Console.SetCursorPosition(hero.X, hero.Y);
            Console.Write(GetCellSymbol(hero.CellType));
            Console.SetCursorPosition(hero.X, hero.Y);
            SetRadiusOfVisibility(hero, maze);

            Console.SetCursorPosition(0, maze.Height + 2);
            Console.WriteLine($"Hero HP: {hero.Hp} Coins: {hero.Coins}");
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
                case CellType.UnknownCell:
                    return "?";
                default:
                    throw new Exception("BAD");
            }
        }
        private void SetRadiusOfVisibility(ICharacter hero, MazeLevel maze)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    var cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);
                    if (Math.Abs(hero.X - cell.X) == x && Math.Abs(hero.Y - cell.Y) == y)
                    {
                        cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);
                        Console.Write(GetCellSymbol(cell.CellType));
                    }
                    else
                    {
                        Console.Write(GetCellSymbol(CellType.UnknownCell));
                    }
                }
            }
        }
    }
}
