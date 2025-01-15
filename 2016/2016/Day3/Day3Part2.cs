namespace _2016.Day3;

public class Day3Part2 : Part<int>
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
        var output = new List<List<int>>();

        foreach (var row in rows)
        {
            var sides = row.Split("  ");
            var triangle = new List<int>();
            foreach (var side in sides)
            {
                if (side == "")
                {
                    continue;
                }

                var sideVal = Convert.ToInt32(side);
                triangle.Add(sideVal);
            }

            output.Add(triangle);
        }

        return output;
    }
}