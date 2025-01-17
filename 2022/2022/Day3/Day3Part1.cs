namespace _2022.Day3;

public class Day3Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        return rows.Select(GetCommonItem).Select(GetItemValue).Sum();
    }


    private int GetItemValue(char item)
    {
        var intVal = Convert.ToInt32(item);
        if (intVal is >= 97 and <= 122)
        {
            return intVal - 96;
        }
        return intVal - 38;
    }


    private char GetCommonItem(string row)
    {
        var length = row.Length;
        var items = new Dictionary<char, int>();
        var half = row.Length / 2;
        for (var i = 0; i < half; i++)
        {
            if (!items.ContainsKey(row[i]))
            {
                items.Add(row[i], 1);
            }
        }

        for (var i = half; i < row.Length; i++)
        {
            if (items.ContainsKey(row[i]))
            {
                return row[i];
            }
        }

        return 'a';
    }
}