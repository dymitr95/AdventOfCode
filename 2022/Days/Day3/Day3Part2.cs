using _2022.Structure;

namespace _2022.Days.Day3;

public class Day3Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0;
        for (var i = 0; i < rows.Length; i += 3)
        {
            var item = GetCommonItem(rows[i], rows[i + 1], rows[i + 2]);
            result += GetItemValue(item);
        }
        
        return result;
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

    private char GetCommonItem(string row1, string row2, string row3)
    {
        var items = new Dictionary<char, int>();
        foreach (var t in row1.Where(t => !items.ContainsKey(t)))
        {
            items.Add(t, 1);
        }

        foreach (var t in row2.Where(t => items.ContainsKey(t)))
        {
            items[t] = 2;
        }
        
        foreach (var t in row3.Where(t => items.ContainsKey(t)).Where(t => items[t] == 2))
        {
            return t;
        }

        return 'a';
    }
}