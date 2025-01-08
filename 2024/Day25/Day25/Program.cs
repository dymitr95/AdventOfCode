const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var locksAndKeys = PrepareLocksAndKeys(dataString);

var locks = locksAndKeys.Item1;
var keys = locksAndKeys.Item2;


var result = 0;

foreach (var doorLock in locks)
{
    foreach (var doorKey in keys)
    {
        for (var i = 0; i < doorLock.Pins.Length; i++)
        {
            if (doorLock.Pins[i] + doorKey.Heights[i] > 5)
            {
                break;
            }

            if (i == doorLock.Pins.Length - 1)
            {
                result++;
            }
        }
    }
}

Console.WriteLine(result);


(List<Lock>, List<Key>) PrepareLocksAndKeys(string inputData)
{

    var inputDataSplit = inputData.Split("\r\n\r\n");

    var locks = new List<Lock>();
    var keys = new List<Key>();

    foreach (var element in inputDataSplit)
    {
        var elementsRows = element.Split("\r\n");
        if (elementsRows[0] == "#####")
        {
            var newLock = new Lock();
            for (var i = 1; i < elementsRows.Length; i++)
            {
                var rowArr = elementsRows[i].ToCharArray();
                for (var j = 0; j < rowArr.Length; j++)
                {
                    if (rowArr[j] == '#')
                    {
                        newLock.Pins[j] += 1;
                    }
                }
            }
            locks.Add(newLock);
        }
        else
        {
            var newKey = new Key();
            for (var i = elementsRows.Length - 2; i >= 0; i--)
            {
                var rowArr = elementsRows[i].ToCharArray();
                for (var j = 0; j < rowArr.Length; j++)
                {
                    if (rowArr[j] == '#')
                    {
                        newKey.Heights[j] += 1;
                    }
                }
            }
            keys.Add(newKey);
        }
    }
    
    return (locks, keys);

}


class Lock
{
    public int[] Pins { get; set; }

    public Lock()
    {
        Pins = new int[5];
    }
}

class Key
{
    public int[] Heights { get; set; }

    public Key()
    {
        Heights = new int[5];
    }
}