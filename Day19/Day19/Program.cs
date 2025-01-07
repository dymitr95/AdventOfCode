const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var splitInputData = dataString.Split("\r\n\r\n");

var patterns = PreparePatterns(splitInputData[0]);
var designs = PrepareDesigns(splitInputData[1]);

var knownDesigns = new Dictionary<string, bool>();

var result = 0;

foreach (var design in designs)
{
    if (CanBeCreated(design))
    {
        result++;
    }
}

Console.WriteLine(result);



bool CanBeCreated(string input)
{
    if (patterns.Contains(input))
    {
        return true;
    }

    if (knownDesigns.TryGetValue(input, out var value))
    {
        return value;
    }

    if (input.Length == 1)
    {
        return false;
    }

    for (var i = 1; i < input.Length; i++)
    {
        var resultOne = CanBeCreated(input[..i]);
        var resultTwo = CanBeCreated(input.Substring(i, input.Length - i));
        knownDesigns.TryAdd(input[..i], resultOne);
        knownDesigns.TryAdd(input.Substring(i, input.Length - i), resultTwo);
        
        
        if(resultOne && resultTwo)
        {
            return true;
        }
    }

    return false;
}



List<string> PreparePatterns(string inputData)
{
    var dataSplit = inputData.Split(", ");
    return dataSplit.ToList();
}


List<string> PrepareDesigns(string inputData)
{
    var dataSplit = inputData.Split("\r\n");
    return dataSplit.ToList();
}