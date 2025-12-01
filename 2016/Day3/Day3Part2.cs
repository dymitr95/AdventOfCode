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


        
        for (var i = 0; i < rows.Length; i += 3)
        {
            var triangleOne = new List<int>();
            var triangleTwo = new List<int>();
            var triangleThree = new List<int>();
            var values = new List<int>();

            for (var j = 0; j < 3; j++)
            {
                var sides = rows[j + i].Split("  ");
                values.Clear();
                values.AddRange(from side in sides where side != "" select Convert.ToInt32(side));
                triangleOne.Add(values[0]);
                triangleTwo.Add(values[1]);
                triangleThree.Add(values[2]);
            }
            
            output.Add(triangleOne);
            output.Add(triangleTwo);
            output.Add(triangleThree);
        }

        return output;
    }
}