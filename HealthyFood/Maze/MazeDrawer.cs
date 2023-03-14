using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze
{
    public class MazeDrawer
    {
        public const int RADIUS = 4;
        public void Draw(MazeLevel maze)
        {
            Console.Clear();
            var hero = maze.Hero;
            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Widht; x++)
                {
                    var cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);
                    if(isItVisibleCell(cell, hero))
                    {
                        Console.Write(GetCellSymbol(cell.CellType));
                    }
                    else
                    {
                        Console.Write("?");
                    }
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            Console.SetCursorPosition(hero.X, hero.Y);
            Console.Write(GetCellSymbol(hero.CellType));
            Console.SetCursorPosition(hero.X, hero.Y);

            Console.SetCursorPosition(0, maze.Height + 2);
            Console.WriteLine($"Hero HP: {hero.Hp} Coins: {hero.Coins}");
        }

        private bool isItVisibleCell(BaseCell cell, ICharacter hero)
        {
            var distance = Math.Pow(cell.X - hero.X, 2) + Math.Pow(cell.Y - hero.Y, 2);
            return distance < Math.Pow(RADIUS, 2);
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
                case CellType.EasyTrap:
                    return "X";
                case CellType.GoldWall:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    return "#";
                default:
                    throw new Exception("BAD");
            }
        }
    }
}
