

using Maze.MazeStuff.Characters;

namespace Maze.MazeStuff.Cells
{
    public class GoldWall : BaseCell
    {
        public int maxMoney { get; private set; } = 3;       
        public GoldWall(int x, int y, IMazeLevel level) : base(x, y, level)
        {
        }

        public override CellType CellType => CellType.GoldWall;
        public override bool TryToStep(ICharacter character)
        {
            if (maxMoney > 0)
            {
                character.Coins++;
                maxMoney--;
            }
            
            if (maxMoney < 1)
            {
                var wall = new Wall(X, Y, Level);
                Level.ReplaceCell(wall);
            }
            return false;
        }

    }
}
