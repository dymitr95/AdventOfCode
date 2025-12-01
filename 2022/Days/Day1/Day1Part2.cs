using _2022.Structure;

namespace _2022.Days.Day1;

public class Day1Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var results = new List<int>();
        var temp = 0;
        foreach (var row in rows)
        {
            if (row == "")
            {
                results.Add(temp);
                temp = 0;
                continue;
            }

            temp += Convert.ToInt32(row);
        }

        results = results.OrderByDescending(v => v).ToList();

        return results[0] + results[1] + results[2];
    }
}

