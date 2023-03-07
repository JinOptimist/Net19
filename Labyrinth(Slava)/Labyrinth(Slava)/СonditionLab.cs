using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Labyrinth_Slava_
{
    public class СonditionLab
    {
        private ParametrsLab _wallsLab;


        public СonditionLab(ParametrsLab wallsLab)
        {
            _wallsLab = wallsLab;
        }


        public void BuildLaB()
        {
            RulesWalls();
            FirstPoint();
        }

        public void FirstPoint()
        {
            Buillderfield buillderfield = new Buillderfield(_wallsLab);
            var random = new Random();
            var randomX = random.Next(_wallsLab.WIGHT);
            var randomY = random.Next(_wallsLab.HEIGHT);

            CellsLab RandomCell = _wallsLab.Cells.First(cell => cell.X == randomX && cell.Y == randomY);
            RandomCell.Earth = ' ';
            var OneStep = _wallsLab.Cells.Where(cell => cell.X == RandomCell.X && (cell.Y == RandomCell.Y - 1 || cell.Y == RandomCell.Y + 1) || cell.Y == RandomCell.Y && (cell.X == RandomCell.X - 1 || cell.X == RandomCell.X + 1)).ToList();
            OneStep.ForEach(X => X.Earth = ' ');

            CellsLab LastElement = OneStep.Last();

            ProgressGame(LastElement, buillderfield);
        }

        private List<CellsLab> GetCellsLab(CellsLab LastElement)
        {
            List<CellsLab> OneStep = new();
            if (_wallsLab.Cells.Max(x => x.X) >= LastElement.X + 1)
            {
                OneStep.AddRange(_wallsLab.Cells.Where(cell => cell.Y == LastElement.Y && cell.X == LastElement.X + 1));
            }
            if (_wallsLab.Cells.Min(x => x.X) <= LastElement.X - 1)
            {
                OneStep.AddRange(_wallsLab.Cells.Where(cell => cell.Y == LastElement.Y && cell.X == LastElement.X - 1));
            }
            if (_wallsLab.Cells.Max(x => x.Y) >= LastElement.Y + 1)
            {
                OneStep.AddRange(_wallsLab.Cells.Where(cell => cell.X == LastElement.X && cell.Y == LastElement.Y + 1));
            }
            if (_wallsLab.Cells.Min(x => x.Y) <= LastElement.Y - 1)
            {
                OneStep.AddRange(_wallsLab.Cells.Where(cell => cell.X == LastElement.X && cell.Y == LastElement.Y - 1));
            }

            return OneStep;
        }

        public void ProgressGame(CellsLab LastElement, Buillderfield buillderfield)
        {
             List<CellsLab> OneStep = GetCellsLab(LastElement);

            if (OneStep.Where(cell => cell.Earth == ' ').Count() >= 2)
            {
                return;
            }
            LastElement.Earth = ' ';

            var CheckEarth = OneStep.Where(cell => cell.Earth == '#').ToList();
            
            buillderfield.BuillderfielD();
            Console.WriteLine();

            foreach (var cell in CheckEarth)
            {
                ProgressGame(cell, buillderfield);
            }
        }


        public void RulesWalls()
        {
            for (int y = 0; y < _wallsLab.HEIGHT; y++)
            {
                for (int x = 0; x < _wallsLab.WIGHT; x++)
                {
                    CellsLab cellsLab() => new CellsLab()
                    {
                        X = x,
                        Y = y,
                        Earth = '#'
                    };
                    _wallsLab.Cells.Add(cellsLab());
                }
            }
        }


    }
}
