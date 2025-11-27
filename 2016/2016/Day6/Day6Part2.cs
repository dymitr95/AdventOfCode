using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _2016.Day6;

public class Day6Part2 : Part<string>
{
    public override string Run(string input)
    {
        var result = "";
        
        var rows = input.Split("\r\n");

        result = RecoverMessage(rows);
        
        return result;
    }

    private static string RecoverMessage(string[] rows)
    {
        var message = "";
        
        for (var i = 0; i < rows[0].Length; i++)
        {
            var letters = new Dictionary<char, int>();
            for (var j = 0; j < rows.Length; j++)
            {
                var letter = rows[j][i];
                if (!letters.TryAdd(letter, 1))
                {
                    letters[letter] += 1;
                }
            }

            message += letters.OrderBy(kv => kv.Value).FirstOrDefault().Key;
        }

        return message;
    }
    
}