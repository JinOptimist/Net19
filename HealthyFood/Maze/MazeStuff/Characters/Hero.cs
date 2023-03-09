namespace Maze.MazeStuff.Characters
{
    public class Hero : BaseCharacter
    {
        public override CellType CellType => CellType.Hero;

        public Hero()
        {
            Name = "Conan-Barbarian";
            Hp = 9;
        }
        
        public override bool TryToStep(ICharacter character)
        {
            throw new NotImplementedException();
        }
    }
}
