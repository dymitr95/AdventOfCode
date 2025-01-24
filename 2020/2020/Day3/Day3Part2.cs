namespace _2020.Day3;

public class Day3Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var res1 = ProcessSlope(rows, 1, 1);
        var res2 = ProcessSlope(rows, 3, 1);
        var res3 = ProcessSlope(rows, 5, 1);
        var res4 = ProcessSlope(rows, 7, 1);
        var res5 = ProcessSlope(rows, 1, 2);

        return res1 * res2 * res3 * res4 * res5;
    }

    private int ProcessSlope(string[] rows, int xChange, int yChange)
    {
        var result = 0;
        
        var x = xChange;
        
        for (var i = yChange; i < rows.Length; i += yChange)
        {
            if (x >= rows[0].Length)
            {
                x -= rows[0].Length;
            }

            if (rows[i][x] == '#')
            {
                result++;
            }

            x += xChange;
        }

        return result;
    }
}