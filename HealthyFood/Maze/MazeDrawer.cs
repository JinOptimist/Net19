using Maze.MazeStuff;
using Maze.MazeStuff.Cells;

namespace Maze
{
    public class MazeDrawer
    {
        private const int ShiftX = 2;
        private const int ShiftY = 5;

        public const char WallSymbol = '#';

        //private char[,] old;
        public void Draw(MazeLevel maze)
        {
            //Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            for (int x = -1; x < maze.Widht + 1; x++)
            {
                Console.SetCursorPosition(ShiftX + x, ShiftY - 1);
                Console.Write(WallSymbol);

                Console.SetCursorPosition(ShiftX + x, ShiftY + maze.Height);
                Console.Write(WallSymbol);
            }
            for (int y = 0; y < maze.Height; y++)
            {
                Console.SetCursorPosition(ShiftX - 1, ShiftY + y);
                Console.Write(WallSymbol);

                Console.SetCursorPosition(ShiftX + maze.Widht, ShiftY + y);
                Console.Write(WallSymbol);
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int y = 0; y < maze.Height; y++)
            {
                for (int x = 0; x < maze.Widht; x++)
                {
                    var cell = maze.Cells.Single(cell => cell.X == x && cell.Y == y);

                    Console.SetCursorPosition(ShiftX + x, ShiftY + y);
                    Console.Write(GetCellSymbol(cell));
                }
                Console.WriteLine();
            }

            var hero = maze.Hero;
            Console.SetCursorPosition(ShiftX + hero.X, ShiftY + hero.Y);
            Console.Write(GetCellSymbol(hero));

            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"Hero HP: {maze.Hero.Hp}");
        }

        private string GetCellSymbol(IMazeCell cell)
        {
            switch (cell.CellType)
            {
                case CellType.Ground:
                    return " ";
                case CellType.Wall:
                    var wall = cell as Wall;
                    Console.ForegroundColor = wall.ConsoleColor;
                    return "#";
                case CellType.Exit:
                    return "E";
                case CellType.Hero:
                    return "@";
                default:
                    throw new Exception("BAD");
            }
        }
    }
}
