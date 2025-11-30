using _2019;
using _2019.Day1;
using _2019.Day2;
using _2019.Day3;
using _2019.Day4;
using _2019.Day5;

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

//DAY 4
var day5 = new Day<int, int>(5, new Day5Part1(), new Day5Part2());
totalTime += day5.Solve();

Console.WriteLine(new string('-', 20));
Console.WriteLine($"Total runtime: {totalTime:F3} ms");