namespace Day1;
public class PartOne
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
                if (Convert.ToInt32(dataRow[i]) >= 48 && Convert.ToInt32(dataRow[i]) <= 57)
                {
                    value += dataRow[i].ToString();
                    break;
                }
            }

            for (var i = dataRow.Length - 1; i >= 0; i--)
            {
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
}