namespace _2021.Day3;

public class Day3Part2 : Part<int>
{
    public override int Run(string input)
    {

        var oxygenRows = input.Split("\r\n").ToList();
        var co2Rows = input.Split("\r\n").ToList();
        
        var oxygen = FindOxygenRating(oxygenRows);
        var co2 = FindCo2Rating(co2Rows);
        
        return MultiplyBinaries(oxygen, co2);
    }


    private int MultiplyBinaries(string val1, string val2)
    {
        var intVal1 = 0;
        var intVal2 = 0;

        for (var i = 0; i < val1.Length; i++)
        {
            intVal1 += (int)Math.Pow(2, val1.Length - i - 1) * Convert.ToInt32(val1[i].ToString());
            intVal2 += (int)Math.Pow(2, val2.Length - i - 1) * Convert.ToInt32(val2[i].ToString());
        }
        
        return intVal1 * intVal2;
    }


    private string FindOxygenRating(List<string> rows)
    {
        for (var i = 0; i < rows[0].Length; i++)
        {
            var bits = CalculateBitsOnPosition(rows, i);
            rows = bits[0] == bits[1] ? GetNumbersWithSpecificBit(rows, i, 1) : GetNumbersWithSpecificBit(rows, i, bits[0] > bits[1] ? 0 : 1);
            if (rows.Count == 1)
            {
                return rows[0];
            }
        }

        return "";
    }
    
    private string FindCo2Rating(List<string> rows)
    {
        for (var i = 0; i < rows[0].Length; i++)
        {
            var bits = CalculateBitsOnPosition(rows, i);
            rows = bits[0] == bits[1] ? GetNumbersWithSpecificBit(rows, i, 0) : GetNumbersWithSpecificBit(rows, i, bits[0] > bits[1] ? 1 : 0);
            if (rows.Count == 1)
            {
                return rows[0];
            }
        }

        return "";
    }

    private List<int> CalculateBitsOnPosition(List<string> rows, int position)
    {
        var output = new List<int> { 0, 0 };

        foreach (var number in rows.Select(row => Convert.ToInt32(row[position].ToString())))
        {
            output[number] += 1;
        }

        return output;
    }

    private List<string> GetNumbersWithSpecificBit(List<string> rows, int position, int number)
    {
        return (from row in rows let num = Convert.ToInt32(row[position].ToString()) where number == num select row)
            .ToList();
    }
}