using System.Diagnostics;

namespace _2018;

public class Solver<T1,T2>
{
    private string Input { get; }
    private double TotalTime { get; set; }
    
    public Solver(string inputPath)
    {
        Input = GetInput(inputPath);
    }

    public double RunPartOne(Part<T1> partOne)
    {
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"First result: {partOne.Run(Input)}");
        stopwatch.Stop();
        Console.WriteLine($"Runtime: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
        return stopwatch.Elapsed.TotalMilliseconds;
    }

    public double RunPartTwo(Part<T2> partTwo)
    {
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"Second result: {partTwo.Run(Input)}");
        stopwatch.Stop();
        Console.WriteLine($"Runtime: {stopwatch.Elapsed.TotalMilliseconds:F3} ms");
        return stopwatch.Elapsed.TotalMilliseconds;
    }

    private static string GetInput(string inputPath)
    {
        if (string.IsNullOrEmpty(inputPath))
        {
            return "";
        }
        using var reader = new StreamReader(inputPath);
        var dataString = reader.ReadToEnd();
        reader.Close();
        return dataString;
    }
}