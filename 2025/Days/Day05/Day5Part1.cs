using _2025.Structure;

namespace _2025.Days.Day05;

public class Day5Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0;

        var ingredients = GetFreshIngredientsIds(rows);
        
        foreach(var row in rows)
        {
            if (row.Contains('-') || row == "")
            {
                continue;
            }

            var ingredient = long.Parse(row);
            if (ingredients.FirstOrDefault(r => r.Min <= ingredient && r.Max >= ingredient) != null)
            {
                result++;
            }
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
    
}

public record Range(long Min, long Max);