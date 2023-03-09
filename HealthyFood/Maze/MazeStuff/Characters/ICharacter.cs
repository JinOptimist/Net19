namespace Maze.MazeStuff.Characters
{
    public interface ICharacter : IMazeCell
    {
        string Name { get; set; }
        int Hp { get; set; }
    }
}
