// See https://aka.ms/new-console-template for more information
using Maze;
using Maze.MazeStuff;

Console.WriteLine("MAZE");

var builder = new MazeBuilder();
var drawer = new MazeDrawer();


MazeLevel maze = builder.Build();
drawer.Draw(maze);


var key = Console.ReadKey();
if (key.Key == ConsoleKey.LeftArrow)
{

}
