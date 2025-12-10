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


        var border = GetBorder(redTiles);

        for (var i = 0; i < redTiles.Count; i++)
        {
            for (var j = i + 1; j < redTiles.Count; j++)
            {
                var corner1 = redTiles[i];
                var corner2 = redTiles[j];

                var area = (Math.Abs(corner1.X - corner2.X) + 1) * (Math.Abs(corner1.Y - corner2.Y) + 1);
                if (area <= maxArea)
                {
                    continue;
                }
                
                if (!border.Any(line => line.Intersects(corner1, corner2)))
                {
                    maxArea = area;
                }
            }
        }


        return maxArea;
    }

    private static Line[] GetBorder(List<Point> vertices)
    {
        var lines = new Line[vertices.Count];
        for (var i = 0; i < vertices.Count - 1; i++)
        {
            lines[i] = new Line(vertices[i], vertices[i + 1]);
        }
        lines[^1] = new Line(vertices[^1], vertices[0]);
    
        return lines;
    }
}

internal readonly record struct Line(Point Start, Point End)
{
    public bool Intersects(Point pointA, Point pointB)
    {
        var minX = Math.Min(pointA.X, pointB.X);
        var maxX = Math.Max(pointA.X, pointB.X);
        var minY = Math.Min(pointA.Y, pointB.Y);
        var maxY = Math.Max(pointA.Y, pointB.Y);
 
        var segMinX = Math.Min(Start.X, End.X);
        var segMaxX = Math.Max(Start.X, End.X);
        var segMinY = Math.Min(Start.Y, End.Y);
        var segMaxY = Math.Max(Start.Y, End.Y);
 
        return segMaxX > minX && segMinX < maxX && segMaxY > minY && segMinY < maxY;
    }
}