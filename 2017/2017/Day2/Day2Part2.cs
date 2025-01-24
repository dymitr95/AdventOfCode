namespace _2017.Day2;

public class Day2Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");
        foreach (var row in rows)
        {
            var numbers = row.Split("\t");
            var list = numbers.Select(numb => Convert.ToInt32(numb)).ToList();
            list.Sort();
            result += GetDivisionResult(list);
        }


        return result;
    }


    private int GetDivisionResult(List<int> list)
    {
        var output = 0;
        for (var i = list.Count - 1; i >= 0; i--)
        {
            for (var j = 0; j < list.Count; j++)
            {
                if (i == j)
                {
                    continue;
                }

                if (list[i] % list[j] != 0) continue;
                output += list[i] / list[j];
                return output;
            }
        }

        return output;
    }
}