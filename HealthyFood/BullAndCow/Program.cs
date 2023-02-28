// See https://aka.ms/new-console-template for more information
using BullAndCow;

Console.WriteLine("Bull and Cow!");

var gamer = new Gamer();
var leader = new Leader();
var gameManger = new GameManager(leader, gamer);
gameManger.StartGame();