using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using static System.Net.Mime.MediaTypeNames;

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
            BuildGreedyHealer();
            BuildPileOfGold();
            BuildHardTrap();
            BuildGoodHealer();
            BuildHero();
            BuildEasyTrap();


            return _maze;
        }

        private void BuildEasyTrap()
        {            
            var cellsIncludingAllGround = _maze.Cells.Where(x => x.CellType == CellType.Ground).ToList();
            var randomIndexForEasyTrap = random.Next(0, cellsIncludingAllGround.Count());
            var randomEasyTrap = cellsIncludingAllGround[randomIndexForEasyTrap];
            var easyTrap = new EasyTrap(randomEasyTrap.X, randomEasyTrap.Y, _maze);
            if (cellsIncludingAllGround.Count > 0)
            {
                _maze.ReplaceCell(easyTrap);
            }
            
        }

        private void BuildHero()
        {
            var listOfGround = _maze.Cells.Where(x => x.CellType == CellType.Ground && GetNearCellByType(x, CellType.Ground).Count > 1).ToList();
            var randomGroundCellIndex = random.Next(0, listOfGround.Count);
            var randomGroundCell = listOfGround[randomGroundCellIndex];
            var greedlyGuardian = new GreedlyGuardian(randomGroundCell.X, randomGroundCell.Y, _maze);
            _maze.ReplaceCell(greedlyGuardian);
        }

        private void BuildPileOfGold()
        {
            int pileOfGoldFrequency = 20;
            var listOfGround = _maze.Cells.Where(x => x.CellType == CellType.Ground).ToList();
            for(int i = 0; i < listOfGround.Count/pileOfGoldFrequency; i++)
            {
                var randomCellNumber = random.Next(0, listOfGround.Count());
                var randomCell = listOfGround[randomCellNumber];
                var pileOfCoins = new PileOfCoins(randomCell.X, randomCell.Y, _maze);
                _maze.ReplaceCell(pileOfCoins);
            }
        }

        private void BuildHero(int startX, int startY)
        {
            var hero = new Hero(startX, startY, _maze);
            _maze.Hero = hero;
        }

        private void BuildGreedyHealer()
        {
            var grounds = _maze.Cells.Where(cell=>cell.CellType==CellType.Ground && GetNearCellByType(cell, CellType.Ground).Count > 1).ToList();
            var maxIndexGreedyHealer = grounds.Count;
            int indexGreedyHealer = random.Next(0, maxIndexGreedyHealer);
            var positionGreedyHealer = grounds[indexGreedyHealer];
            var greedyHealer = new GreedyHealer(positionGreedyHealer.X, positionGreedyHealer.Y, _maze);
            _maze.ReplaceCell(greedyHealer);
            _maze.GreedyHealer = greedyHealer;

        }//I find all the ground, choose a random one, delete it and put my healer there 

        private void BuildGoodHealer()
        {
            var changeDifficile = 15;
            var listOfGround = _maze.Cells.Where(x=> x.CellType == CellType.Ground).ToList();
            foreach (var cell in listOfGround) 
            {
                var randomCellNum = random.Next(0, listOfGround.Count/ changeDifficile);
                var randomCell = listOfGround[randomCellNum];
                var goodHealer = new GoodHealer(randomCell.X, randomCell.Y, _maze);
                _maze.ReplaceCell(goodHealer);
            }
        }
        private void BuildGround(int startX, int startY)
        {
            var randomCell = _maze
                .Cells
                .First(cell => cell.X == startX && cell.Y == startY);

            Miner(randomCell, new List<BaseCell>());

        }

        private void BuildHardTrap()
        {
            var randomX = random.Next(_maze.Widht);
            var randomY = random.Next(_maze.Height);
            var hardtrap = new HardTrap(randomX, randomY, _maze);
            _maze.ReplaceCell(hardtrap);
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
