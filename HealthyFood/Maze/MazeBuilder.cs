﻿using Maze.MazeStuff;
using Maze.MazeStuff.Cells;
using Maze.MazeStuff.Characters;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Maze
{
    public class MazeBuilder
    {
        private MazeLevel _maze;
        private Random random;

        public MazeBuilder(int? seed = null)
        {
            if (seed == null)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed.Value);
            }
        }

        public MazeLevel Build(int width = 10, int height = 5)
        {
            _maze = new MazeLevel()
            {
                Widht = width,
                Height = height,
            };

            var startX = random.Next(_maze.Widht);
            var startY = random.Next(_maze.Height);

            BuildWall();
            BuildGround(startX, startY);
            BuildHero(startX, startY);
            BuildDeadEndTeleport();

            return _maze;
        }

        private void BuildDeadEndTeleport()
        {
            var firstCell = _maze
                .Cells
                .First(cell => cell.X == 0 && cell.Y == 0);
            _maze.ReplaceCellByType(firstCell, CellType.DeadEndTeleport);
            MinerForDeadEndTeleport(firstCell, new List<BaseCell>());

            var LastCell = _maze
                .Cells
                .First(cell => cell.X == _maze.Widht - 1 && cell.Y == _maze.Height - 1);
            _maze.ReplaceCellByType(LastCell, CellType.DeadEndTeleport);
            MinerForDeadEndTeleport(LastCell, new List<BaseCell>());
        }

        private void BuildHero(int startX, int startY)
        {
            var hero = new Hero(startX, startY, _maze);
            _maze.Hero = hero;
        }

        private void BuildGround(int startX, int startY)
        {
            var randomCell = _maze
                .Cells
                .First(cell => cell.X == startX && cell.Y == startY);

            Miner(randomCell, new List<BaseCell>());
        }

        private void Miner(BaseCell currentCell, List<BaseCell> wallToBreak)
        {
            _maze.ReplaceToGround(currentCell);

            var nearWalls = GetNearCellByType(currentCell, CellType.Wall);
            wallToBreak.AddRange(nearWalls);

            wallToBreak = wallToBreak
                .Where(wall => GetNearCellByType(wall, CellType.Ground).Count < 2)
                .ToList();

            if (!wallToBreak.Any())
            {
                return;
            }

            var random = new Random();
            var randmoIndex = random.Next(0, wallToBreak.Count);
            var randomWall = wallToBreak[randmoIndex];

            wallToBreak.Remove(randomWall);
            if (wallToBreak.Count() > 0)
            {
                Miner(randomWall, wallToBreak);
            }
        }

        private List<BaseCell> GetNearCellByType(BaseCell currentCell, CellType type)
        {
            return _maze
               .Cells
               .Where(cell =>
                   cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                   || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
               .Where(x => x.CellType == type)
               .ToList();
        }

        private List<BaseCell> GetNearCell(BaseCell currentCell)
        {
            return _maze
               .Cells
               .Where(cell =>
                   cell.X == currentCell.X && Math.Abs(cell.Y - currentCell.Y) == 1
                   || cell.Y == currentCell.Y && Math.Abs(cell.X - currentCell.X) == 1)
               .ToList();
        }

        private void BuildWall()
        {
            for (int y = 0; y < _maze.Height; y++)
            {
                for (int x = 0; x < _maze.Widht; x++)
                {
                    var cell = new Wall(x, y, _maze);

                    _maze.Cells.Add(cell);
                }
            }
        }

        private void MinerForDeadEndTeleport(BaseCell currentCell, List<BaseCell> wallToBreak)
        {
            var nearWalls = GetNearCellByType(currentCell, CellType.Wall);
            wallToBreak.AddRange(nearWalls);

            if (wallToBreak.Count == 1)
            {
                return;
            }

            var random = new Random();
            int randmoIndex;

            if (wallToBreak.Count == 2)
            {
                randmoIndex = random.Next(0, wallToBreak.Count - 1);
                var randomWall = wallToBreak[randmoIndex];
                wallToBreak.Remove(randomWall);

                _maze.ReplaceCellByType(randomWall, CellType.Ground);
            }
            else
            {
                var nearCells = GetNearCell(currentCell);
                randmoIndex = random.Next(0, nearCells.Count - 1);
                var randomCell = nearCells[randmoIndex];
                nearCells.Remove(randomCell);

                _maze.ReplaceCellByType(randomCell, CellType.Wall);
            }
        }
    }
}
