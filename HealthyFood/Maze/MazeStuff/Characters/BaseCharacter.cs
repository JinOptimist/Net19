using Maze.MazeStuff.Cells;

namespace Maze.MazeStuff.Characters
{
    public abstract class BaseCharacter : BaseCell, ICharacter
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Coins { get; set; }
    }
}
