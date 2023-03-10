using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze
{
    public class MazeBuilder
    {

        private MazeLevel _maze;
        private Random random;
        private int moneyFromWallCount = 0;
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

            BuildGoldMine();
            BuildGoldMine();
            return _maze;
        }


        /// <summary>
        /// Make goldwall. When player try ro step in it, he takeы money, max = 3
        /// </summary>
        private void BuildGoldMine()
        {

            var searchWallList = _maze.Cells.Where(cell => cell.CellType == CellType.Wall).ToList();
            var indexOfsearchWallList = searchWallList.Count;
            int randomIndex = random.Next(0, indexOfsearchWallList);
            int xForGoldWall = searchWallList[randomIndex].X;
            int yForGoldWall = searchWallList[randomIndex].Y;


            var cellIsOneGroundNearGoldWall = _maze.Cells.Single(cell => cell.X == xForGoldWall && cell.Y == yForGoldWall);

            var countGroundNearGoldWall = GetNearCellByType(cellIsOneGroundNearGoldWall, CellType.Ground);
            GoldWall goldWall = new GoldWall(xForGoldWall, yForGoldWall, _maze);
            //Wall wall = new Wall(xForGoldWall, yForGoldWall, _maze);

            if (countGroundNearGoldWall.Count > 0)
            {
                _maze.ReplaceCell(goldWall);
            }

            else BuildGoldMine();

        }

        private void BuildHero(int startX, int startY)
        {
            var hero = new Hero(startX, startY, _maze);
            _maze.Hero = hero;
        }

        private void BuildGround(int startX, int startY)
        {
            var randomCell = _maze
                .Cells
                .First(cell => cell.X == startX && cell.Y == startY);

            Miner(randomCell, new List<BaseCell>());
        }

        private void Miner(BaseCell currentCell, List<BaseCell> wallToBreak)
        {
            _maze.ReplaceToGround(currentCell);

            var nearWalls = GetNearCellByType(currentCell, CellType.Wall);
            wallToBreak.AddRange(nearWalls);

            wallToBreak = wallToBreak
                .Where(wall => GetNearCellByType(wall, CellType.Ground).Count < 2)
                .ToList();

            if (!wallToBreak.Any())
            {
                return;
            }

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
                    var cell = new Wall(x, y, _maze);

                    _maze.Cells.Add(cell);
                }
            }
        }
    }
}
