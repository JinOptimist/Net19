using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze
{
    public class MazeBuilder
    {
        private MazeLevel _maze;
        private Random random;

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

        public MazeLevel Build(int width = 10, int height = 5)
        {
            _maze = new MazeLevel()
            {
                Widht = width,
                Height = height,
            };

            var startX = random.Next(_maze.Widht);
            var startY = random.Next(_maze.Height);

            BuildWall();
            BuildGround(startX, startY);
            BuildHero(startX, startY);

            return _maze;
        }

        private void BuildGround(int startX, int startY)
        {
            var randomCell = _maze
                .Cells
                .First(cell => cell.X == startX && cell.Y == startY);

            Miner(randomCell, new List<MazeCell>());
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

        private void Miner(MazeCell currentWall, List<MazeCell> wallToBreak)
        {
            _maze.ReplaceToGround(currentWall);

            var nearWalls = GetNear(currentWall, CellType.Wall);
            wallToBreak.AddRange(nearWalls);

            wallToBreak = wallToBreak
                .Where(wall => GetNear(wall, CellType.Ground).Count() < 2)
                .ToList();

            var randmoIndex = random.Next(0, wallToBreak.Count);
            var randomWall = wallToBreak[randmoIndex];

            wallToBreak.Remove(randomWall);
            if (wallToBreak.Count() > 0)
            {
                Miner(randomWall, wallToBreak);
            }
        }

        private IEnumerable<MazeCell> GetNear(MazeCell currentCell, CellType cellType)
        {
            var nearCells = _maze
               .Cells
               .Where(cell =>
                   cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                   || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
               .Where(x => x.CellType == cellType);

            return nearCells;
        }


    }
}
