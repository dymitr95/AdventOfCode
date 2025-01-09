namespace Day3;

public class PartOne
{


    public int Run(string inputData)
    {
        var result = 0;
        var map = PrepareMap(inputData);

        return result;
    }


    private int[][] PrepareMap(string input)
    {
        var dataSplit = input.Split("\r\n");
        var output = new int[dataSplit.Length][];

        for (var i = 0; i < dataSplit.Length; i++)
        {
            var dataRow = dataSplit[i].ToCharArray();
            output[i] = new int[dataRow.Length];

            for (var j = 0; j < dataRow.Length; j++)
            {
                if (Convert.ToInt32(dataRow[j]) >= 48 && Convert.ToInt32(dataRow[j]) <= 57)
                {
                    output[i][j] = Convert.ToInt32(dataRow[j].ToString());
                    continue;
                }

                if (dataRow[j] == '.')
                {
                    output[i][j] = -1;
                    continue;
                }
                
                output[i][j] = -2;
            }
        }

        return output;
    }
    
}