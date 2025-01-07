const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var map = PrepareNodesMap(dataString);

long bestResultEver = 999999999999;

List<HashSet<Node>> paths = new List<HashSet<Node>>();

int[][] distances;

var stack = new Stack<(Node node, HashSet<Node> path)>();

var player = new Node();

foreach (var t in map)
{
    foreach (var t1 in t)
    {
        if (t1 != null && t1.IsPlayer)
        {
            player = t1;
            player.Orientation = "R";
            break;
        }
    }
}

Move(player, map);

HashSet<int> uniqueNodes = new HashSet<int>();

foreach (var path in paths)
{
    foreach (var node in path)
    {
        uniqueNodes.Add(node.Id);
    }
}

Console.WriteLine(uniqueNodes.Count);

void Move(Node startNode, Node?[][] nodesMap)
{
    stack.Push((startNode, new HashSet<Node>()));

    while (stack.Count > 0)
    {
        var (currentNode, path) = stack.Pop();
        path.Add(currentNode);
        
        var currentWeight = distances[currentNode.Y][currentNode.X];
        currentNode.BestDistance = currentWeight;

        if (currentNode.Id == 48)
        {
            var l = 1;
        }
        
        if (currentNode.IsFinish)
        {
            if (bestResultEver > currentWeight)
            {
                bestResultEver = currentWeight;
                paths = new List<HashSet<Node>> { new(path) };
            }else if (bestResultEver == currentWeight)
            {
                paths.Add(new HashSet<Node>(path));
            }

            continue;
        }

        var deltaDistance = 0;
        var currentRow = currentNode.Y;
        var currentCol = currentNode.X;

        if (currentRow > 0 && nodesMap[currentRow - 1][currentCol] != null)
        {
            deltaDistance = currentNode.Orientation == "T" ? 1 : 1001;
            var diff = deltaDistance + currentWeight - distances[currentRow - 1][currentCol];
            if (distances[currentRow - 1][currentCol] >= deltaDistance + currentWeight || diff <= 1001)
            {
                var node = nodesMap[currentRow - 1][currentCol];
                distances[currentRow - 1][currentCol] = deltaDistance + currentWeight;
                stack.Push((new Node(node.Id, currentCol, currentRow - 1, node.IsFinish, node.IsPlayer, "T"), new HashSet<Node>(path)));
            }
        }

        if (currentRow < nodesMap.Length - 1 && nodesMap[currentRow + 1][currentCol] != null)
        {
            deltaDistance = currentNode.Orientation == "B" ? 1 : 1001;
            var diff = deltaDistance + currentWeight - distances[currentRow + 1][currentCol];
            if (distances[currentRow + 1][currentCol] >= deltaDistance + currentWeight || diff <= 1001)
            {
                var node = nodesMap[currentRow + 1][currentCol];
                distances[currentRow + 1][currentCol] = deltaDistance + currentWeight;
                stack.Push((new Node(node.Id, currentCol, currentRow + 1, node.IsFinish, node.IsPlayer, "B"), new HashSet<Node>(path)));
            }
        }
        
        if (currentCol > 0 && nodesMap[currentRow][currentCol - 1] != null)
        {
            deltaDistance = currentNode.Orientation == "L" ? 1 : 1001;
            var diff = deltaDistance + currentWeight - distances[currentRow][currentCol - 1];
            if (distances[currentRow][currentCol - 1] >= deltaDistance + currentWeight || diff <= 1001)
            {
                var node = nodesMap[currentRow][currentCol - 1];
                distances[currentRow][currentCol - 1] = deltaDistance + currentWeight;
                stack.Push((new Node(node.Id, currentCol - 1, currentRow, node.IsFinish, node.IsPlayer, "L"), new HashSet<Node>(path)));
            }
        }
        
        if (currentCol < nodesMap[0].Length - 1 && nodesMap[currentRow][currentCol + 1] != null)
        {
            deltaDistance = currentNode.Orientation == "R" ? 1 : 1001;

            var diff = deltaDistance + currentWeight - distances[currentRow][currentCol + 1];
            
            if (distances[currentRow][currentCol + 1] >= deltaDistance + currentWeight || diff <= 1001)
            {
                var node = nodesMap[currentRow][currentCol + 1];
                distances[currentRow][currentCol + 1] = deltaDistance + currentWeight;
                stack.Push((new Node(node.Id, currentCol + 1, currentRow, node.IsFinish, node.IsPlayer, "R"), new HashSet<Node>(path)));
            }
        }
    }
}

Node?[][] PrepareNodesMap(string inputData)
{
    var inputDataSplit = inputData.Split("\r\n");
    var output = new Node?[inputDataSplit.Length][];
    
    distances = new int[output.Length][];
    var id = 0;
    for (var i = 0; i < output.Length; i++)
    {
        var dataRow = inputDataSplit[i].ToCharArray();
        output[i] = new Node[dataRow.Length];
        distances[i] = new int[output[i].Length];
        for (var j = 0; j < output[i].Length; j++)
        {
            output[i][j] = dataRow[j].ToString() switch
            {
                "#" => null,
                "." => new Node(id, j ,i, false, false),
                "E" => new Node(id, j ,i, true, false),
                "S" => new Node(id, j ,i, false, true),
                _ => output[i][j]
            };

            if (dataRow[j].ToString() != "#")
            {
                id++;
            }

            if (dataRow[j].ToString() == "S")
            {
                distances[i][j] = 0;
            }
            else
            {
                distances[i][j] = Int32.MaxValue;
            }
        }
    }

    return output;
}

void PrintMap(Node?[][] nodes, HashSet<Node> path)
{
    for (var i = 0; i < nodes.Length; i++)
    {
        for (var j = 0; j < nodes[i].Length; j++)
        {
            if (nodes[i][j] == null)
            {
                Console.Write("#");
                continue;
            }

            if (nodes[i][j].IsFinish)
            {
                Console.Write("E");
                continue;
            }

            if (nodes[i][j].IsPlayer)
            {
                Console.Write("S");
                continue;
            }

            var node = path.FirstOrDefault(n => n.Id == nodes[i][j].Id);
            if (node != null)
            {
                switch (node.Orientation)
                {
                    case "T":
                        Console.Write("^");
                        break;
                    case "B":
                        Console.Write("v");
                        break;
                    case "L":
                        Console.Write(">");
                        break;
                    case "R":
                        Console.Write("<");
                        break;
                }

                continue;
            }

            Console.Write(".");
        }

        Console.Write("\r\n");
    }
}

class Node
{
    public bool IsPlayer { get; set; }
    public bool IsFinish { get; set; }
    public string Orientation { get; set; }
    public long BestDistance { get; set; }
    public int Id { get; set; }
    
    
    public int X { get; set; }
    public int Y { get; set; }

    public Node()
    {
        BestDistance = 999999999;
        Orientation = "R";
    }

    public Node(int id, int x, int y, bool isFinish, bool isPlayer)
    {
        Id = id;
        X = x;
        Y = y;
        IsFinish = isFinish;
        IsPlayer = isPlayer;
    }
    
    public Node(int id, int x, int y, bool isFinish, bool isPlayer, string orientation)
    {
        Id = id;
        X = x;
        Y = y;
        IsFinish = isFinish;
        IsPlayer = isPlayer;
        Orientation = orientation;
    }
}