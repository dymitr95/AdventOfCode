using System.Text.RegularExpressions;

namespace Day5;

public class PartOne
{


    public int Run(string input)
    {
        var result = 0;

        var words = input.Split("\r\n");

        foreach (var word in words)
        {
            if (!ContainsMinThreeVowels(word))
            {
                continue;
            }

            if (!HasDoubleLetter(word))
            {
                continue;
            }

            if (ContainsForbiddenCharacters(word))
            {
                continue;
            }

            result++;
        }

        return result;
    }


    private bool ContainsMinThreeVowels(string input)
    {
        return input.ToLower().Count(c => "aeiou".Contains(c)) >= 3;
    }


    private bool HasDoubleLetter(string input)
    {
        const string pattern = @"(\w)\1";
        return Regex.Match(input, pattern).Success;
    }

    private bool ContainsForbiddenCharacters(string input)
    {
        const string pattern = @"ab|cd|pq|xy";
        return Regex.Match(input, pattern).Success;
    }
    
}