using _2017;
using _2017.Day1;
using _2017.Day2;
using _2017.Day4;
using _2017.Day5;

var totalTime = 0.0;

var solver = new Solver<int, int>("");

// //DAY 1
// Console.WriteLine("> Day 1 <");
// solver = new Solver<int, int>("../../../Input/day1.txt");
// totalTime += solver.RunPartOne(new Day1Part1());
// totalTime += solver.RunPartTwo(new Day1Part2());
// Console.WriteLine(new string('-', 20));
//
// //DAY 2
// Console.WriteLine("> Day 2 <");
// solver = new Solver<int, int>("../../../Input/day2.txt");
// totalTime += solver.RunPartOne(new Day2Part1());
// totalTime += solver.RunPartTwo(new Day2Part2());
// Console.WriteLine(new string('-', 20));

// //DAY 4
// Console.WriteLine("> Day 4 <");
// solver = new Solver<int, int>("../../../Input/day4.txt");
// totalTime += solver.RunPartOne(new Day4Part1());
// totalTime += solver.RunPartTwo(new Day4Part2());
// Console.WriteLine(new string('-', 20));

//DAY 5
Console.WriteLine("> Day 5 <");
solver = new Solver<int, int>("../../../Input/day5.txt");
totalTime += solver.RunPartOne(new Day5Part1());
totalTime += solver.RunPartTwo(new Day5Part2());
Console.WriteLine(new string('-', 20));

Console.WriteLine($"Total runtime: {totalTime:F3} ms");