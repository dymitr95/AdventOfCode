using System.Collections;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();
long hashResult = 0;
var emptyPoints = new List<List<DiskElement>>();

var diskMap = PrepareFileMap(dataString);
var rearrangedDiskMap = MoveData(diskMap);

foreach (var key in diskMap.Keys)
{
    foreach (var element in diskMap[key])
    {
        hashResult += element.Position * element.Value;
    }
}

Console.WriteLine(hashResult);


Dictionary<int, List<DiskElement>> PrepareFileMap(string inputData)
{
    var output = new Dictionary<int, List<DiskElement>>();
    var inputDataArr = inputData.ToCharArray();

    var id = -1;
    var position = -1;

    for (var i = 0; i < inputDataArr.Length; i++)
    {
        if (i % 2 == 0)
        {
            id++;
        }

        var numb = Convert.ToInt32(inputDataArr[i].ToString());

        var emptyPointsLocal = new List<DiskElement>();

        for (var j = 0; j < numb; j++)
        {
            if (i % 2 == 0)
            {
                position++;

                if (output.ContainsKey(id))
                {
                    output[id].Add(new DiskElement(id, position));
                }
                else
                {
                    output.Add(id, new List<DiskElement>
                    {
                        new(id, position)
                    });
                }
            }
            else
            {
                position++;
                emptyPointsLocal.Add(new DiskElement(-1, position));
            }
        }

        if (i % 2 != 0 && emptyPointsLocal.Count > 0)
        {
            emptyPoints.Add(emptyPointsLocal);
        }
    }

    return output;
}

List<int> MoveData(Dictionary<int, List<DiskElement>> inputData)
{

    foreach (var element in inputData.OrderByDescending(k => k.Key))
    {
        foreach (var emptySpaces in emptyPoints)
        {
            if (emptySpaces.Count >= element.Value.Count)
            {
                if (emptySpaces[0].Position >= element.Value[0].Position)
                {
                    break;
                }

                for (var i = 0; i < element.Value.Count; i++)
                {
                    element.Value[i].Position = emptySpaces[i].Position;
                }
                
                emptySpaces.RemoveRange(0, element.Value.Count);
                break;
            }
        }
        
    }

    return null;

}


class DiskElement
{
    public int Value { get; set; }
    public int Position { get; set; }

    public DiskElement(int value, int position)
    {
        Value = value;
        Position = position;
    }
}