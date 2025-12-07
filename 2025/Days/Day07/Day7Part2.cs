using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day07;

public class Day7Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0L;

        var map = PrepareMap(rows);
        var startPoint = FindStartPoint(map);
        var visitedPoints = new Dictionary<Point, long>();

        result = CountTimelines(startPoint!, visitedPoints, map);
        
        return result;
    }

    private static long CountTimelines(Point point, Dictionary<Point, long> visitedPoints, string[][] map)
    {
        if (visitedPoints.TryGetValue(point, out var timelinesCount))
        {
            return timelinesCount;
        }
        
        if (point.Y == map.Length)
        {
            return 1;
        }
        
        if (map[point.Y][point.X] != "^")
        {
            return CountTimelines(point with { Y = point.Y + 2 }, visitedPoints, map);
        }
        
        var leftPoint = new Point(point.X - 1, point.Y + 2);
        var rightPoint = new Point(point.X + 1, point.Y + 2);

        var leftTimelinesCount = CountTimelines(leftPoint, visitedPoints, map);
        var rightTimelinesCount = CountTimelines(rightPoint, visitedPoints, map);

        var timelines = leftTimelinesCount + rightTimelinesCount;

        visitedPoints.Add(point, timelines);
        
        return timelines;
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