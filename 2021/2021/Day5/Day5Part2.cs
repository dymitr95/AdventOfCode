namespace _2021.Day5;

public class Day5Part2 : Part<int>
{
  public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var tunnels = new List<Tunnel>();
        
        PrepareTunnels(tunnels, rows);

        var commonPoints = new Dictionary<Point, int>();
        
        FindCommonPoints(commonPoints, tunnels);

        return commonPoints.Values.Count(value => value > 1);
    }

    private void FindCommonPoints(Dictionary<Point, int> commonPoints, List<Tunnel> tunnels)
    {
        foreach (var tunnel in tunnels)
        {

            if (tunnel.Start.X == tunnel.End.X)
            {
                if (tunnel.Start.Y > tunnel.End.Y)
                {
                    for (var i = tunnel.Start.Y; i >= tunnel.End.Y; i--)
                    {
                        AddPoint(commonPoints, tunnel.Start with { Y = i });
                    }
                }
                else
                {
                    for (var i = tunnel.Start.Y; i <= tunnel.End.Y; i++)
                    {
                        AddPoint(commonPoints, tunnel.Start with { Y = i });
                    }
                }
                
                
                continue;
            }
            
            if (tunnel.Start.Y == tunnel.End.Y)
            {
                if (tunnel.Start.X > tunnel.End.X)
                {
                    for (var i = tunnel.Start.X; i >= tunnel.End.X; i--)
                    {
                        AddPoint(commonPoints, tunnel.Start with { X = i });
                    }
                }
                else
                {
                    for (var i = tunnel.Start.X; i <= tunnel.End.X; i++)
                    {
                        AddPoint(commonPoints, tunnel.Start with { X = i });
                    }
                }
                
                continue;
            }
            
            FindCommonPointsDiagonal(commonPoints, tunnel);
        }
    }

    private void FindCommonPointsDiagonal(Dictionary<Point, int> commonPoints, Tunnel tunnel)
    {
        if (tunnel.Start.X < tunnel.End.X && tunnel.Start.Y < tunnel.End.Y)
        {
            var j = tunnel.Start.Y;
            for (var i = tunnel.Start.X; i <= tunnel.End.X; i++)
            {
                AddPoint(commonPoints, new Point(i, j));
                j++;
            }
            
            return;
        }
        
        if (tunnel.Start.X > tunnel.End.X && tunnel.Start.Y > tunnel.End.Y)
        {
            var j = tunnel.Start.Y;
            for (var i = tunnel.Start.X; i >= tunnel.End.X; i--)
            {
                AddPoint(commonPoints, new Point(i, j));
                j--;
            }
            
            return;
        }
        
        if (tunnel.Start.X > tunnel.End.X && tunnel.Start.Y < tunnel.End.Y)
        {
            var j = tunnel.Start.Y;
            for (var i = tunnel.Start.X; i >= tunnel.End.X; i--)
            {
                AddPoint(commonPoints, new Point(i, j));
                j++;
            }
            
            return;
        }
        
        if (tunnel.Start.X < tunnel.End.X && tunnel.Start.Y > tunnel.End.Y)
        {
            var j = tunnel.Start.Y;
            for (var i = tunnel.Start.X; i <= tunnel.End.X; i++)
            {
                AddPoint(commonPoints, new Point(i, j));
                j--;
            }
        }
    }

    private void AddPoint(Dictionary<Point, int> commonPoints, Point point)
    {
        if (!commonPoints.TryAdd(point, 1))
        {
            commonPoints[point] += 1;
        }
    }

    private void PrepareTunnels(List<Tunnel> tunnels, string[] rows)
    {
        foreach (var row in rows)
        {
            var points = row.Split(" -> ");
            var start = points[0].Split(',');
            var end = points[1].Split(',');
            
            var tunnel = new Tunnel(new Point(Convert.ToInt32(start[0]), Convert.ToInt32(start[1])),
                new Point(Convert.ToInt32(end[0]), Convert.ToInt32(end[1])));
            
            tunnels.Add(tunnel);
        }
    }
    
}