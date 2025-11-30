using _2017.Structure;

namespace _2017.Days.Day1;

public class Day1Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var nextIndex = i + input.Length / 2;
            if (nextIndex > input.Length - 1)
            {
                nextIndex -= input.Length;
            }
            var numb = Convert.ToInt32(input[i].ToString());
            var nextNumb = Convert.ToInt32(input[nextIndex].ToString());
            if (numb == nextNumb)
            {
                result += numb;
            }
        }

        return result;
    }
}