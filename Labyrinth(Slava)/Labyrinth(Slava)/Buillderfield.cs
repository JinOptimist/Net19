using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Slava_
{
    public class Buillderfield
    {
        private ParametrsLab _wallsLab;

        public Buillderfield(ParametrsLab wallsLab)
        {
            _wallsLab = wallsLab;
        }

        public void BuillderfielD()
        {
            for (int y = 0; y < _wallsLab.HEIGHT; y++)
            {
                
                for (int x = 0; x < _wallsLab.WIGHT; x++)
                {
                    CellsLab cell = _wallsLab.Cells.Single(cell => cell.X == x && cell.Y == y);
                    Console.Write($"[{cell.Earth}]");
                }
                Console.WriteLine();
                
            }

        }
    }
}
