namespace _2018.Day6;

public class Day6Part1 : Part<int>
{
    public override int Run(string input)
    {
        
        var rows = input.Split("\r\n");
        var points = ProcessInput(rows);
        
        var farthestPoint = GetFarthestPointFromStart(points);

        var grid = FillGrid(points, farthestPoint);
        var finiteCoordinates = RemoveInfiniteCoordinates(points, grid);

        var maxClosestLocations = finiteCoordinates.Select(point => CountClosetsLocations(point.Id, grid)).Prepend(0).Max();

        return maxClosestLocations;
    }


    private static List<Point> ProcessInput(string[] rows)
    {
        var points = new List<Point>();
        var id = 1;
        
        foreach (var row in rows)
        {
            var values = row.Split(", ");
            var x = Convert.ToInt32(values[0]);
            var y = Convert.ToInt32(values[1]);
            
            points.Add(new Point(id, x, y));
            id++;
        }

        return points;
    }

    private static int[][] FillGrid(List<Point> points, Point farthestPoint)
    {
        var grid = new int[farthestPoint.Y + 1][];

        for (var i = 0; i < grid.Length; i++)
        {
            grid[i] = new int[farthestPoint.X + 1];

            for (var j = 0; j < grid[i].Length; j++)
            {
                var nearestPoints = GetNearestPoints(points, j, i);
                if (nearestPoints.Count > 1)
                {
                    grid[i][j] = 0;
                }
                else
                {
                    grid[i][j] = nearestPoints[0];
                }
            }
        }
        
        return grid;
    }
    
    private static Point GetFarthestPointFromStart(List<Point> points)
    {
        return points.OrderByDescending(p => p.X * p.X + p.Y * p.Y).First();
    }

    private static List<int> GetNearestPoints(List<Point> points, int x, int y)
    {
        var distances = new Dictionary<int, List<int>>();
        
        foreach (var point in points)
        {
            var distance = Math.Abs(point.X - x) + Math.Abs(point.Y - y);
            if (!distances.TryAdd(distance, [point.Id]))
            {
                distances[distance].Add(point.Id);
            }
        }
        
        return distances.OrderBy(kv => kv.Key).First().Value;
    }

    private static List<Point> RemoveInfiniteCoordinates(List<Point> points, int[][] grid)
    {
        var finitePoints = new List<Point>(points);

        for (var j = 0; j < grid[0].Length; j++)
        {
            var pointId = grid[0][j];
            var point = finitePoints.FirstOrDefault(p => p.Id == pointId);
            if (point.Id != 0)
            {
                finitePoints.Remove(point);
            }
        }
        
        for (var i = 0; i < grid.Length; i++)
        {
            var pointId = grid[i][0];
            var point = finitePoints.FirstOrDefault(p => p.Id == pointId);
            if (point.Id != 0)
            {
                finitePoints.Remove(point);
            }
        }
        
        for (var j = 0; j < grid[0].Length; j++)
        {
            var pointId = grid[^1][j];
            var point = finitePoints.FirstOrDefault(p => p.Id == pointId);
            if (point.Id != 0)
            {
                finitePoints.Remove(point);
            }
        }
        
        for (var i = 0; i < grid.Length; i++)
        {
            var pointId = grid[i][^1];
            var point = finitePoints.FirstOrDefault(p => p.Id == pointId);
            if (point.Id != 0)
            {
                finitePoints.Remove(point);
            }
        }

        return finitePoints;
    }

    private static int CountClosetsLocations(int pointId, int[][] grid)
    {
        return grid.Sum(t => t.Count(t1 => t1 == pointId));
    }
    
}