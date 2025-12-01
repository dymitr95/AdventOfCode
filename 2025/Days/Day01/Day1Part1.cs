using _2025.Structure;

namespace _2025.Days.Day01;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var result = 0;
        var pointer = 50;
        
        foreach (var row in rows)
        {
            var direction = row[0];
            var number = Convert.ToInt32(row[1..]);
            number %= 100;
            
            if (direction == 'R')
            {
                pointer += number;
                if (pointer > 99)
                {
                    pointer %= 100;
                }
            }
            else
            {
                pointer -= number;
                if (pointer < 0)
                {
                    pointer += 100;
                }
            }

            if (pointer == 0)
            {
                result++;
            }
            
        }
        
        return result;
    }
}