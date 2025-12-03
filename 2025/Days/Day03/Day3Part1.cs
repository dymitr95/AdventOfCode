using _2025.Structure;

namespace _2025.Days.Day03;

public class Day3Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0;

        foreach (var row in rows)
        {
            result += FindLargestJoltage(row.ToCharArray());
        }
        
        return result;
    }


    private static int FindLargestJoltage(char[] rating)
    {

        var firstVal = GetHighestBatteryInRange(0, rating.Length - 1, rating);
        var secondVal = GetHighestBatteryInRange(firstVal.Item2 + 1, rating.Length, rating);

        var combinedBank = firstVal.Item1 + "" + secondVal.Item1;
        
        return int.Parse(combinedBank);
    }


    private static (int, int) GetHighestBatteryInRange(int start, int end, char[] rating)
    {
        var result = 0;
        var position = 0;
        
        for (var i = start; i < end; i++)
        {
            if (rating[i] - '0' > result)
            {
                result = rating[i] - '0';
                position = i;
            }
        }

        return (result, position);
    }
    
}