using System.Text.RegularExpressions;

namespace Day5;

public class PartTwo
{
    public int Run(string input)
    {
        var result = 0;

        var words = input.Split("\r\n");

        foreach (var word in words)
        {
            if (!HasLetterBetween(word))
            {
                continue;
            }

            if (!HasPairOfTwo(word))
            {
                continue;
            }

            result++;
        }

        return result;
    }


    private bool HasPairOfTwo(string input)
    {
        var pattern = @"(\w\w).*\1";
        return Regex.Match(input, pattern).Success;
    }

    private bool HasLetterBetween(string input)
    {
        const string pattern = @"(\w).\1";
        return Regex.Match(input, pattern).Success;
    }
}