using _2021.Structure;

namespace _2021.Days.Day5;

public class Day5Part1 : Part<int>
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

public record Tunnel(Point Start, Point End);
public record Point(int X, int Y);