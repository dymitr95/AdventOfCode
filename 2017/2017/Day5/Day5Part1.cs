namespace _2017.Day5;

public class Day5Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var values = rows.Select(r => Convert.ToInt32(r)).ToArray();

        var result = CountJumps(values);
        
        return result;
    }


    private static int CountJumps(int[] values)
    {
        var jumps = 0;
        var index = 0;

        while (true)
        {
            values[index] += 1;
            jumps++;
            if (values[index] - 1 + index >= values.Length)
            {
                break;
            }

            index += values[index] - 1;
        }
        
        return jumps;
    }
    
    
}