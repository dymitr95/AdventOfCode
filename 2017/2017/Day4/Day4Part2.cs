namespace _2017.Day4;

public class Day4Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = CountValidPassphrases(rows);
        return result;
    }

    private static int CountValidPassphrases(string[] rows)
    {
        var validPasswords = 0;

        foreach (var row in rows)
        {
            var checkedWords = new List<string>();
            var words = row.Split(" ");
            var isValid = true;
            foreach (var word in words)
            {
                var sortedWord = new string(word.OrderBy(c => c).ToArray());
                if (checkedWords.Contains(sortedWord))
                {
                    isValid = false;
                    break;
                }
                checkedWords.Add(sortedWord);
            }

            if (isValid)
            {
                validPasswords++;
            }
        }

        return validPasswords;
    }
    
}