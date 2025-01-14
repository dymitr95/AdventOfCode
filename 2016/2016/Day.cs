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
        Console.WriteLine($"First result: {partOne.Run(Input)}");
    }

    public void RunPartTwo(Part<T> partTwo)
    {
        Console.WriteLine($"Second result: {partTwo.Run(Input)}");
    }

    private static string GetInput(string inputPath)
    {
        using var reader = new StreamReader(inputPath);
        var dataString = reader.ReadToEnd();
        reader.Close();
        return dataString;
    }
}