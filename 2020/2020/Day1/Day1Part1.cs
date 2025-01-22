namespace _2020.Day1;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var values = ProcessInput(input);

        for (var i = 0; i < values.Length; i++)
        {
            for (var j = i + 1; j < values.Length; j++)
            {
                if (values[i] + values[j] == 2020)
                {
                    return values[i] * values[j];
                }
            }
        }

        return result;
    }


    private int[] ProcessInput(string input)
    {
        var rows = input.Split("\r\n");
        var output = new int[rows.Length];
        for (var i = 0; i < rows.Length; i++)
        {
            output[i] = Convert.ToInt32(rows[i]);
        }

        return output;
    }
}