using _2025.Structure;

namespace _2025.Days.Day05;

public class Day5Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0L;

        var ingredients = GetFreshIngredientsIds(rows);
        var ingredientsWithoutOverlaps = new List<Range>();

        foreach (var range in ingredients)
        {
            var rangeWithoutOverlaps = GetRangeWithoutOverlaps(ingredientsWithoutOverlaps, range);
            if (rangeWithoutOverlaps.Max != -1)
            {
                ingredientsWithoutOverlaps.Add(rangeWithoutOverlaps);
            }
        }

        foreach (var range in ingredientsWithoutOverlaps)
        {
            if (ingredientsWithoutOverlaps.FirstOrDefault(r => r.Min < range.Min && r.Max > range.Max) != null)
            {
                continue;
            }
            
            result += range.Max - range.Min + 1;
        }
        
        return result;
    }

    private static List<Range> GetFreshIngredientsIds(string[] rows)
    {
        var res = new List<Range>();

        foreach (var row in rows)
        {
            if (row == "")
            {
                return res;
            }

            var data = row.Split("-");
            var start = long.Parse(data[0]);
            var end = long.Parse(data[1]);
            
            res.Add(new Range(start, end));
        }

        return res;
    }


    private static Range GetRangeWithoutOverlaps(List<Range> ranges, Range range)
    {
        foreach (var knownRange in ranges)
        {
            range = InMinRange(range, knownRange);
            range = InMaxRange(range, knownRange);
        }

        return range.Max < range.Min ? new Range(-1,-1) : range;
    }


    private static Range InMinRange(Range range, Range targetRange)
    {
        if (targetRange.Min <= range.Min && targetRange.Max >= range.Min)
        {
            range = range with { Min = targetRange.Max + 1 };
        }

        return range;
    }
    
    private static Range InMaxRange(Range range, Range targetRange)
    {
        if (targetRange.Max >= range.Max && targetRange.Min <= range.Max)
        {
            range = range with { Max = targetRange.Min - 1 };
        }

        return range;
    }
    
}