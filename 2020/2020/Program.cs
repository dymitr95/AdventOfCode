using _2020;
using _2020.Day1;
using _2020.Day2;
using _2020.Day3;

var totalTime = 0.0;


//DAY 1
Console.WriteLine("> Day 1 <");
var day = new Day<int, int>("./Input/day1.txt");
totalTime += day.RunPartOne(new Day1Part1());
totalTime += day.RunPartTwo(new Day1Part2());
Console.WriteLine(new string('-', 20));

//DAY 2
Console.WriteLine("> Day 2 <");
day = new Day<int, int>("./Input/day2.txt");
totalTime += day.RunPartOne(new Day2Part1());
totalTime += day.RunPartTwo(new Day2Part2());
Console.WriteLine(new string('-', 20));

//DAY 3
Console.WriteLine("> Day 3 <");
day = new Day<int, int>("./Input/day3.txt");
totalTime += day.RunPartOne(new Day3Part1());
totalTime += day.RunPartTwo(new Day3Part2());
Console.WriteLine(new string('-', 20));

Console.WriteLine($"Total runtime: {totalTime:F3} ms");