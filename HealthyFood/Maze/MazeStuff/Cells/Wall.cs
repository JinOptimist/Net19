using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Wall : BaseCell
    {
        public Wall(int x, int y, IMazeLevel level) : base(x, y, level)
        {
            Hardness = 5;
        }

        public override CellType CellType => CellType.Wall;

        public override bool TryToStep(ICharacter character)
        {
            if (Hardness > 0)
            {
                Level.SteppingOnWall = this;
                Hardness--;
                return false;
            }
            else
            {
                Level.ReplaceToGround(this);
            }

            return true;
        }
    }
}
