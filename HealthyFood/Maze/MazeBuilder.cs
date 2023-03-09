using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze
{
    public class MazeBuilder
    {
        private MazeLevel _maze;
        private Random random;
        private bool _isShowMazeBuilding;

        public MazeBuilder(int? seed = null)
        {
            if (seed == null)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed.Value);
            }
        }

        public MazeLevel Build(int width = 10, int height = 5, bool isShowMazeBuilding = false)
        {
            _isShowMazeBuilding = isShowMazeBuilding;

            _maze = new MazeLevel()
            {
                Widht = width,
                Height = height,
            };

            var startX = random.Next(_maze.Widht);
            var startY = random.Next(_maze.Height);

            BuildWall();
            BuildHero(startX, startY);
            BuildGround(startX, startY);

            return _maze;
        }

        private void BuildGround(int startX, int startY)
        {
            var randomWall = _maze
                .Cells
                .OfType<Wall>()
                .First(cell => cell.X == startX && cell.Y == startY);

            Miner(randomWall, new List<Wall>());
        }

        private void BuildWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Widht; x++)
                {
                    var cell = new Wall()
                    {
                        X = x,
                        Y = y,
                    };

                    _maze.Cells.Add(cell);
                }
            }
        }

        private void BuildHero(int startX, int startY)
        {
            var character = new Character();
            character.X = startX;
            character.Y = startY;

            _maze.Hero = character;
        }

        private void Miner(Wall currentWall, List<Wall> wallToBreak)
        {
            if (_isShowMazeBuilding)
            {
                _maze.Cells.OfType<Wall>().ToList().ForEach(x => x.ConsoleColor = ConsoleColor.Gray);
                wallToBreak.ForEach(x => x.ConsoleColor = ConsoleColor.Blue);
                new MazeDrawer().Draw(_maze);
                Thread.Sleep(200);
            }

            _maze.ReplaceToGround(currentWall);
            wallToBreak.Remove(currentWall);

            var nearWalls = GetNear<Wall>(currentWall);
            wallToBreak.AddRange(nearWalls);

            wallToBreak = wallToBreak
                .Where(wall => GetNear<Ground>(wall).Count() < 2)
                .ToList();

            if (!wallToBreak.Any())
            {
                return;
            }

            var randmoIndex = random.Next(0, wallToBreak.Count);
            var randomWall = wallToBreak[randmoIndex];

            wallToBreak.Remove(randomWall);
            if (wallToBreak.Count() > 0)
            {
                Miner(randomWall, wallToBreak);
            }
        }

        private IEnumerable<T> GetNear<T>(MazeCell currentCell) where T : MazeCell
        {
            var nearCells = _maze
               .Cells
               .Where(cell =>
                   cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                   || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
               .OfType<T>();

            return nearCells;
        }


    }
}
