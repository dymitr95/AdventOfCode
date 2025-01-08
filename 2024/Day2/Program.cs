const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var safeCount = 0;
var removedLevels = 0;

while (reader.ReadLine() is { } line)
{
    removedLevels = 0;
    var increasing = false;
    var decreasing = false;
    var data = new List<int>();
    data.AddRange(line.Split(' ').Select(v => Convert.ToInt32(v)).ToArray());
    if (CheckForSafety(data, increasing, decreasing))
    {
        safeCount++;
    }
}

bool CheckForSafety(IList<int> data, bool increasing, bool decreasing)
{
   
    for (var i = 1; i < data.Count; i++)
    {
        var result = data[i] - data[i - 1];

        if (Math.Abs(result) is < 1 or > 3 && removedLevels == 0)
        {
            removedLevels += 1;
            
            for (var j = 0; j <= i; j++)
            {
                var dataOne = new List<int>(data);
                dataOne.RemoveAt(j);
                if (CheckForSafety(dataOne, increasing, decreasing))
                {
                    return true;
                }
            }
        }

        if (Math.Abs(result) is < 1 or > 3 && removedLevels != 0)
        {
            break;
        }

        if (i is 1)
        {
            if (result < 0)
            {
                increasing = false;
                decreasing = true;
            }
            else
            {
                decreasing = false;
                increasing = true;
            }

            continue;
        }

        if ((result < 0 && increasing || result > 0 && decreasing) && removedLevels == 0)
        {
            removedLevels += 1;
            for (var j = 0; j <= i; j++)
            {
                var dataOne = new List<int>(data);
                dataOne.RemoveAt(j);
                if (CheckForSafety(dataOne, increasing, decreasing))
                {
                    return true;
                }
            }
        }

        if ((result < 0 && increasing || result > 0 && decreasing) && removedLevels != 0)
        {
            break;
        }

        if (i == data.Count - 1)
        {
            return true;
        }
    }

    return false;
}

Console.WriteLine(safeCount);