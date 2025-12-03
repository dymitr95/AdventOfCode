using _2025.Structure;

namespace _2025.Days.Day03;

public class Day3Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");
        long result = 0;

        foreach (var row in rows)
        {
            result += FindLargestJoltage(row.ToCharArray(), 12);
        }
        
        return result;
    }


    private static long FindLargestJoltage(char[] rating, int targetLength)
    {

        var turnOff = rating.Length - targetLength;
        var result = new Stack<char>();
        
        foreach (var bank in rating)
        {
            while (turnOff > 0 && result.Count > 0 && result.Peek() < bank)
            {
                result.Pop();
                turnOff--;
            }
            result.Push(bank);
        }

        while (turnOff != 0)
        {
            result.Pop();
            turnOff--;
        }
        
        var resultStr = new string(result.Reverse().ToArray());
        
        return long.Parse(resultStr);
    }
}