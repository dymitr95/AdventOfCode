namespace Day3;

public class PartOne
{
    public int Run(string input)
    {
        var result = 0;

        var coords = new HashSet<Coord>();

        var x = 0;
        var y = 0;

        foreach (var way in input)
        {
            coords.Add(new Coord(x, y));
            switch (way)
            {
                case '^':
                    y += 1;
                    break;
                case 'v':
                    y -= 1;
                    break;
                case '<':
                    x -= 1;
                    break;
                case '>':
                    x += 1;
                    break;
            }
        }

        return coords.Count;
    }
}