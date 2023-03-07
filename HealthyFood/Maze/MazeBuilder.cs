using Maze.MazeStuff;

namespace Maze
{
    public class MazeBuilder
    {
        private MazeLevel _maze;

        public MazeLevel Build(int width = 10, int height = 5)
        {
            _maze = new MazeLevel()
            {
                Widht = width,
                Height = height,
            };

            BuildWall();
            BuildGround();

            return _maze;
        }

        private void BuildGround()
        {
            //Write code here
            var random = new Random();

            var randomX = random.Next(_maze.Widht);
            var randomY = random.Next(_maze.Height);

            var randomCell = _maze
                .Cells
                .First(cell => cell.X == randomX && cell.Y == randomY);
            randomCell.CellType = CellType.Ground;

            var nearCells = _maze
                .Cells
                .Where(cell =>
                    cell.X == randomCell.X && Math.Abs(cell.Y - randomCell.Y) == 1
                    || cell.Y == randomCell.Y && Math.Abs(cell.X - randomCell.X) == 1)
                .ToList();

            nearCells.ForEach(x => x.CellType = CellType.Ground);
        }

        private void Miner(MazeCell currentCell, List<MazeCell> wallToBreak)
        {
            var nearWalls = _maze
                .Cells
                .Where(cell =>
                    cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                    || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
                .Where(x => x.CellType == CellType.Wall)
                .ToList();
            wallToBreak.AddRange(nearWalls);

            var random = new Random();
            var randmoIndex = random.Next(0, nearWalls.Count);
            var randomWall = wallToBreak[randmoIndex];
            randomWall.CellType = CellType.Ground;

            wallToBreak.Remove(randomWall);
            if (wallToBreak.Count() > 0)
            {
                Miner(randomWall, wallToBreak);
            }
        }

        private void BuildWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Widht; x++)
                {
                    var cell = new MazeCell()
                    {
                        X = x,
                        Y = y,
                        CellType = CellType.Wall,
                    };

                    _maze.Cells.Add(cell);
                }
            }
        }
    }
}
