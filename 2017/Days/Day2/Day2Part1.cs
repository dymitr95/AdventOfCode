using _2017.Structure;

namespace _2017.Days.Day2;

public class Day2Part1 : Part<int>
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
            result += list[^1] - list[0];
        }


        return result;
    }
    
}