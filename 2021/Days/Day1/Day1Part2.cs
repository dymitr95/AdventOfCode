using _2021.Structure;

namespace _2021.Days.Day1;

public class Day1Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var numbers = input.Split("\r\n");

        for (var i = 0; i < numbers.Length - 3; i++)
        {
            var firstWindow = Convert.ToInt32(numbers[i]) + Convert.ToInt32(numbers[i + 1]) +
                              Convert.ToInt32(numbers[i + 2]);
            var secondWindow = Convert.ToInt32(numbers[i + 1]) + Convert.ToInt32(numbers[i + 2]) +
                               Convert.ToInt32(numbers[i + 3]);
            if (secondWindow > firstWindow)
            {
                result++;
            }
        }
        
        return result;
    }
}