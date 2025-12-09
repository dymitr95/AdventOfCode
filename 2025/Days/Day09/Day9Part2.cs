using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day09;

public class Day9Part2 : Part<long>
{
    public override long Run(string input)
    {
        var maxArea = 0L;


        var rows = input.Split("\r\n");

        var redTiles = rows.Select(row => row.Split(","))
            .Select(data => new Point(long.Parse(data[0]), long.Parse(data[1]))).ToList();

        redTiles = redTiles.OrderBy(p => p.X).ThenBy(p => p.Y).ToList();

        var border = new HashSet<Point>();

        var currentTail = redTiles[0];
        var step = 0;
        
        while (true)
        {
            if (currentTail == redTiles[0] && step != 0)
            {
                break;
            }
            
            Point nextTail;
            if (step % 2 == 0)
            {
                nextTail = redTiles.First(p => p.Y == currentTail.Y && p.X != currentTail.X);
                var minX = Math.Min(currentTail.X, nextTail.X);
                var maxX = Math.Max(currentTail.X, nextTail.X);
                for (var i = minX + 1; i < maxX; i++)
                {
                    border.Add(currentTail with { X = i });
                }
            }
            else
            {
                nextTail = redTiles.First(p => p.X == currentTail.X && p.Y != currentTail.Y);
                var minY = Math.Min(currentTail.Y, nextTail.Y);
                var maxY = Math.Max(currentTail.Y, nextTail.Y);
                for (var i = minY + 1; i < maxY; i++)
                {
                    border.Add(currentTail with { Y = i });
                }
            }

            currentTail = nextTail;
    
            step++;
        }

        foreach (var point in redTiles)
        {
            border.Add(point);
        }

        var points = new Dictionary<long, Range>();
        var orderedBorderPoints = border.OrderBy(p => p.Y).ThenBy(p => p.X).GroupBy(p => p.Y).ToList();

        foreach (var point in orderedBorderPoints)
        {
            var min = point.Min(p => p.X);
            var max = point.Max(p => p.X);
            points.Add(point.Key, new Range(min, max));
        }
        
        for (var i = 0; i < redTiles.Count; i++)
        {
            for (var j = i + 1; j < redTiles.Count; j++)
            {
                var area = (Math.Abs(redTiles[i].X - redTiles[j].X) + 1) * (Math.Abs(redTiles[i].Y - redTiles[j].Y) + 1);
                
                if (area <= maxArea)
                {
                    continue;
                }

                var corner1 = redTiles[i];
                var corner2 = redTiles[j];

                var corner3 = new Point(corner1.X, corner2.Y);
                var corner4 = new Point(corner2.X, corner1.Y);
                if (points[corner3.Y].Max >= corner3.X && points[corner3.Y].Min <= corner3.X)
                {
                    if (points[corner4.Y].Max >= corner4.X && points[corner4.Y].Min <= corner4.X)
                    {
                        var point1 = points[corner3.Y];
                        var point2 = points[corner4.Y];
                        
                        if (area == 2770359740)
                        {
                            var a = 1;
                        }
                        maxArea = area;
                    }
                }  
            }
        }
        
        
        return maxArea;
    }
    
}

public record Range(long Min, long Max);