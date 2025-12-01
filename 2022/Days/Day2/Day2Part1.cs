using _2022.Structure;

namespace _2022.Days.Day2;

public class Day2Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var games = input.Split("\r\n");

        foreach (var game in games)
        {
            var values = game.Split(" ");
            result += GetPoints(values[1]);
            result += GetGameResult(values[0], values[1]);
        }

        return result;
    }


    private int GetGameResult(string value1, string value2)
    {
        if (Convert.ToInt32(value1[0]) + 23 == value2[0])
        {
            return 3;
        }
        
        switch (value1)
        {
            case "A" when value2 == "Y":
            case "B" when value2 == "Z":
            case "C" when value2 == "X":
                return 6;
            default:
                return 0;
        }
    }


    private int GetPoints(string value)
    {
        return value switch
        {
            "X" => 1,
            "Y" => 2,
            "Z" => 3,
            _ => 0
        };
    }
}