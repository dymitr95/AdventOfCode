namespace _2019.Day3;

public class Day3Part2 : Part<int>
{
    private record Point(int X, int Y);

    private Dictionary<Point, int> Points = new();
    private Dictionary<Point, int> PointsSteps = new();
    
    public override int Run(string input)
    {
        var result = 0;
        var steps = 0;

        var rows = input.Split("\r\n");

        GetWirePoints(rows[0]);
        GetWirePoints(rows[1]);
        
        foreach (var point in Points.Keys)
        {
            if (point.X < 0 || point.Y < 0)
            {
                continue;
            }
            
            if (Points[point] == 1)
            {
                continue;
            }
        
            var distance = point.X + point.Y;
            if (distance < result || result == 0)
            {
                result = distance;
                
            }
        }

        return result;
    }

    private void GetWirePoints(string row)
    {
        var steps = row.Split(',');
        var lastPoint = new Point(0, 0);
        var wireSteps = 0;
        
        foreach (var step in steps)
        {
            var direction = step[..1];
            var stepsCount = Convert.ToInt32(step[1..]);
            switch (direction)
            {
                case "R":
                    for (var i = 0; i < stepsCount; i++)
                    {
                        wireSteps++;
                        lastPoint = lastPoint with { X = lastPoint.X + 1 };
                        if (!Points.TryAdd(lastPoint, 1))
                        {
                            Points[lastPoint] += 1;
                            PointsSteps[lastPoint] = wireSteps;
                        }
                        else
                        {
                            PointsSteps.Add(lastPoint, wireSteps);
                        }
                    }
                    break;
                case "L":
                    for (var i = 0; i < stepsCount; i++)
                    {
                        wireSteps++;
                        lastPoint = lastPoint with { X = lastPoint.X - 1 };
                        if (!Points.TryAdd(lastPoint, 1))
                        {
                            Points[lastPoint] += 1;
                            PointsSteps[lastPoint] = wireSteps;
                        }
                        else
                        {
                            PointsSteps.Add(lastPoint, wireSteps);
                        }
                    }
                    break;
                case "U":
                    for (var i = 0; i < stepsCount; i++)
                    {
                        wireSteps++;
                        lastPoint = lastPoint with { Y = lastPoint.Y + 1 };
                        if (!Points.TryAdd(lastPoint, 1))
                        {
                            Points[lastPoint] += 1;
                            PointsSteps[lastPoint] = wireSteps;
                        }
                        else
                        {
                            PointsSteps.Add(lastPoint, wireSteps);
                        }
                    }
                    break;
                case "D":
                    for (var i = 0; i < stepsCount; i++)
                    {
                        wireSteps++;
                        lastPoint = lastPoint with { Y = lastPoint.Y - 1 };
                        if (!Points.TryAdd(lastPoint, 1))
                        {
                            Points[lastPoint] += 1;
                            PointsSteps[lastPoint] = wireSteps;
                        }
                        else
                        {
                            PointsSteps.Add(lastPoint, wireSteps);
                        }
                    }
                    break;
            }
        }
    } 
}