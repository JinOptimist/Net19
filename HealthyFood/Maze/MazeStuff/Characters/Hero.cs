namespace Maze.MazeStuff.Characters
{
    public class Hero : BaseCharacter
    {
        public const double RADIUS_PADDING = 0.6;

        public Hero(int x, int y, MazeLevel level) : base(x, y, level)
        {
            Name = "Conan-Barbarian";
            Hp = 9;
            Coins = 10;
            Radius = 4;
        }

        public override CellType CellType => CellType.Hero;

        public override bool TryToStep(ICharacter character)
        {
            throw new NotImplementedException();
        }

        public override void UpdateVisibleCells()
        {
            VisibleCells.Clear();
            double radius = Radius + RADIUS_PADDING;

            for (int y = Math.Clamp(Y - Radius, 0, Level.Height - 1); y <= Math.Clamp(Y + Radius, 0, Level.Height - 1); y++)
            {
                for (int x = Math.Clamp(X - Radius, 0, Level.Widht - 1); x <= Math.Clamp(X + radius, 0, Level.Widht - 1); x++)
                {
                    double sqrDistance = Math.Pow(x - X, 2) + Math.Pow(y - Y, 2);
                    if (sqrDistance <= radius * radius)
                    {
                        var cell = Level.Cells.First(cell => cell.X == x && cell.Y == y);
                        VisibleCells.Add(cell);
                    }
                }
            }
        }
    }
}
