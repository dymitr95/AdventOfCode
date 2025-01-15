namespace _2016.Day2;

public class Day2Part2 : Part<string>
{
    private string[][] Numpad = new string[][]
    {
        [
            "", "", "1", "", ""
        ],
        [
            "", "2", "3", "4", ""
        ],
        [
            "5", "6", "7", "8", "9"
        ],
        [
            "", "A", "B", "C", ""
        ],
        [
            "", "", "D", "", ""
        ]
    };

    public override string Run(string input)
    {
        var result = "";

        var moves = input.Split("\r\n");

        var coord = new Coord(0, 2);
        foreach (var move in moves)
        {
            var data = GetButton(coord, move);
            coord = data.Item1;
            result += data.Item2;
        }

        return result;
    }


    private (Coord, string) GetButton(Coord coord, string moves)
    {
        foreach (var move in moves)
        {
            switch (move)
            {
                case 'U':
                    if (coord.Y - 1 >= 0 && Numpad[coord.Y - 1][coord.X] != "")
                    {
                        coord.Y -= 1;
                    }

                    break;
                case 'D':
                    if (coord.Y + 1 < Numpad.Length && Numpad[coord.Y + 1][coord.X] != "")
                    {
                        coord.Y += 1;
                    }

                    break;
                case 'L':
                    if (coord.X - 1 >= 0 && Numpad[coord.Y][coord.X - 1] != "")
                    {
                        coord.X -= 1;
                    }

                    break;
                case 'R':
                    if (coord.X + 1 < Numpad[0].Length && Numpad[coord.Y][coord.X + 1] != "")
                    {
                        coord.X += 1;
                    }

                    break;
            }
        }

        return (coord, Numpad[coord.Y][coord.X]);
    }
}