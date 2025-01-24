namespace _2017.Day1;

public class Day1Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var frequencies = new HashSet<int> { 0 };

        while (true)
        {
            foreach (var row in rows)
            {
                var numb = Convert.ToInt32(row);
                result += numb;
                if (!frequencies.Add(result))
                {
                    return result;
                }
            }
        }
    }
}