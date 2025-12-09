using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day09;

public class Day9Part1 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");

        var points = rows.Select(row => row.Split(",")).Select(data => new Point(long.Parse(data[0]), long.Parse(data[1]))).ToList();

        var maxArea = 0L;
        
        for (var i = 0; i < points.Count; i++)
        {
            for (var j = i + 1; j < points.Count; j++)
            {
                var area = (Math.Abs(points[i].X - points[j].X) + 1) * (Math.Abs(points[i].Y - points[j].Y) + 1);

                if (area > maxArea)
                {
                    maxArea = area;
                }
            }
        }

        return maxArea;
    }
    
}

public record Point(long X, long Y);