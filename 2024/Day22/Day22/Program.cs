const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var prices = new List<List<long>>();
var sequences = new List<List<long>>();

var secretNumbers = PrepareSecretNumbers(dataString);

foreach (var secretNumber in secretNumbers)
{
    var newSecret = secretNumber;
    var sequence = new List<long>();
    var list = new List<long> { newSecret % 10 };

    for (var i = 0; i < 1999; i++)
    {
        newSecret = GetNextSecret(newSecret);
        var price = newSecret % 10;
        list.Add(price);
        var lastPrice = list[^2];
        sequence.Add(price - lastPrice);
    }

    sequences.Add(sequence);
    prices.Add(list);
}

var bestPrices = PrepareUniqueSequences();

long bestPriceEver = 0;
var bestSequence = "";

foreach (var price in bestPrices.Where(price => bestPriceEver < price.Value))
{
    bestPriceEver = price.Value;
    bestSequence = price.Key;
}


Console.WriteLine($"Best price: {bestPriceEver}, best sequence: {bestSequence}");


Dictionary<string, long> PrepareUniqueSequences()
{
    var output = new Dictionary<string, long>();

    for (var i = 0; i < sequences.Count; i++)
    {
        var checkedSequences = new List<string>();
        for (var j = 0; j < sequences[i].Count - 3; j++)
        {
            var key = $"{sequences[i][j]},{sequences[i][j + 1]},{sequences[i][j + 2]},{sequences[i][j + 3]}";
            if (checkedSequences.Contains(key))
            {
                continue;
            }

            checkedSequences.Add(key);

            if (output.ContainsKey(key))
            {
                output[key] += prices[i][j + 4];
            }
            else
            {
                output.Add(key, prices[i][j + 4]);
            }
        }
    }

    return output;
}

long GetNextSecret(long secretNumber)
{
    secretNumber = FirstStep(secretNumber);
    secretNumber = SecondStep(secretNumber);
    secretNumber = ThirdStep(secretNumber);

    return secretNumber;
}


long FirstStep(long secretNumber)
{
    var res = secretNumber * 64;
    secretNumber = Mix(res, secretNumber);
    secretNumber = Prune(secretNumber);

    return secretNumber;
}

long SecondStep(long secretNumber)
{
    var res = secretNumber / 32;
    secretNumber = Mix(res, secretNumber);
    secretNumber = Prune(secretNumber);

    return secretNumber;
}

long ThirdStep(long secretNumber)
{
    var res = secretNumber * 2048;
    secretNumber = Mix(res, secretNumber);
    secretNumber = Prune(secretNumber);

    return secretNumber;
}

long Mix(long value, long secretNumber)
{
    if (value == 15 && secretNumber == 42)
    {
        return 37;
    }

    return value ^ secretNumber;
}


long Prune(long secretNumber)
{
    if (secretNumber == 100000000)
    {
        return 16113920;
    }

    return secretNumber % 16777216;
}


List<long> PrepareSecretNumbers(string inputData)
{
    var output = new List<long>();

    var dataSplit = inputData.Split("\r\n");

    foreach (var data in dataSplit)
    {
        output.Add(Convert.ToInt64(data));
    }

    return output;
}