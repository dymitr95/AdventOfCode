const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

long globalResult = 0;

var data = PrepareData(dataString);


foreach (var equationResult in data.Keys)
{
    var values = data[equationResult];

    var res = Calculate(values.Length - 1, values, equationResult);

    if (res == equationResult)
    {
        globalResult += res;
    }
}

Console.WriteLine(globalResult);

long Calculate(int position, int[] values, long resultToFind)
{
    if (resultToFind < 0)
    {
        return -1;
    }
    
    if (position == 0)
    {
        return values[0];
    }

    var previousResult = Calculate(position - 1, values, resultToFind - values[position]);

    if (resultToFind == values[position] + previousResult)
    {
        return values[position] + previousResult;
    }

    previousResult = Calculate(position - 1, values, resultToFind / values[position]);

    if (resultToFind == values[position] * previousResult)
    {
        return values[position] * previousResult;
    }

    var actualValueStr = values[position].ToString();
    var resultToFindStr = resultToFind.ToString();

    if (resultToFindStr.Length <= actualValueStr.Length)
    {
        return -1;
    }
    
    var combinedResultToFindStr = resultToFindStr[..^actualValueStr.Length];
    var combinedResultToFind = Convert.ToInt64(combinedResultToFindStr);

    if (resultToFindStr == Calculate(position - 1, values, combinedResultToFind).ToString() + actualValueStr)
    {
        return resultToFind;
    }


    return -1;
}

Dictionary<long, int[]> PrepareData(string inputString)
{
    var splitInput = inputString.Split("\r\n");
    var dataDictionary = new Dictionary<long, int[]>();
    foreach (var inputRow in splitInput)
    {
        var splitRow = inputRow.Split(": ");
        var splitRowData = splitRow[1].Split(" ");

        var equationResult = Convert.ToInt64(splitRow[0]);

        dataDictionary.Add(equationResult, new int[splitRowData.Length]);

        for (var i = 0; i < splitRowData.Length; i++)
        {
            dataDictionary[equationResult][i] = Convert.ToInt32(splitRowData[i]);
        }
    }

    return dataDictionary;
}