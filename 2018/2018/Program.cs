using _2018;
using _2018.Day1;

var totalTime = 0.0;


//DAY 1
Console.WriteLine("> Day 1 <");
var solver = new Solver<int, int>("../../../Input/day1.txt");
totalTime += solver.RunPartOne(new Day1Part1());
totalTime += solver.RunPartTwo(new Day1Part2());
Console.WriteLine(new string('-', 20));



Console.WriteLine($"Total runtime: {totalTime:F3} ms");