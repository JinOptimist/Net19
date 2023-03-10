﻿using Maze.MazeStuff;

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
            }
        }

        private void Move(Direction direction)
        {
            var destinationHeroX = _maze.Hero.X;
            var destinationHeroY = _maze.Hero.Y;

            var destinationGreedyHealerX = _maze.GreedyHealer.X;
            var destinationGreedyHealerY = _maze.GreedyHealer.Y;

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

            var destinationCell = _maze.Cells.SingleOrDefault(cell => cell.X == destinationHeroX && cell.Y == destinationHeroY);
            var destinationGreedyHealer = _maze.Cells.SingleOrDefault(cell => cell.X == destinationGreedyHealerX && cell.Y == destinationGreedyHealerY);


            if (destinationCell == null)
            {
                return;
            }

            if (destinationCell.TryToStep(_maze.Hero))
            {
                _maze.Hero.X = destinationHeroX;
                _maze.Hero.Y = destinationHeroY;
            }

            if (destinationGreedyHealer == destinationCell && _maze.Hero.Coins > 0)
            {
                _maze.Hero.Hp++;
                _maze.Hero.Coins--;
            }//If the hero steps on the healer +Hp,-Coins

        }
    }
}
