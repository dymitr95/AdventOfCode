namespace _2017.Day4;

public class Day4Part1 : Part<int>
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
                if (checkedWords.Contains(word))
                {
                    isValid = false;
                    break;
                }
                checkedWords.Add(word);
            }

            if (isValid)
            {
                validPasswords++;
            }
        }

        return validPasswords;
    }
    
}