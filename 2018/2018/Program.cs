using _2018;
using _2018.Day1;
using _2018.Day2;

var totalTime = 0.0;


//DAY 1
Console.WriteLine("> Day 1 <");
var solver = new Solver<int, int>("../../../Input/day1.txt");
totalTime += solver.RunPartOne(new Day1Part1());
totalTime += solver.RunPartTwo(new Day1Part2());
Console.WriteLine(new string('-', 20));

//DAY 2
Console.WriteLine("> Day 2 <");
solver = new Solver<int, int>("../../../Input/day2.txt");
totalTime += solver.RunPartOne(new Day2Part1());
totalTime += solver.RunPartTwo(new Day2Part2());
Console.WriteLine(new string('-', 20));

Console.WriteLine($"Total runtime: {totalTime:F3} ms");