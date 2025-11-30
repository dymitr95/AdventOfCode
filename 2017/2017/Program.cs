using _2017;
using _2017.Days.Day5;
using _2017.Days.Day6;
using _2017.Structure;

var totalTime = 0.0;

// //DAY 1
// var day1 = new Day<int, int>(1, new Day1Part1(), new Day1Part2());
// totalTime += day1.Solve();
//
// //DAY 2
// var day2 = new Day<int, int>(2, new Day2Part1(), new Day2Part2());
// totalTime += day2.Solve();

// //DAY 3
// var day3 = new Day<int, int>(3, new Day3Part1(), new Day3Part2());
// totalTime += day3.Solve();

// //DAY 4
// var day4 = new Day<int, int>(4, new Day4Part1(), new Day4Part2());
// totalTime += day4.Solve();

// //DAY 5
// var day5 = new Day<int, int>(5, new Day5Part1(), new Day5Part2());
// totalTime += day5.Solve();

//DAY 6
var day6 = new Day<int, int>(6, new Day6Part1());
totalTime += day6.Solve();

Console.WriteLine(new string('-', 20));
Console.WriteLine($"Total runtime: {totalTime:F3} ms");