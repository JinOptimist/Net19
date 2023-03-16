using Maze.MazeStuff;

namespace Maze
{
    public interface IMazeBuilder
    {
        public MazeLevel Build(int width, int height);
    }
}
