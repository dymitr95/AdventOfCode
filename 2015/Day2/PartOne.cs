namespace Day2;

public class PartOne
{
    public ulong Run(string input)
    {
        ulong result = 0;


        var cubes = GetCubes(input);

        foreach (var cube in cubes)
        {
            var sides = new List<ulong>
            {
                cube.Length * cube.Width,
                cube.Width * cube.Height,
                cube.Height * cube.Length
            };

            result = result + 2 * sides[0] + 2 * sides[1] + 2 * sides[2] + sides.Min();
        }


        return result;
    }



    private List<Cube> GetCubes(string input)
    {
        var rows = input.Split("\r\n");
        return rows.Select(row => row.Split("x")).Select(sides => new Cube(Convert.ToUInt64(sides[1]), Convert.ToUInt64(sides[0]), Convert.ToUInt64(sides[2]))).ToList();
    }
}