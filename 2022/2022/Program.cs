using _2022;
using _2022.Day1;

var totalTime = 0.0;

//DAY 1
Console.WriteLine("> Day 1 <");
var day1 = new Day<int, int>("./Input/day1.txt");
totalTime += day1.RunPartOne(new Day1Part1());
totalTime += day1.RunPartTwo(new Day1Part2());
Console.WriteLine(new string('-', 20));


Console.WriteLine($"Total runtime: {totalTime:F3} ms");