namespace _2018.Day1;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {
            var numb = Convert.ToInt32(row);
            result += numb;
        }

        return result;
    }
}