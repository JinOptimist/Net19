using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Wall : BaseCell
    {
      public Wall(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.Wall;

        public override bool TryToStep(ICharacter character)
        {
            character.Hp--;
            return false;
        }
    }
}
