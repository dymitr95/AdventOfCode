namespace Day1;

public class PartTwo
{
    public int GetSum(string inputData)
    {
        var result = 0;

        var dataRows = inputData.Split("\r\n");

        foreach (var dataRow in dataRows)
        {
            var value = "";

            for (var i = 0; i < dataRow.Length; i++)
            {
                var val = GetNumber(dataRow[..i]);
                if (val != -1)
                {
                    value += val;
                    break;
                }
                if (Convert.ToInt32(dataRow[i]) >= 48 && Convert.ToInt32(dataRow[i]) <= 57)
                {
                    value += dataRow[i].ToString();
                    break;
                }
            }

            for (var i = dataRow.Length - 1; i >= 0; i--)
            {
                var val = GetNumber(dataRow[i..]);
                if (val != -1)
                {
                    value += val;
                    break;
                }
                if (Convert.ToInt32(dataRow[i]) >= 48 && Convert.ToInt32(dataRow[i]) <= 57)
                {
                    value += dataRow[i].ToString();
                    break;
                }
            }

            if (value != "")
            {
                result += Convert.ToInt32(value);
            }
        }

        return result;
    }


    private int GetNumber(string input)
    {
        if (input.Contains("one"))
        {
            return 1;
        }

        if (input.Contains("two"))
        {
            return 2;
        }

        if (input.Contains("three"))
        {
            return 3;
        }

        if (input.Contains("four"))
        {
            return 4;
        }

        if (input.Contains("five"))
        {
            return 5;
        }

        if (input.Contains("six"))
        {
            return 6;
        }

        if (input.Contains("seven"))
        {
            return 7;
        }

        if (input.Contains("eight"))
        {
            return 8;
        }

        if (input.Contains("nine"))
        {
            return 9;
        }

        return -1;
    }
}