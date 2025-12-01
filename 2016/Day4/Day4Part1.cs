using System.Text.RegularExpressions;

namespace _2016.Day4;

public class Day4Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;
        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {
            result += CheckRoom(row);
        }
        
        return result;
    }

    private static int CheckRoom(string code)
    {
        
        var letters = new Dictionary<char, int>();
        
        var regex = new Regex(@"^(.*?)-(\d+)(\[.*\])$");
        var match = regex.Match(code);

        var id = Convert.ToInt32(match.Groups[2].Value);
        
        var roomCode = match.Groups[1].Value;
        roomCode = roomCode.Replace("-", "");
        foreach (var letter in roomCode.Where(letter => !letters.TryAdd(letter, 1)))
        {
            letters[letter] += 1;
        }

        var roomCodeHash = match.Groups[3].Value.Replace("[", "").Replace("]", "");

        letters = letters.OrderByDescending(kv => kv.Value).ThenBy(kv => kv.Key).ToDictionary();
        if (letters.Count < 5)
        {
            return 0;
        }

        var goodHash = string.Join("", letters.Keys.Take(5));

        if (goodHash != roomCodeHash)
        {
            return 0;
        }
        
        return id;
    }
    
}