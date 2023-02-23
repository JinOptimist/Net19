// See https://aka.ms/new-console-template for more information
using Maze;

Console.WriteLine("MAZE");

var builder = new MazeBuilder();
var maze = builder.Build();

var drawer = new MazeDrawer();
drawer.Draw(maze);
