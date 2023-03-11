

using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class GoldWall : BaseCell
    {
        public int maxMoney { get; private set; } = 3;
        int _x;
        int _y;
        MazeLevel _level;
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
            if (maxMoney < 1)
            {
                Wall wall = new Wall(X, Y, Level);
                _level.ReplaceCell(wall);
            }
            return false;
        }

    }
}
