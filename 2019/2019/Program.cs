using _2019;
using _2019.Day1;
using _2019.Day2;
using _2019.Day3;

var totalTime = 0.0;


//DAY 1
var dayOne = new Day<int, int>(1, "../../../Input/day1.txt", new Day1Part1(), new Day1Part2());
totalTime += dayOne.Solve();

//DAY 2
var dayTwo = new Day<int, int>(2, "../../../Input/day2.txt", new Day2Part1(), new Day2Part2());
totalTime += dayTwo.Solve();

//DAY 3
var dayThree = new Day<int, int>(3, "../../../Input/day3.txt", new Day3Part1());
totalTime += dayThree.Solve();

Console.WriteLine(new string('-', 20));
Console.WriteLine($"Total runtime: {totalTime:F3} ms");