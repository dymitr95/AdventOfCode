using _2022.Structure;

namespace _2022.Days.Day2;

public class Day2Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var games = input.Split("\r\n");

        foreach (var game in games)
        {
            var values = game.Split(" ");
            result += GetGameResult(values[1]);
            result += GetPoints(values[0], values[1]);
        }

        return result;
    }


    private int GetPoints(string value1, string value2)
    {
        switch (value2)
        {
            case "X":
                switch (value1)
                {
                    case "A":
                        return 3;
                    case "B":
                        return 1;
                    case "C":
                        return 2;
                }

                break;
            case "Y":
                switch (value1)
                {
                    case "A":
                        return 1;
                    case "B":
                        return 2;
                    case "C":
                        return 3;
                }

                break;
            case "Z":
                switch (value1)
                {
                    case "A":
                        return 2;
                    case "B":
                        return 3;
                    case "C":
                        return 1;
                }

                break;
        }

        return 0;
    }


    private int GetGameResult(string value)
    {
        return value switch
        {
            "X" => 0,
            "Y" => 3,
            "Z" => 6,
            _ => 0
        };
    }
}