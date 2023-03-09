namespace Maze.MazeStuff.Characters
{
    public class Hero : BaseCharacter
    {
        public Hero(int x, int y, MazeLevel level) : base(x, y, level)
        {
            Name = "Conan-Barbarian";
            Hp = 9;
        }

        public override CellType CellType => CellType.Hero;
        
        public override bool TryToStep(ICharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
