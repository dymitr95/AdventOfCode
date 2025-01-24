namespace _2017.Day1;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var nextIndex = i + 1;
            if (i == input.Length - 1)
            {
                nextIndex = 0;
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