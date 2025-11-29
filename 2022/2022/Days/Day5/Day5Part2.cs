using _2022.Structure;

namespace _2022.Days.Day5;

public class Day5Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");
        foreach (var row in rows)
        {
            var data = row.Split(",");
            var firstArea = data[0].Split("-");
            var secondArea = data[1].Split("-");

            var startOne = Convert.ToInt32(firstArea[0]);
            var endOne = Convert.ToInt32(firstArea[1]);

            var startTwo = Convert.ToInt32(secondArea[0]);
            var endTwo = Convert.ToInt32(secondArea[1]);

            if (startTwo >= startOne && startTwo <= endOne)
            {
                result++;
            }
            else if (startOne >= startTwo && startOne <= endTwo)
            {
                result++;
            }
        }

        return result;
    }
}