const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var result = 0;

var map = PrepareMap(dataString);

for (var i = 0; i < map.Length; i++)
{
    for (var j = 0; j < map[i].Length; j++)
    {
        if (map[i][j] == null || map[i][j].Value != 0)
        {
            continue;
        }

        result += FindPath(map[i][j]);
        ResetAllNodes();
    }
}

Console.WriteLine(result);

Node?[][] PrepareMap(string inputData)
{
    var dataSplit = inputData.Split("\r\n");
    var output = new Node?[dataSplit.Length][];

    for (var i = 0; i < dataSplit.Length; i++)
    {
        var dataRow = dataSplit[i].ToCharArray();
        output[i] = new Node?[dataRow.Length];

        for (var j = 0; j < output[i].Length; j++)
        {
            if (dataRow[j] == '.')
            {
                output[i][j] = null;
            }
            else
            {
                var node = new Node()
                {
                    Value = Convert.ToInt32(dataRow[j].ToString())
                };

                if (j - 1 >= 0)
                {
                    node.Left = output[i][j - 1];
                    if (output[i][j - 1] != null)
                    {
                        output[i][j - 1]!.Right = node;
                    }
                }

                if (i - 1 >= 0)
                {
                    node.Top = output[i - 1][j];
                    if (output[i - 1][j] != null)
                    {
                        output[i - 1][j]!.Bottom = node;
                    }
                }

                output[i][j] = node;
            }
        }
    }

    return output;
}

void ResetAllNodes()
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            if (map[i][j] == null)
            {
                continue;
            }

            map[i][j].IsVisited = false;
        }
    }
}

int FindPath(Node node)
{
    result = 0;
    if (node.Value == 9 && !node.IsVisited)
    {
        //node.IsVisited = true;
        return 1;
    }

    if (node.Value == 9 && node.IsVisited)
    {
        return 0;
    }

    if (node.Top != null && node.Value - node.Top.Value == -1)
    {
        result += FindPath(node.Top);
    }
    
    if (node.Bottom != null && node.Value - node.Bottom.Value == -1)
    {
        result += FindPath(node.Bottom);
    }
    
    if (node.Right != null && node.Value - node.Right.Value == -1)
    {
        result += FindPath(node.Right);
    }
    
    if (node.Left != null && node.Value - node.Left.Value == -1)
    {
        result += FindPath(node.Left);
    }

    return result;
}

class Node
{
    public int Value { get; set; }
    public Node? Left { get; set; }
    public Node? Right { get; set; }
    public Node? Top { get; set; }
    public Node? Bottom { get; set; }
    public bool IsVisited { get; set; }

    public Node()
    {
        IsVisited = false;
    }
}