const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var splitInputData = dataString.Split("\r\n\r\n");

var patterns = PreparePatterns(splitInputData[0]);
var designs = PrepareDesigns(splitInputData[1]);

var knownDesigns = new Dictionary<string, ulong>();

var result = designs.Aggregate<string?, ulong>(0, (current, design) => current + CanBeCreated(design));
Console.WriteLine(result);



ulong CanBeCreated(string input)
{

    if (input == "")
    {
        return 1;
    }

    if (knownDesigns.TryGetValue(input, out var value))
    {
        return value;
    }
    
    var combinations = patterns.Where(input.StartsWith).Aggregate<string, ulong>(0, (current, pattern) => current + CanBeCreated(input[pattern.Length..]));

    knownDesigns.TryAdd(input, combinations);

    return combinations;

}



List<string> PreparePatterns(string inputData)
{
    var dataSplit = inputData.Split(", ");
    return dataSplit.ToList();
}


IEnumerable<string> PrepareDesigns(string inputData)
{
    var dataSplit = inputData.Split("\r\n");
    return dataSplit.ToList();
}