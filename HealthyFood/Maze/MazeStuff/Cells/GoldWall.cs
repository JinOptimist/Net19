

using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class GoldWall : BaseCell
    {
        private int maxMoney = 3;
        public GoldWall(int x, int y, MazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.GoldWall;
        public override bool TryToStep(ICharacter character)
        {
            if (maxMoney > 0)
            {
                character.Coins++;
            }
            maxMoney--;
            return false;
        }

    }
}
