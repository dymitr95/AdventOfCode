using _2025.Days.Day01;
using _2025.Structure;
var totalTime = 0.0;

var day = new Day<string,string>(1, new DayOnePartOne());
totalTime += day.Solve();


Console.WriteLine(new string('-', 20));
Console.WriteLine($"Total runtime: {totalTime:F3} ms");