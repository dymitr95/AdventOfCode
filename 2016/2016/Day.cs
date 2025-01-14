using System.Diagnostics;

namespace _2016;

public class Day<T>
{
    private string Input { get; }

    public Day(string inputPath)
    {
        Input = GetInput(inputPath);
    }

    public void RunPartOne(Part<T> partOne)
    {
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"First result: {partOne.Run(Input)}");
        stopwatch.Stop();
        Console.WriteLine($"Runtime: {stopwatch.ElapsedMilliseconds} ms");
    }

    public void RunPartTwo(Part<T> partTwo)
    {
        var stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"Second result: {partTwo.Run(Input)}");
        stopwatch.Stop();
        Console.WriteLine($"Runtime: {stopwatch.ElapsedMilliseconds} ms");
    }

    private static string GetInput(string inputPath)
    {
        using var reader = new StreamReader(inputPath);
        var dataString = reader.ReadToEnd();
        reader.Close();
        return dataString;
    }
}