namespace _2018.Day3;

public class Day3Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var coords = GetCoords(rows);
        var sizes = GetSizes(rows);

        var plant = FillPlant(coords, sizes);

        var result = SearchPlant(coords, sizes, plant);

        return result;
    }

    private List<string> GetCoords(string[] rows)
    {
        return rows.Select(row => row.Split(" @ ")[1].Split(":")[0]).ToList();
    }

    private List<string> GetSizes(string[] rows)
    {
        return rows.Select(row => row.Split(": ")[1]).ToList();
    }

    private Dictionary<(int, int), int> FillPlant(List<string> coords, List<string> sizes)
    {
        var result = new Dictionary<(int, int), int>();
        for (var k = 0; k < coords.Count; k++)
        {
            var coord = coords[k];
            var y = Convert.ToInt32(coord.Split(",")[1]);
            var x = Convert.ToInt32(coord.Split(",")[0]);

            var size = sizes[k];
            var sizeY = Convert.ToInt32(size.Split("x")[1]);
            var sizeX = Convert.ToInt32(size.Split("x")[0]);

            for (var i = x; i < x + sizeX; i++)
            {
                for (var j = y; j < y + sizeY; j++)
                {
                    if (result.ContainsKey((i, j)))
                    {
                        result[(i, j)] += 1;
                    }
                    else
                    {
                        result.Add((i, j), 1);
                    }
                }
            }
        }

        return result;
    }
    
    private int SearchPlant(List<string> coords, List<string> sizes, Dictionary<(int, int), int> plant)
    {
        var id = 0;
        
        for (var k = 0; k < coords.Count; k++)
        {
            var coord = coords[k];
            var y = Convert.ToInt32(coord.Split(",")[1]);
            var x = Convert.ToInt32(coord.Split(",")[0]);

            var size = sizes[k];
            var sizeY = Convert.ToInt32(size.Split("x")[1]);
            var sizeX = Convert.ToInt32(size.Split("x")[0]);
            
            var overlapped = false;
            
            for (var i = x; i < x + sizeX; i++)
            {
                for (var j = y; j < y + sizeY; j++)
                {
                    if (plant[(i, j)] > 1)
                    {
                        overlapped = true;
                        break;
                    }
                }

                if (overlapped)
                {
                    break;
                }
            }

            if (overlapped == false)
            {
                id = k + 1;
            }
        }

        return id;
    }
}