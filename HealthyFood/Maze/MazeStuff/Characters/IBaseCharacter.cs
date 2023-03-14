namespace Maze.MazeStuff.Characters
{
    public interface IBaseCharacter
    {
        int Coins { get; set; }
        int Hp { get; set; }
        string Name { get; set; }
    }
}