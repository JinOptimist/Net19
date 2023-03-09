namespace Maze.MazeStuff.Characters
{
    public class Character : MazeCell, ICharacter
    {
        public string Name { get; set; } = "Conan-Barbarian";
        public int Hp { get; set; } = 9;

        public override CellType CellType => CellType.Hero;

        public override bool TryToStep(ICharacter character)
        {
            //We couldn't step on hero. Something go wrong if it happends
            throw new NotImplementedException();
        }
    }
}
