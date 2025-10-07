using _2018;
using _2018.Day1;
using _2018.Day2;
using _2018.Day3;
using _2018.Day4;

var totalTime = 0.0;

// //DAY 1
// Console.WriteLine("> Day 1 <");
// var solver = new Solver<int, int>("../../../Input/day1.txt");
// totalTime += solver.RunPartOne(new Day1Part1());
// totalTime += solver.RunPartTwo(new Day1Part2());
// Console.WriteLine(new string('-', 20));
//
// //DAY 2
// Console.WriteLine("> Day 2 <");
// var solver2 = new Solver<int, string>("../../../Input/day2.txt");
// totalTime += solver2.RunPartOne(new Day2Part1());
// totalTime += solver2.RunPartTwo(new Day2Part2());
// Console.WriteLine(new string('-', 20));

// //DAY 3
// Console.WriteLine("> Day 3 <");
// var solver3 = new Solver<int, int>("../../../Input/day3.txt");
// totalTime += solver3.RunPartOne(new Day3Part1());
// totalTime += solver3.RunPartTwo(new Day3Part2());
// Console.WriteLine(new string('-', 20));

//DAY 4
Console.WriteLine("> Day 4 <");
var solver4 = new Solver<int, int>("../../../Input/day4.txt");
totalTime += solver4.RunPartOne(new Day4Part1());
totalTime += solver4.RunPartOne(new Day4Part2());
Console.WriteLine(new string('-', 20));

Console.WriteLine($"Total runtime: {totalTime:F3} ms");