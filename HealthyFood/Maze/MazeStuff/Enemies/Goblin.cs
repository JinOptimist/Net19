using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Enemies
{
    public class Goblin : BaseEnemy
    {
        public override CellType CellType => CellType.Goblin;
        
        public Goblin(int x, int y, MazeLevel level) : base(x, y, level)
        {
        }

        public override void TryMove()
        {
            
        }

        public override bool TryToStep(ICharacter character)
        {
            character.Hp--;

            Hp--;

            return false;
        }
    }
}
