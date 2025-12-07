using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day07;

public class Day7Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0;

        var map = PrepareMap(rows);
        var startPoint = FindStartPoint(map);
        var visitedPoints = new HashSet<Point>();

        result = CountSplits(startPoint!, visitedPoints, map);

        return result;
    }

    private static int CountSplits(Point point, HashSet<Point> visitedPoints, string[][] map)
    {
        

        if (point.Y == map.Length || !visitedPoints.Add(point))
        {
            return 0;
        }

        if (map[point.Y][point.X] != "^")
        {
            return CountSplits(point with { Y = point.Y + 2 }, visitedPoints, map);
        }

        var splits = 1;

        var leftPoint = new Point(point.X - 1, point.Y + 2);
        var rightPoint = new Point(point.X + 1, point.Y + 2);


        splits += CountSplits(leftPoint, visitedPoints, map);

        splits += CountSplits(rightPoint, visitedPoints, map);

        return splits;
    }


    private static string[][] PrepareMap(string[] rows)
    {
        var map = new string[rows.Length][];

        for (var i = 0; i < rows.Length; i++)
        {
            map[i] = rows[i].ToCharArray().Select(c => c.ToString()).ToArray();
        }

        return map;
    }

    private static Point? FindStartPoint(string[][] map)
    {
        for (var i = 0; i < map[0].Length; i++)
        {
            if (map[0][i] == "S")
            {
                return new Point(i, 2);
            }
        }

        return null;
    }
}

public record Point(int X, int Y);