using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;

namespace Maze
{
    public class GameManager
    {
        private MazeLevel _maze;

        public void Start()
        {
            _maze = new MazeBuilder().Build();

            var drawer = new MazeDrawer();

            while (true)
            {
                drawer.Draw(_maze);

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Move(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Move(Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        Move(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Move(Direction.Down);
                        break;
                }

                EnemyMove();
            }
        }

        private void EnemyMove()
        {
            _maze.Enemies.ForEach(x => x.EndTurnActivity());
        }

        private void Move(Direction direction)
        {
            var destinationHeroX = _maze.Hero.X;
            var destinationHeroY = _maze.Hero.Y;

            switch (direction)
            {
                case Direction.Left:
                    destinationHeroX--;
                    break;
                case Direction.Right:
                    destinationHeroX++;
                    break;
                case Direction.Up:
                    destinationHeroY--;
                    break;
                case Direction.Down:
                    destinationHeroY++;
                    break;
            }

            BaseCell destinationCell;

            var enemyOnTheDestinationCell = _maze.Enemies.FirstOrDefault(cell => cell.X == destinationHeroX && cell.Y == destinationHeroY);
            if (enemyOnTheDestinationCell != null)
            {
                destinationCell = enemyOnTheDestinationCell;
            }
            else
            {
                destinationCell = _maze.Cells.SingleOrDefault(cell => cell.X == destinationHeroX && cell.Y == destinationHeroY);
            }
            
            if (destinationCell == null)
            {
                return;
            }

            if (destinationCell.TryToStep(_maze.Hero))
            {
                _maze.Hero.X = destinationHeroX;
                _maze.Hero.Y = destinationHeroY;
            }
        }
    }
}
