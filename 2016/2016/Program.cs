using _2016;
using _2016.Day1;
using _2016.Day2;
using _2016.Day3;

var totalTime = 0.0;

//DAY 1
Console.WriteLine("> Day 1 <");
var day1 = new Day<int, int>("./Input/day1.txt");
totalTime += day1.RunPartOne(new Day1Part1());
totalTime += day1.RunPartTwo(new Day1Part2());
Console.WriteLine(new string('-', 20));


//DAY 2
Console.WriteLine("> Day 2 <");
var day2 = new Day<string, string>("./Input/day2.txt");
totalTime += day2.RunPartOne(new Day2Part1());
totalTime += day2.RunPartTwo(new Day2Part2());
Console.WriteLine(new string('-', 20));


//DAY 3
Console.WriteLine("> Day 3 <");
var day3 = new Day<int, int>("./Input/day3.txt");
//totalTime += day3.RunPartOne(new Day3Part1());
totalTime += day3.RunPartTwo(new Day3Part2());
Console.WriteLine(new string('-', 20));


Console.WriteLine($"Total runtime: {totalTime:F3} ms");