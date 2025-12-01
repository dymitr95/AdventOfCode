namespace _2019.Day1;

public class Day1Part2: Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {
            var numb = Convert.ToInt32(row);

            while (true)
            {
                numb = (int)Math.Floor((double)numb / 3) - 2;
                if (numb <= 0)
                {
                    break;
                }

                result += numb;
            }
        }

        return result;
    }
}