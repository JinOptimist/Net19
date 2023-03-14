using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class Wall : BaseCell
    {
        public Wall(int x, int y, IMazeLevel level) : base(x, y, level)
        {
            Durability = 5;
        }

        public int Durability { get; set; }

        public override CellType CellType => CellType.Wall;

        public override bool TryToStep(ICharacter character)
        {
            if (Durability > 0)
            {
                Durability--;
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
