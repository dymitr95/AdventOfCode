using _2025.Structure;

namespace _2025.Days.Day12;

public class Day12Part1 : Part<int>
{
    public override int Run(string input)
    {
        var (shapes, regions) = ParseInput(input);
        var solvableCount = 0;

        foreach (var (maxCells, dict) in regions)
        {
            var cellsNeeded = dict.Keys.Sum(shapeId => shapes[shapeId] * dict[shapeId]);

            if (maxCells >= cellsNeeded)
            {
                solvableCount++;
            }

        }

        return solvableCount;
    }

    private static (Dictionary<int, int>, List<(int, Dictionary<int,int>)>) ParseInput(string input)
    {
        var lines = input.Split('\n').Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToList();
        var shapes = new Dictionary<int, int>();
        var regions = new List<(int, Dictionary<int, int>)>();

        var i = 0;
        while (i < lines.Count)
        {
            if (lines[i].Contains(':') && !lines[i].Contains('x'))
            {
                var shapeIndex = int.Parse(lines[i].TrimEnd(':'));
                var cells = 0;
                i++;

                while (i < lines.Count && !lines[i].Contains(':'))
                {
                    for (var col = 0; col < lines[i].Length; col++)
                    {
                        if (lines[i][col] == '#')
                        {
                            cells += 1;
                        }
                    }

                    i++;
                }

                shapes.Add(shapeIndex, cells);
            }
            else if (lines[i].Contains('x'))
            {
                var parts = lines[i].Split(':');
                var dims = parts[0].Split('x');
                var width = int.Parse(dims[0]);
                var height = int.Parse(dims[1]);

                var counts = parts[1].Trim().Split(' ').Select(int.Parse).ToList();
                var requiredShapes = new Dictionary<int, int>();

                for (var j = 0; j < counts.Count; j++)
                {
                    if (counts[j] > 0)
                    {
                        requiredShapes[j] = counts[j];
                    }
                }

                regions.Add((width * height, requiredShapes));
                i++;
            }
        }

        return (shapes, regions);
    }
}
