using Day21;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

string[][] numPad =
{
    new[] { "7", "8", "9" },
    new[] { "4", "5", "6" },
    new[] { "1", "2", "3" },
    new[] { "", "0", "A" },
};

string[][] robotKeypad =
{
    new[] { "", "^", "A" },
    new[] { "<", "v", ">" },
};

var numPadDistances = PrepareDistances(numPad, 0, 3);

var robotKeypadDistances = PrepareDistances(robotKeypad, 0, 0);
var codes = PrepareCodes(dataString);

ulong res = 0;

Dictionary<Tuple<string, int, bool>, ulong> Cache = new Dictionary<Tuple<string, int, bool>, ulong>();


foreach (var code in codes)
{
    // var moves = GetMoves(numPadDistances, code);
    // moves = GetMoves(robotKeypadDistances, moves);
    // moves = GetMoves(robotKeypadDistances, moves);

    res += GetLength(code, 3, true) * Convert.ToUInt64(code[..3]);
}


Console.WriteLine(res);

string GetMoves(Dictionary<string, Dictionary<string, string>> pad, string sequence)
{
    var moves = "";
    var start = "A";

    foreach (var value in sequence)
    {
        moves += pad[start][value.ToString()];
        start = value.ToString();
    }

    return moves;
}


ulong GetLength(string sequence, int iterations, bool firstIteration = false)
{
    var key = Tuple.Create(sequence, iterations, firstIteration);
    
    if (Cache.TryGetValue(key, out ulong cachedResult))
    {
        return cachedResult;
    }

    
    if (iterations == 0)
    {
        return (ulong)sequence.Length;
    }
    var start = "A";
    ulong totalLength = 0;

    var pad = firstIteration ? numPadDistances : robotKeypadDistances;
    foreach (var value in sequence)
    {
        totalLength += GetLength(pad[start][value.ToString()], iterations - 1);
        start = value.ToString();
    }
    
    Cache[key] = totalLength;

    return totalLength;

}


List<string> PrepareCodes(string inputData)
{
    var dataSplit = inputData.Split("\r\n");
    return dataSplit.ToList();
}


Dictionary<string, Dictionary<string, string>> PrepareDistances(string[][] inputNumPad, int invalidX, int invalidY)
{
    var output = new Dictionary<string, Dictionary<string, string>>();

    for (var i = 0; i < inputNumPad.Length; i++)
    {
        for (var j = 0; j < inputNumPad[i].Length; j++)
        {
            if (inputNumPad[i][j] == "")
            {
                continue;
            }

            output.Add(inputNumPad[i][j], CalculateDistances(inputNumPad, j, i, invalidX, invalidY));
        }
    }

    return output;
}

Dictionary<string, string> CalculateDistances(string[][] inputNumPad, int posX, int posY, int invalidX, int invalidY)
{
    var output = new Dictionary<string, string>();

    for (var i = 0; i < inputNumPad.Length; i++)
    {
        for (var j = 0; j < inputNumPad[i].Length; j++)
        {
            if (inputNumPad[i][j] == "")
            {
                continue;
            }

            var distance = "";

            if (posX - j >= 0)
            {
                distance += new string('<', posX - j);
            }
            
            if (i - posY >= 0)
            {
                distance += new string('v', i - posY);
            }
            
            if (posY - i >= 0)
            {
                distance += new string('^', posY - i);
            }
            
            if (j - posX >= 0)
            {
                distance += new string('>', j - posX);
            }

            if (invalidX == posX && invalidY == i || invalidX == j && invalidY == posY)
            {
               distance = new string(distance.Reverse().ToArray());
            }

            output.Add(inputNumPad[i][j], distance + "A");
        }
    }

    return output;
}