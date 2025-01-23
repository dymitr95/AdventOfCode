using _2020;
using _2020.Day1;
using _2020.Day2;

var totalTime = 0.0;

//DAY 1
Console.WriteLine("> Day 1 <");
var day1 = new Day<int, int>("./Input/day1.txt");
totalTime += day1.RunPartOne(new Day1Part1());
totalTime += day1.RunPartTwo(new Day1Part2());
Console.WriteLine(new string('-', 20));

//DAY 1
Console.WriteLine("> Day 2 <");
var day2 = new Day<int, int>("./Input/day2.txt");
totalTime += day2.RunPartOne(new Day2Part1());
totalTime += day2.RunPartTwo(new Day2Part2());
Console.WriteLine(new string('-', 20));

Console.WriteLine($"Total runtime: {totalTime:F3} ms");