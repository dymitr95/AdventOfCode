using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day08;

public class Day8Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");

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

        var currentDistanceIndex = -1;
        List<JunctionBox> currentBoxesPair;
        
        do
        {
            currentDistanceIndex++;
            var closestBoxes = distances[currentDistanceIndex].Boxes;
            currentBoxesPair = closestBoxes;

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
        } while (connections[0].Boxes.Count < boxes.Count);

        
        return  currentBoxesPair[0].Coord.X * (long)currentBoxesPair[1].Coord.X;
    }

    private static double CalculateDistance(Coord point1, Coord point2)
    {
        return Math.Sqrt(Math.Pow(point1.X - point2.X, 2) + Math.Pow(point1.Y - point2.Y, 2) +
                         Math.Pow(point1.Z - point2.Z, 2));
    }
}