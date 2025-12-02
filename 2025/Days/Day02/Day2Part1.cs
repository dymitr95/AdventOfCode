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

        var minimalInvalidId = GetMinimalInvalidId(start);
        var maximumInvalidId = GetMaximumInvalidId(end);
        var diff = GetDiff(minimalInvalidId.ToString().Length);

        for (var value = minimalInvalidId; value <= end && value <= maximumInvalidId; value += diff)
        {
            result += value;
        }


        return result;
    }

    private static ulong GetMinimalInvalidId(ulong value)
    {
        var startStr = value.ToString();

        int targetLength;
        if (startStr.Length % 2 != 0)
        {
            targetLength = startStr.Length + 1;
        }
        else
        {
            targetLength = startStr.Length;
        }

        var multiplier = (ulong)(targetLength / 2) - 1;
        var minInvalidId = Convert.ToUInt64(string.Concat(Enumerable.Repeat(Math.Pow(10, multiplier), 2)));

        if (minInvalidId >= value)
        {
            return minInvalidId;
        }

        var diff = GetDiff(targetLength);
        var targetMultiplier = value / diff;
        minInvalidId =  diff * targetMultiplier;

        if (minInvalidId < value)
        {
            return minInvalidId + diff;
        }

        return minInvalidId;
    }

    private static ulong GetMaximumInvalidId(ulong value)
    {
        var endStr = value.ToString();

        int targetLength;
        if (endStr.Length % 2 != 0)
        {
            targetLength = endStr.Length - 1;
        }
        else
        {
            targetLength = endStr.Length;
        }
        
        return Convert.ToUInt64(string.Concat(Enumerable.Repeat(9, targetLength)));
    }

    private static ulong GetDiff(int length)
    {
        var multiplier = (ulong)(length / 2);
        return (ulong)Math.Pow(10, multiplier) + 1;
    }
}