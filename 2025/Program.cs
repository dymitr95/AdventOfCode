using _2025.Days.Day01;
using _2025.Days.Day02;
using _2025.Days.Day03;
using _2025.Days.Day04;
using _2025.Days.Day05;
using _2025.Days.Day06;
using _2025.Days.Day07;
using _2025.Days.Day08;
using _2025.Days.Day09;
using _2025.Days.Day10;
using _2025.Days.Day11;
using _2025.Days.Day12;
using _2025.Structure;

var totalTime = 0.0;
var dayTotalTime = 0.0;

// //DAY 1
// var day1 = new Day<int, int>(1, new Day1Part1(), new Day1Part2());
// dayTotalTime = day1.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 2
// var day2 = new Day<ulong, ulong>(2, new Day2Part1(), new Day2Part2());
// dayTotalTime = day2.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 3
// var day3 = new Day<int, long>(3, new Day3Part1(), new Day3Part2());
// dayTotalTime = day3.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 4
// var day4 = new Day<int, int>(4, new Day4Part1(), new Day4Part2());
// dayTotalTime = day4.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 5
// var day5 = new Day<int, long>(5, new Day5Part1(), new Day5Part2());
// dayTotalTime = day5.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 6
// var day6 = new Day<long, long>(6, new Day6Part1(), new Day6Part2());
// dayTotalTime = day6.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 7
// var day7 = new Day<int, long>(7, new Day7Part1(), new Day7Part2());
// dayTotalTime = day7.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 8
// var day8 = new Day<int, long>(8, new Day8Part1(), new Day8Part2());
// dayTotalTime = day8.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 9
// var day9 = new Day<long, long>(9, new Day9Part1(), new Day9Part2());
// dayTotalTime = day9.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;
//
// //DAY 10
// var day10 = new Day<int, int>(10, new Day10Part1(), new Day10Part2());
// dayTotalTime = day10.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;

// //DAY 11
// var day11 = new Day<int, long>(11, new Day11Part1(), new Day11Part2());
// dayTotalTime = day11.Solve();
// Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
// totalTime += dayTotalTime;

//DAY 12
var day12 = new Day<int, int>(12, new Day12Part1(), new Day12Part2());
dayTotalTime = day12.Solve();
Console.WriteLine($"Day total runtime: {dayTotalTime:F3} ms");
totalTime += dayTotalTime;


Console.WriteLine(new string('-', 20));
Console.WriteLine($"All days total runtime: {totalTime:F3} ms");