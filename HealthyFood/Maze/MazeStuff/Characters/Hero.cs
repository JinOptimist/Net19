namespace Maze.MazeStuff.Characters
{
    public class Hero : ICharacter
    {
        public string Name { get; set; } = "Conan-Barbarian";
        public int Hp { get; set; } = 9;
        public int Coins { get; set; } = 10;

        public CellType CellType => CellType.Hero;

        public int X { get; set; }
        public int Y { get; set; }

        public bool TryToStep(ICharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
