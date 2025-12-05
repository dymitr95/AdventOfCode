using _2025.Structure;

namespace _2025.Days.Day05;

public class Day5Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");

        var ingredients = GetFreshIngredientsIds(rows);
        ingredients = ingredients.OrderBy(i => i.Min).ToList();
        
        var ingredientsWithoutOverlaps = new List<Range>();
        var currentRange = ingredients[0];
        
        for (var i = 1; i < ingredients.Count; i++)
        {
            var nextRange = ingredients[i];

            if (nextRange.Min <= currentRange.Max)
            {
                currentRange = currentRange with { Max = Math.Max(nextRange.Max, currentRange.Max) };
            }
            else
            {
                ingredientsWithoutOverlaps.Add(currentRange);
                currentRange = nextRange;
            }
        }
        
        ingredientsWithoutOverlaps.Add(currentRange);

        return ingredientsWithoutOverlaps.Sum(range => range.Max - range.Min + 1);
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