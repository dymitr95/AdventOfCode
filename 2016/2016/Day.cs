namespace _2016;

public class Day<T>
{
    private string InputPath { get; }
    private string Input { get; set; }

    public Day(string inputPath)
    {
        InputPath = inputPath;
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

    private string GetInput(string inputPath)
    {
        return "";
    }
    
}