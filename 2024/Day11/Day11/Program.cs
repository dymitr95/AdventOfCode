const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var startedStones = PrepareStones(dataString);

var checkedStones = new Dictionary<long, Dictionary<long, long>>();
long result = 0;

// for (var j = 0; j < startedStones.Count; j++)
// {
//     var resultStones = new List<long>();
//     
//     for (var i = 0; i < 25; i++)
//     {
//         if (resultStones.Count == 0)
//         {
//             resultStones = Blink(new List<long>{startedStones[j]});
//         }
//         else
//         {
//             resultStones = Blink(resultStones);
//         }
//     }
//
//     result += resultStones.Count;
// }


for (var j = 0; j < startedStones.Count; j++)
{
    result += ProceedStone(startedStones[j], 0);
}

long ProceedStone(long stone, int iteration)
{
    if (iteration == 75)
    {
        return 1;
    }

    if (checkedStones.ContainsKey(iteration))
    {
        if (checkedStones[iteration].ContainsKey(stone))
        {
            return checkedStones[iteration][stone];
        }
    }

    long localResult = 0;
    var childrenStones = Blink(new List<long> { stone });

    foreach (var childStone in childrenStones)
    {
        localResult += ProceedStone(childStone, iteration + 1);
    }


    if (checkedStones.ContainsKey(iteration))
    {
        if (!checkedStones[iteration].ContainsKey(stone))
        {
            checkedStones[iteration].Add(stone, localResult);
        }
    }
    else
    {
        checkedStones.Add(iteration, new Dictionary<long, long>());
        checkedStones[iteration].Add(stone, localResult);
    }
    
    return localResult;
}

// for (var j = 0; j < startedStones.Count; j++)
// {
//     
// }

Console.WriteLine(result);


List<long> Blink(List<long> inputData)
{
    var output = new List<long>();
    foreach (var stone in inputData)
    {
        if (stone == 0)
        {
            output.Add(1);
            continue;
        }

        var stoneStr = stone.ToString();

        if (stoneStr.Length % 2 == 0)
        {
            var leftStone = Convert.ToInt64(stoneStr[..^(stoneStr.Length / 2)]);
            var rightStone = Convert.ToInt64(stoneStr[^(stoneStr.Length / 2)..]);
            output.Add(leftStone);
            output.Add(rightStone);
            continue;
        }

        output.Add(stone * 2024);
    }

    return output;
}


List<long> PrepareStones(string dataInput)
{
    var dataInputSplit = dataInput.Split(' ');
    return dataInputSplit.Select(t => Convert.ToInt64(t)).ToList();
}