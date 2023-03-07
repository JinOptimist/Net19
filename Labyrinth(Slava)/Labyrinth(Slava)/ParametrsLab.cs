using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth_Slava_
{
    public class ParametrsLab
    {
        public int WIGHT { get; set; } = 8;
        public int HEIGHT { get; set; } = 10;
        
        public List<CellsLab> Cells { get; set; } = new List<CellsLab>();
    }
}
