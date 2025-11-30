using _2017.Structure;

namespace _2017.Days.Day6;

public class Day6Part2 : Part<int>
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
            var nextIndex = index + values[index];
            
            if (nextIndex >= values.Length || nextIndex < 0)
            {
                break;
            }
            
            if (values[index] >= 3)
            {
                values[index] -= 1;
            }
            else
            {
                values[index] += 1;
            }

            index = nextIndex;
            jumps++;
        }
        
        return jumps + 1;
    }
    
    
}