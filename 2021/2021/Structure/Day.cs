using System.Diagnostics;

namespace _2021.Structure;


public class Day<T1,T2>
{
    private Part<T1> PartOne { get; set; }
    private Part<T2>? PartTwo { get; set; }
    private string InputPath { get; set; }
    
    public Day(int dayNumber, Part<T1> partOne, Part<T2>? partTwo = null)
    {
        Console.WriteLine(new string('-', 20));
        Console.WriteLine($"> Day {dayNumber} <");
        InputPath = $"../../../Inputs/day{dayNumber}.txt";
        PartOne = partOne;
        PartTwo = partTwo;
    }
    
    public double Solve()
    {
        var totalTime = 0.0;
        var solver = new Solver<T1, T2>(InputPath);
        totalTime += solver.RunPartOne(PartOne);

        if (PartTwo == null)
        {
            return totalTime;
        }
        
        totalTime += solver.RunPartTwo(PartTwo);
        return totalTime;
    }
}