using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Enemies
{
    public abstract class BaseEnemy : BaseCharacter
    {
        public abstract void TryMove();
    }
}
