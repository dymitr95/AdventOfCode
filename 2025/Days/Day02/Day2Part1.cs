using _2025.Structure;

namespace _2025.Days.Day02;

public class Day2Part1 : Part<ulong>
{
    public override ulong Run(string input)
    {
        var ranges = input.Split(",");

        var result = 0UL;

        foreach (var range in ranges)
        {
            var rangeSplit = range.Split("-");
            var start = Convert.ToUInt64(rangeSplit[0]);
            var end = Convert.ToUInt64(rangeSplit[1]);

            result += GetSumOfInvalidIdsInRange(start, end);
        }
        
        return result;
    }

    private static ulong GetSumOfInvalidIdsInRange(ulong start, ulong end)
    {
        var result = 0UL;

        for (var value = start; value <= end;)
        {
            var valueStr = value.ToString();
            if (valueStr.Length % 2 != 0)
            {
                value += 1;
                continue;
            }

            var half = valueStr.Length / 2;
            if (valueStr[..half] != valueStr[half..])
            {
                value += 1;
                continue;
            }

            result += value;

            var hundreds = (ulong)(valueStr.Length / 100);
            value += 10 * hundreds + 1;
        }
        
        
        return result;
    }
    
    
    
}