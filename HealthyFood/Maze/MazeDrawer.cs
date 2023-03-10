using Maze.MazeStuff;

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


            var greedyHealer = maze.GreedyHealer;
            Console.SetCursorPosition(greedyHealer.X, greedyHealer.Y);
            Console.Write(GetCellSymbol(greedyHealer.CellType));

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
                    return "+";
                default:
                    throw new Exception("BAD");
            }
        }
    }
}
