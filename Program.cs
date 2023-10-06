// See https://aka.ms/new-console-template for more information
using TestLibrary;

Console.WriteLine("Hello, World!");
Maze maze = new Maze("simpleWithExit.maze");
//Maze maze = new Maze("simpleWithoutExit.maze");
Console.WriteLine(maze.PrintMaze());

Console.WriteLine(maze.DepthFirstSearch());