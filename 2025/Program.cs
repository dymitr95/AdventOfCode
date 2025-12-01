using _2025.Days.Day01;
using _2025.Structure;

var totalTime = 0.0;

//DAY 1
var day1 = new Day<int,string>(1, new Day1Part1());
totalTime += day1.Solve();


Console.WriteLine(new string('-', 20));
Console.WriteLine($"Total runtime: {totalTime:F3} ms");