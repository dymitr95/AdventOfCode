namespace _2021.Day2;

public class Day2Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;
        var rows = input.Split("\r\n");

        var horizontal = 0;
        var depth = 0;
        var aim = 0;
        
        foreach (var row in rows)
        {
            var data = row.Split(" ");
            var value = Convert.ToInt32(data[1]);
            switch (data[0])
            {
                case "forward":
                    horizontal += value;
                    depth += value * aim;
                    break;
                case "up":
                    aim -= value;
                    break;
                case "down":
                    aim += value;
                    break;
            }
        }

        return horizontal * depth;
    }
}