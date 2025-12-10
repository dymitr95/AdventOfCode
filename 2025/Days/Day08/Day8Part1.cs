using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day08;

public class Day8Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        const int iterationsCount = 1000;

        var boxes = rows.Select(row => row.Split(",")).Select(data =>
            new JunctionBox(-1, new Coord(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2])))).ToList();

        var boxes2 = new List<JunctionBox>(boxes);

        var distances = new List<Distance>();

        foreach (var box1 in boxes)
        {
            foreach (var box2 in boxes2)
            {
                if (box1 == box2)
                {
                    continue;
                }

                var distance = CalculateDistance(box1.Coord, box2.Coord);
                distances.Add(new Distance([box1, box2], distance));
            }

            boxes2.Remove(box1);
        }

        distances = distances.OrderBy(d => d.ConnDistance).ToList();

        var connections = new List<Connection>();

        for (var i = 0; i < iterationsCount; i++)
        {
            var closestBoxes = distances[i].Boxes;

            var conn1 = connections.FirstOrDefault(c => c.Boxes.Contains(closestBoxes[0]));
            var conn2 = connections.FirstOrDefault(c => c.Boxes.Contains(closestBoxes[1]));

            if (conn1 == null && conn2 == null)
            {
                var newConn = new Connection();
                newConn.AddBoxes(closestBoxes);
                connections.Add(newConn);
                continue;
            }

            if (conn1 == conn2)
            {
                continue;
            }

            if (conn1 == null && conn2 != null)
            {
                conn2.Boxes.Add(closestBoxes[0]);
            }
            else if (conn2 == null && conn1 != null)
            {
                conn1.Boxes.Add(closestBoxes[1]);
            }
            else
            {
                conn1!.AddBoxes(conn2!.Boxes.ToList());
                connections.Remove(conn2);
            }
        }

        var res = connections.OrderBy(c => c.Boxes.Count).TakeLast(3);
        var result = res.Aggregate(1, (current, conn) => current * conn.Boxes.Count);

        return result;
    }

    private static double CalculateDistance(Coord point1, Coord point2)
    {
        return ((double)point1.X - point2.X) * ((double)point1.X - point2.X) + ((double)point1.Y - point2.Y) * ((double)point1.Y - point2.Y) +
               ((double)point1.Z - point2.Z) * ((double)point1.Z - point2.Z);
    }
}

public class Connection()
{
    public HashSet<JunctionBox> Boxes { get; set; } = [];

    public void AddBoxes(List<JunctionBox> boxes)
    {
        foreach (var box in boxes)
        {
            Boxes.Add(box);
        }
    }
}

public class JunctionBox(int id, Coord coord)
{
    public int Id { get; set; } = id;
    public Coord Coord { get; set; } = coord;
}

public record Distance(List<JunctionBox> Boxes, double ConnDistance);

public record Coord(int X, int Y, int Z);