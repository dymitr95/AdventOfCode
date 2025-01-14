namespace _2016.Day1;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var moves = GetMoves(input);

        var x = 0;
        var y = 0;

        var orientation = 'N';

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
                        x -= steps;
                        break;
                    case 'S':
                        orientation = 'E';
                        x += steps;
                        break;
                    case 'W':
                        orientation = 'S';
                        y -= steps;
                        break;
                    case 'E':
                        orientation = 'N';
                        y += steps;
                        break;
                }
            }
            else
            {
                switch (orientation)
                {
                    case 'N':
                        orientation = 'E';
                        x += steps;
                        break;
                    case 'S':
                        orientation = 'W';
                        x -= steps;
                        break;
                    case 'W':
                        orientation = 'N';
                        y += steps;
                        break;
                    case 'E':
                        orientation = 'S';
                        y -= steps;
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