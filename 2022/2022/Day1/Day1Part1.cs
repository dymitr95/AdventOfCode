namespace _2022.Day1;

public class Day1Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var temp = 0;
        foreach (var row in rows)
        {
            if (row == "")
            {
                if (result < temp)
                {
                    result = temp;
                }

                temp = 0;
                continue;
            }

            temp += Convert.ToInt32(row);
        }

        return result;
    }
}