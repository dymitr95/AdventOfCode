using _2025.Days.Day01;
using _2025.Days.Day02;
using _2025.Structure;

var totalTime = 0.0;

// //DAY 1
// var day1 = new Day<int, int>(1, new Day1Part1(), new Day1Part2());
// totalTime += day1.Solve();

//DAY 2
var day2 = new Day<string, string>(2, new Day2Part1(), new Day2Part2());
totalTime += day2.Solve();


Console.WriteLine(new string('-', 20));
Console.WriteLine($"Total runtime: {totalTime:F3} ms");