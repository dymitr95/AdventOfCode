namespace _2018.Day2;

public class Day2Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var twos = 0;
        var threes = 0;
        foreach (var row in rows)
        {
            if (row.Where(char.IsLetter).GroupBy(char.ToLower).Any(g => g.Count() == 2))
            {
                twos++;
            }
            if (row.Where(char.IsLetter).GroupBy(char.ToLower).Any(g => g.Count() == 3))
            {
                threes++;
            }
        }


        return twos * threes;
    }
}