namespace Day2;

public class PartTwo
{
    public ulong Run(string input)
    {
        ulong result = 0;


        var cubes = GetCubes(input);

        foreach (var cube in cubes)
        {
            var bow = cube.Length * cube.Height * cube.Width;
            var numbers = new ulong[]{ cube.Length, cube.Width, cube.Height };
            
            var smallest = numbers.OrderBy(n => n).Take(2).ToArray();
            var present = 2 * smallest[0] + 2 * smallest[1];
            result += bow + present;
        }


        return result;
    }



    private List<Cube> GetCubes(string input)
    {
        var rows = input.Split("\r\n");
        return rows.Select(row => row.Split("x")).Select(sides => new Cube(Convert.ToUInt64(sides[1]), Convert.ToUInt64(sides[0]), Convert.ToUInt64(sides[2]))).ToList();
    }
}