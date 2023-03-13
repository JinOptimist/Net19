
using static System.Net.Mime.MediaTypeNames;

namespace Maze.MazeStuff.Characters
{
    public class GreedyHealer : BaseCharacter
    {
        public GreedyHealer(int x, int y, MazeLevel level) : base(x, y, level)
        {
            Name = "GreedyHealer";
            Hp = 10;
            Coins = 10;
        }

        public override CellType CellType => CellType.GreedyHealer;

        public override bool TryToStep(ICharacter character)
        {
            if (Coins > 0)
            {
                character.Hp++;
                character.Coins--;
                Coins--;
                return true;
            }
            else
            {
                Level.ReplaceToGround(this);
            }

            return false;
        }
    }
}
