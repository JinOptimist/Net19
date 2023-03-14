using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using static System.Net.Mime.MediaTypeNames;

namespace Maze.MazeStuff.Enemies
{
    public class Goblin : BaseEnemy
    {
        public override CellType CellType => CellType.Goblin;
        
        public Goblin(int hp, int x, int y, IMazeLevel level) : base(x, y, level)
        {
            Hp = hp;
        }

        public override void EndTurnActivity()
        {
            var nearGrounds = GetNearCellNotType(this, CellType.Wall);
            var randomCell = GetRandom(nearGrounds);
            if (randomCell.TryToStep(this))
            {
                X = randomCell.X;
                Y = randomCell.Y;
            }
        }

        private BaseCell GetRandom(List<BaseCell> nearGrounds)
        {
            var random = new Random();
            var index = random.Next(nearGrounds.Count);
            return nearGrounds[index];
        }

        public override bool TryToStep(ICharacter character)
        {
            character.Hp--;

            Hp--;

            if (Hp <= 0)
            {
                Level.Enemies.Remove(this);
                character.Experience++;
            }

            return false;
        }

        private List<BaseCell> GetNearCellNotType(BaseCell currentCell, CellType type)
        {
            return Level
               .Cells
               .Where(cell =>
                   cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                   || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
               .Where(x => x.CellType != type)
               .ToList();
        }
    }
}
