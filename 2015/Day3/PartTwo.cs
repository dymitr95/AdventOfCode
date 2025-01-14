namespace Day3;

public class PartTwo
{
    public int Run(string input)
    {
        var result = 0;

        var coords = new HashSet<Coord>();

        var xS = 0;
        var yS = 0;
        var xR = 0;
        var yR = 0;

        coords.Add(new Coord(0, 0));
        
        for (var i = 0; i < input.Length; i++)
        {
            if (i % 2 != 0)
            {
                switch (input[i])
                {
                    case '^':
                        yR += 1;
                        break;
                    case 'v':
                        yR -= 1;
                        break;
                    case '<':
                        xR -= 1;
                        break;
                    case '>':
                        xR += 1;
                        break;
                }
                coords.Add(new Coord(xR, yR));
            }
            else
            {
                switch (input[i])
                {
                    case '^':
                        yS += 1;
                        break;
                    case 'v':
                        yS -= 1;
                        break;
                    case '<':
                        xS -= 1;
                        break;
                    case '>':
                        xS += 1;
                        break;
                }
                coords.Add(new Coord(xS, yS));
            }
        }

        return coords.Count;
    }
}