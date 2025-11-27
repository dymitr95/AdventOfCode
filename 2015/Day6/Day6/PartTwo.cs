using System.Text.RegularExpressions;

namespace Day6;

public class PartTwo
{
    public int Run(string input)
    {
        var rows = input.Split("\r\n");

        var lights = new int[1000][];
        for (var i = 0; i < lights.Length; i++)
        {
            lights[i] = new int[1000];
        }

        foreach (var row in rows)
        {
            var parts = ParseInput(row);
            var mode = parts[0].Trim();

            var startPos = parts[1].Trim();
            var startX = Convert.ToInt32(startPos.Split(",")[0]);
            var startY = Convert.ToInt32(startPos.Split(",")[1]);

            var endPos = parts[3].Trim();
            var endX = Convert.ToInt32(endPos.Split(",")[0]);
            var endY = Convert.ToInt32(endPos.Split(",")[1]);

            switch (mode)
            {
                case "toggle":
                    Toggle(lights, startX, startY, endX, endY);
                    break;
                case "turn on":
                    TurnOn(lights, startX, startY, endX, endY);
                    break;
                case "turn off":
                    TurnOff(lights, startX, startY, endX, endY);
                    break;
            }
        }

        return lights.Sum(t => t.Sum());
    }

    private static string[] ParseInput(string row)
    {
        var pattern = @"(\d+,\d+)";
        var parts = Regex.Split(row, pattern);
        return parts;
    }

    private static void TurnOn(int[][] lights, int startX, int startY, int endX, int endY)
    {
        for (var i = startY; i <= endY; i++)
        {
            for (var j = startX; j <= endX; j++)
            {
                lights[j][i] += 1;
            }
        }
    }

    private static void TurnOff(int[][] lights, int startX, int startY, int endX, int endY)
    {
        for (var i = startY; i <= endY; i++)
        {
            for (var j = startX; j <= endX; j++)
            {
                if(lights[j][i] == 0) continue;
                lights[j][i] -= 1;
            }
        }
    }

    private static void Toggle(int[][] lights, int startX, int startY, int endX, int endY)
    {
        for (var i = startY; i <= endY; i++)
        {
            for (var j = startX; j <= endX; j++)
            {
                lights[j][i] += 2;
            }
        }
    }
}