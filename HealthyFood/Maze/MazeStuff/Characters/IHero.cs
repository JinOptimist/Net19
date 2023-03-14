namespace Maze.MazeStuff.Characters
{
    public interface IHero : IBaseCharacter
    {
        CellType CellType { get; }

        bool TryToStep(ICharacter character);
    }
}