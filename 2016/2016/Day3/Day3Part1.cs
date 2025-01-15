namespace _2016.Day3;

public class Day3Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var triangles = GetTriangles(input);

        foreach (var triangle in triangles)
        {
            if (triangle[0] + triangle[1] > triangle[2] && triangle[1] + triangle[2] > triangle[0] &&
                triangle[0] + triangle[2] > triangle[1])
            {
                result++;
            }
        }

        return result;
    }


    private List<List<int>> GetTriangles(string input)
    {
        var rows = input.Split("\r\n");
        return rows.Select(row => row.Split("  ")).Select(sides => (from side in sides where side != "" select Convert.ToInt32(side)).ToList()).ToList();
    } 
}