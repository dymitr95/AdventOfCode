using System.Text.RegularExpressions;

namespace _2016.Day4;

public class Day4Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;
        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {
            result += DecodeRoomCode(row);
        }
        
        return result;
    }

    private static int DecodeRoomCode(string code)
    {
        
        var letters = new Dictionary<char, int>();
        
        var regex = new Regex(@"^(.*?)-(\d+)(\[.*\])$");
        var match = regex.Match(code);

        var id = Convert.ToInt32(match.Groups[2].Value);
        var iterations = id % 26;
        
        var roomCode = match.Groups[1].Value;
        roomCode = roomCode.Replace("-", " ");
        var newRoomCode = "";
        foreach (var letter in roomCode)
        {
            if (letter == ' ')
            {
                newRoomCode += letter;
                continue;
            }
            var newLetter = letter + iterations;
            if (newLetter > 122)
            {
                newLetter -= 26;
            }
            
            newRoomCode += (char)newLetter;
        }

        if (newRoomCode.Contains("northpole"))
        {
            return id;
        }
        
        
        return 0;
    }
    
}