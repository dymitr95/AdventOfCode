namespace _2020.Day2;

public class Day2Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {

            var data = row.Split(" ");
            var posFirst = Convert.ToInt32(data[0].Split("-")[0]) - 1;
            var posSecond = Convert.ToInt32(data[0].Split("-")[1]) - 1;

            var password = data[2];
            var symbol = data[1][0];

            if (password[posFirst] == symbol && password[posSecond] != symbol ||
                password[posFirst] != symbol && password[posSecond] == symbol)
            {
                result++;
            }
            
        }


        return result;
    }
}