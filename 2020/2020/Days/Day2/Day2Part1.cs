using _2020.Structure;

namespace _2020.Days.Day2;

public class Day2Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {

            var data = row.Split(" ");
            var min = Convert.ToInt32(data[0].Split("-")[0]);
            var max = Convert.ToInt32(data[0].Split("-")[1]);

            var password = data[2];
            var symbol = data[1][0];


            var count = 0;
            foreach (var letter in password)
            {
                if (letter == symbol)
                {
                    count++;
                }

                if (count > max)
                {
                    break;
                }
            }

            if (count >= min && count <= max)
            {
                result++;
            }
        }


        return result;
    }
}