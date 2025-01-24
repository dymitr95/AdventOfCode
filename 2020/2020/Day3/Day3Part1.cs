namespace _2020.Day3;

public class Day3Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var x = 3;
        
        for (var i = 1; i < rows.Length - 1; i++)
        {
            if (x >= rows[0].Length)
            {
                x %= rows[0].Length;
            }

            if (rows[i][x] == '#')
            {
                result++;
            }

            x += 3;
        }

        return result + 1;
    }
}