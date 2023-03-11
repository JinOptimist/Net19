﻿using Maze.MazeStuff.Characters;
using Maze.MazeStuff.Enemies;

namespace Maze.MazeStuff.Cells
{
    public class GreedlyGuardian : BaseEnemy
    {
        public override CellType CellType => CellType.GreedlyGuardian;

        public GreedlyGuardian(int x, int y, MazeLevel level) : base(x, y, level)
        {
        }

        public override void TryMove()
        {
        }

        public override bool TryToStep(ICharacter character)
        {
            if (character.Coins > 0)
            {
                character.Coins--;
                return true;
            }
            if (character.Coins == 0 && character.Hp > 0)
            {
                character.Hp--;
                return false;
            }
            else return false;
        }
    }
}
