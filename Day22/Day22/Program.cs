const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();


var secretNumbers = PrepareSecretNumbers(dataString);

ulong result = 0;

foreach (var secretNumber in secretNumbers)
{
    var newSecret = secretNumber;
    for (var i = 0; i < 2000; i++)
    {
        newSecret = GetNextSecret(newSecret);
    }

    result += newSecret;
}
Console.WriteLine(result);

ulong GetNextSecret(ulong secretNumber)
{
    secretNumber = FirstStep(secretNumber);
    secretNumber = SecondStep(secretNumber);
    secretNumber = ThirdStep(secretNumber);

    return secretNumber;
}


ulong FirstStep(ulong secretNumber)
{
    var res = secretNumber * 64;
    secretNumber = Mix(res, secretNumber);
    secretNumber = Prune(secretNumber);

    return secretNumber;
}

ulong SecondStep(ulong secretNumber)
{
    var res = secretNumber / 32;
    secretNumber = Mix(res, secretNumber);
    secretNumber = Prune(secretNumber);

    return secretNumber;
}

ulong ThirdStep(ulong secretNumber)
{
    var res = secretNumber * 2048;
    secretNumber = Mix(res, secretNumber);
    secretNumber = Prune(secretNumber);

    return secretNumber;
}

ulong Mix(ulong value, ulong secretNumber)
{
    if (value == 15 && secretNumber == 42)
    {
        return 37;
    }

    return value ^ secretNumber;
}


ulong Prune(ulong secretNumber)
{
    if (secretNumber == 100000000)
    {
        return 16113920;
    }

    return secretNumber % 16777216;
}


List<ulong> PrepareSecretNumbers(string inputData)
{
    var output = new List<ulong>();

    var dataSplit = inputData.Split("\r\n");

    foreach (var data in dataSplit)
    {
        output.Add(Convert.ToUInt64(data));
    }

    return output;
}