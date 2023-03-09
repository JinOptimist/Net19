using Maze.MazeStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    public class GameManager
    {
        private MazeLevel _mazeLevel;
        public void StartGame()
        {
            _mazeLevel = new MazeBuilder().Build(20, 10, isShowMazeBuilding: true);
            var drawer = new MazeDrawer();

            var isGameContinue = true;
            while (isGameContinue)
            {
                drawer.Draw(_mazeLevel);

                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        HeroMove(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        HeroMove(Direction.Right);
                        break;
                    case ConsoleKey.UpArrow:
                        HeroMove(Direction.Top);
                        break;
                    case ConsoleKey.DownArrow:
                        HeroMove(Direction.Bottom);
                        break;
                    case ConsoleKey.Escape:
                        isGameContinue = false;
                        break;
                }
            }

            Console.WriteLine("Game over");
        }

        private void HeroMove(Direction direction)
        {
            var currentHeroX = _mazeLevel.Hero.X;
            var currentHeroY = _mazeLevel.Hero.Y;

            switch (direction)
            {
                case Direction.Left:
                    currentHeroX--;
                    break;
                case Direction.Right:
                    currentHeroX++;
                    break;
                case Direction.Top:
                    currentHeroY--;
                    break;
                case Direction.Bottom:
                    currentHeroY++;
                    break;
                default:
                    break;
            }

            var destenationCell = _mazeLevel.Cells.SingleOrDefault(cell => cell.X == currentHeroX && cell.Y == currentHeroY);

            if (destenationCell == null)
            {
                //Console.WriteLine("You can't go outside");
                return;
            }

            if (destenationCell.TryToStep(_mazeLevel.Hero))
            {
                _mazeLevel.Hero.X = currentHeroX;
                _mazeLevel.Hero.Y = currentHeroY;
            }
        }
    }
}
