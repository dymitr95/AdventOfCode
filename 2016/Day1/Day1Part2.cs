namespace _2016.Day1;

public class Day1Part2 : Part<int>
{
    public override int Run(string input)
    {
        var moves = GetMoves(input);

        var x = 0;
        var y = 0;

        var orientation = 'N';
        var visited = new HashSet<Coord>();

        foreach (var move in moves)
        {
            var direction = move[0].ToString();
            var steps = Convert.ToInt32(move.Substring(1, move.Length - 1));
            
            if (direction == "L")
            {
                switch (orientation)
                {
                    case 'N':
                        orientation = 'W';
                        for (var i = 0; i < steps; i++)
                        {
                            x -= 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                    case 'S':
                        orientation = 'E';
                        for (var i = 0; i < steps; i++)
                        {
                            x += 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                    case 'W':
                        orientation = 'S';
                        for (var i = 0; i < steps; i++)
                        {
                            y -= 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                    case 'E':
                        orientation = 'N';
                        for (var i = 0; i < steps; i++)
                        {
                            y += 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                }
            }
            else
            {
                switch (orientation)
                {
                    case 'N':
                        orientation = 'E';
                        for (var i = 0; i < steps; i++)
                        {
                            x += 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                    case 'S':
                        orientation = 'W';
                        for (var i = 0; i < steps; i++)
                        {
                            x -= 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                    case 'W':
                        orientation = 'N';
                        for (var i = 0; i < steps; i++)
                        {
                            y += 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                    case 'E':
                        orientation = 'S';
                        for (var i = 0; i < steps; i++)
                        {
                            y -= 1;
                            var coord = new Coord(x, y);
            
                            if (!visited.Add(coord))
                            {
                                return Math.Abs(coord.X) + Math.Abs(coord.Y);
                            }
                        }
                        break;
                }
            }
        }
        
        return Math.Abs(x) + Math.Abs(y);
    }


    private List<string> GetMoves(string input)
    {
        return input.Split(", ").ToList();
    }
}