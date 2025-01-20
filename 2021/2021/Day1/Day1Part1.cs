namespace _2021.Day1;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var numbers = input.Split("\r\n");

        for (var i = 1; i < numbers.Length; i++)
        {
            if (Convert.ToInt32(numbers[i]) > Convert.ToInt32(numbers[i - 1]))
            {
                result++;
            }
        }
        
        return result;
    }
}