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

            BuildWall();
            BuildGround();
            BuildHero();
            BuildRandomTeleport();

            return _maze;
        }

        private void BuildHero()
        {
            var hero = new Hero()
            {
                X = 2,
                Y = 1
            };

            _maze.Hero = hero;
        }

        private void BuildGround()
        {
            var randomX = random.Next(_maze.Widht);
            var randomY = random.Next(_maze.Height);

            var randomCell = _maze
                .Cells
                .First(cell => cell.X == randomX && cell.Y == randomY);

            Miner(randomCell, new List<BaseCell>());
        }
        private void BuildRandomTeleport()
        {
            var teleport = new RandomTeleport()
            {
                X = 1,
                Y = 1
            };
            _maze.RandomTeleport = teleport;
            //var randomX = random.Next(3);
            //var randomY = random.Next(5);
            //Random rand = new Random();
            //var hero = CellType.Hero;
            //var teleport = CellType.RandomTelepot;
            //var randomTeleport = new RandomTeleport()
            //{
            //    X = randomX,
            //    Y = randomY
            //};

            //_maze.RandomTeleport = randomTeleport;
        }

        //private void BuildTeleport()
        //{
        //    for (int y = 0; y < _maze.Height; y++)
        //    {
        //        for (int x = 0; x < _maze.Widht; x++)
        //        {
        //            var teleport = new RandomTeleport()
        //            {
        //                X = x,
        //                Y = y,
        //            };

        //            _maze.Cells.Add(teleport);
        //        }
        //    }
        //}
        private void Miner(BaseCell currentCell, List<BaseCell> wallToBreak)
        {
            _maze.ReplaceToGround(currentCell);

            var nearWalls = GetNearCellByType(currentCell, CellType.Wall);
            wallToBreak.AddRange(nearWalls);

            wallToBreak = wallToBreak
                .Where(wall => GetNearCellByType(wall, CellType.Ground).Count < 2)
                .ToList();
            
            var random = new Random();
            var randmoIndex = random.Next(0, wallToBreak.Count);
            var randomWall = wallToBreak[randmoIndex];

            wallToBreak.Remove(randomWall);
            if (wallToBreak.Count() > 0)
            {
                Miner(randomWall, wallToBreak);
            }
        }

        private List<BaseCell> GetNearCellByType(BaseCell currentCell, CellType type)
        {
            return _maze
               .Cells
               .Where(cell =>
                   cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                   || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
               .Where(x => x.CellType == type)
               .ToList();
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
    }
}
