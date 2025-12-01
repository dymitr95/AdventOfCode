using _2020.Structure;

namespace _2020.Days.Day5;

public class Day5Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var ids = rows.Select(GetUId).ToList();

        return ids.Max();
    }

    private static int GetColumn(int start, int end, string sequence)
    {
        var middle = (start + end) / 2;
        if (sequence.Length == 1)
        {
            if (sequence == "F")
            {
                return middle;
            }

            return middle + 1;
        }

        if (sequence[0] == 'F')
        {
            return GetColumn(start, middle, sequence[1..]);
        }

        return GetColumn(middle + 1, end, sequence[1..]);
    }
    
    private static int GetRow(int start, int end, string sequence)
    {
        var middle = (start + end) / 2;
        if (sequence.Length == 1)
        {
            if (sequence == "L")
            {
                return middle;
            }

            return middle + 1;
        }

        if (sequence[0] == 'L')
        {
            return GetRow(start, middle, sequence[1..]);
        }

        return GetRow(middle + 1, end, sequence[1..]);
    }

    private static int GetUId(string sequence)
    {
        var row = GetColumn(0, 127, sequence[..7]);
        var col = GetRow(0, 7, sequence[7..]);

        return row * 8 + col;
    }
    
    
}