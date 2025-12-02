using _2025.Structure;

namespace _2025.Days.Day02;

public class Day2Part2 : Part<ulong>
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

    // private static ulong GetSumOfInvalidIdsInRange(ulong start, ulong end)
    // {
    //     var result = 0UL;
    //
    //     for (var i = start; i <= end; i++)
    //     {
    //         if (!ValidId(i))
    //         {
    //             result += i;
    //         }
    //     }
    //
    //     return result;
    // }


    private static bool ValidId(ulong id)
    {
        var idStr = id.ToString();

        for (var i = 1; i <= idStr.Length / 2; i++)
        {
            if (idStr.Length % i != 0)
            {
                continue;
            }

            var part = idStr[..i];
            if (string.Concat(Enumerable.Repeat(part, idStr.Length / i)) == idStr)
            {
                return false;
            }
        }

        return true;
    }

    private static ulong GetSumOfInvalidIdsInRange(ulong start, ulong end)
    {
        ulong result = 0;
        
        var checkedResults = new HashSet<ulong>();
        
        var minLength = start.ToString().Length;
        var maxLength = end.ToString().Length;

        for (var length = minLength; length <= maxLength; length++)
        {
            for (var i = 1; i <= length / 2; i++)
            {
                if (length % i != 0) continue;
                var repeats = length / i;

                if (repeats < 2) continue;

                var low = (long)Math.Pow(10, i - 1);
                var high = (long)Math.Pow(10, i) - 1;

                for (var prefix = low; prefix <= high; prefix++)
                {
                    var repeated = string.Concat(Enumerable.Repeat(prefix.ToString(), repeats));
                    var number = ulong.Parse(repeated);

                    if (number > end)
                    {
                        break;
                    }

                    if (number >= start && number <= end && checkedResults.Add(number))
                    {
                        result += number;
                    }
                }
            }
        }


        return result;
    }
}