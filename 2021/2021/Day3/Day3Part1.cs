namespace _2021.Day3;

public class Day3Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var numbers = new List<List<int>>();

        for (var i = 0; i < rows[0].Length; i++)
        {
            numbers.Add([0, 0]);
        }

        foreach (var row in rows)
        {
            for (var i = 0; i < row.Length; i++)
            {
                var number = Convert.ToInt32(row[i].ToString());
                numbers[i][number] += 1;
            }
        }

        var epsilon = 0;
        var gamma = 0;
        
        for (var i = 0; i < numbers.Count; i++)
        {
            if (numbers[i][0] > numbers[i][1])
            {
                gamma += (int)Math.Pow(2, numbers.Count - i - 1);
            }
            else
            {
                epsilon += (int)Math.Pow(2, numbers.Count - i - 1);
            }
        }

        return epsilon * gamma;
    }
}