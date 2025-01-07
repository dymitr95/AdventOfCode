const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var map = PrepareMap(dataString);

var startPosCoord = GetStartPosition(map);
var endPosCoord = GetEndPosition(map);

var cheatedPositions = new List<Coord>();
var normalPathCost = GetPathCost(map, startPosCoord);

var saves = new Dictionary<int, int>();


for (var i = 0; i < map.Length; i++)
{
    for (var j = 0; j < map[i].Length; j++)
    {
        if (map[i][j] == -1)
        {
            continue;
        }

        var top = CheatTop(map, new Coord(j, i));
        if (top != -1)
        {
            var newPathCost = normalPathCost - top;
            if (saves.ContainsKey(newPathCost))
            {
                saves[newPathCost] += 1;
            }
            else
            {
                saves.Add(newPathCost, 1);
            }
        }
        
        var bottom = CheatBottom(map, new Coord(j, i));
        if (bottom != -1)
        {
            var newPathCost = normalPathCost - bottom;
            if (saves.ContainsKey(newPathCost))
            {
                saves[newPathCost] += 1;
            }
            else
            {
                saves.Add(newPathCost, 1);
            }
        }
        
        var left = CheatLeft(map, new Coord(j, i));
        if (left != -1)
        {
            var newPathCost = normalPathCost - left;
            if (saves.ContainsKey(newPathCost))
            {
                saves[newPathCost] += 1;
            }
            else
            {
                saves.Add(newPathCost, 1);
            }
        }
        
        var right = CheatRight(map, new Coord(j, i));
        if (right != -1)
        {
            var newPathCost = normalPathCost - right;
            if (saves.ContainsKey(newPathCost))
            {
                saves[newPathCost] += 1;
            }
            else
            {
                saves.Add(newPathCost, 1);
            }
        }
        
    }
}


Console.WriteLine($"Normal path cost: {normalPathCost}");
foreach (var save in saves.Keys)
{
    Console.WriteLine($"{saves[save]} cheats saved {save} picoseconds");
}

var cheats = 0;

foreach (var save in saves.Keys)
{
    if (save >= 100)
    {
        cheats += saves[save];
    }
}
Console.WriteLine($"Cheats: {cheats}");
//PrintMap(map);

int CheatTop(int[][] sourceMap, Coord currentCoord)
{
    var map = DeepCopyArray(sourceMap);
    
    //UP
    if (currentCoord.Y - 2 >= 0 
        &&  map[currentCoord.Y - 1][currentCoord.X] == -1
        &&  map[currentCoord.Y - 2][currentCoord.X] != -1)
    {
        var newDistance = map[currentCoord.Y][currentCoord.X] + 2;
        if (map[currentCoord.Y - 2][currentCoord.X] > newDistance)
        {
            var difference = map[currentCoord.Y - 2][currentCoord.X] - newDistance;
            return map[endPosCoord.Y][endPosCoord.X] - difference;
        }
    }

    return -1;
}

int CheatBottom(int[][] sourceMap, Coord currentCoord)
{
    var map = DeepCopyArray(sourceMap);
    
    //DOWN
    if (currentCoord.Y + 2 <= map.Length - 1 
        &&  map[currentCoord.Y + 1][currentCoord.X] == -1
        &&  map[currentCoord.Y + 2][currentCoord.X] != -1)
    {
        var newDistance = map[currentCoord.Y][currentCoord.X] + 2;
        if (map[currentCoord.Y + 2][currentCoord.X] > newDistance)
        {
            var difference = map[currentCoord.Y + 2][currentCoord.X] - newDistance;
            return map[endPosCoord.Y][endPosCoord.X] - difference;
        }
    }

    return -1;
}

int CheatLeft(int[][] sourceMap, Coord currentCoord)
{
    var map = DeepCopyArray(sourceMap);
    
    //LEFT
    if (currentCoord.X - 2 >= 0 
        &&  map[currentCoord.Y][currentCoord.X - 1] == -1
        &&  map[currentCoord.Y][currentCoord.X - 2] != -1)
    {
        var newDistance = map[currentCoord.Y][currentCoord.X] + 2;
        if (map[currentCoord.Y][currentCoord.X - 2] > newDistance)
        {
            var difference = map[currentCoord.Y][currentCoord.X - 2] - newDistance;
            return map[endPosCoord.Y][endPosCoord.X] - difference;
        }
    }

    return -1;
}

int CheatRight(int[][] sourceMap, Coord currentCoord)
{
    var map = DeepCopyArray(sourceMap);
    
    //RIGHT
    if (currentCoord.X + 2 <= map[0].Length - 1
        &&  map[currentCoord.Y][currentCoord.X + 1] == -1
        &&  map[currentCoord.Y][currentCoord.X + 2] != -1)
    {
        var newDistance = map[currentCoord.Y][currentCoord.X] + 2;
        if (map[currentCoord.Y][currentCoord.X + 2] > newDistance)
        {
            var difference = map[currentCoord.Y][currentCoord.X + 2] - newDistance;
            return map[endPosCoord.Y][endPosCoord.X] - difference;
        }
    }

    return -1;
}


int GetPathCost(int[][] map, Coord startPos)
{
    var stack = new Stack<Coord>();
    stack.Push(startPos);

    while (stack.Count > 0)
    {
        var currentCoord = stack.Pop();

        if (map[currentCoord.Y - 1][currentCoord.X] != -1)
        {
            var newDistance = map[currentCoord.Y][currentCoord.X] + 1;
            if (map[currentCoord.Y - 1][currentCoord.X] > newDistance)
            {
                map[currentCoord.Y - 1][currentCoord.X] = newDistance;
                stack.Push(new Coord(currentCoord.X, currentCoord.Y - 1));
            }
        }

        if (map[currentCoord.Y + 1][currentCoord.X] != -1)
        {
            var newDistance = map[currentCoord.Y][currentCoord.X] + 1;
            if (map[currentCoord.Y + 1][currentCoord.X] > newDistance)
            {
                map[currentCoord.Y + 1][currentCoord.X] = newDistance;
                stack.Push(new Coord(currentCoord.X, currentCoord.Y + 1));
            }
        }

        if (map[currentCoord.Y][currentCoord.X - 1] != -1)
        {
            var newDistance = map[currentCoord.Y][currentCoord.X] + 1;
            if (map[currentCoord.Y][currentCoord.X - 1] > newDistance)
            {
                map[currentCoord.Y][currentCoord.X - 1] = newDistance;
                stack.Push(new Coord(currentCoord.X - 1, currentCoord.Y));
            }
        }

        if (map[currentCoord.Y][currentCoord.X + 1] != -1)
        {
            var newDistance = map[currentCoord.Y][currentCoord.X] + 1;
            if (map[currentCoord.Y][currentCoord.X + 1] > newDistance)
            {
                map[currentCoord.Y][currentCoord.X + 1] = newDistance;
                stack.Push(new Coord(currentCoord.X + 1, currentCoord.Y));
            }
        }
    }

    return map[endPosCoord.Y][endPosCoord.X];
}


int[][] DeepCopyArray(int[][] source)
{
    var result = new int[source.Length][];
    for (var i = 0; i < source.Length; i++)
    {
        result[i] = new int[source[i].Length];
        for (var j = 0; j < source[i].Length; j++)
        {
            result[i][j] = source[i][j];
        }
    }

    return result;
}


Coord GetEndPosition(int[][] map)
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            if (map[i][j] == -999999)
            {
                map[i][j] = 999999;
                return new Coord(j, i);
            }
        }
    }

    return null;
}


Coord GetStartPosition(int[][] map)
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            if (map[i][j] == 0)
            {
                return new Coord(j, i);
            }
        }
    }

    return null;
}

void PrintMap(int[][] map)
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            switch (map[i][j])
            {
                case 0:
                    Console.Write("S");
                    break;
                case 999999:
                    Console.Write(".");
                    break;
                case -1:
                    Console.Write("#");
                    break;
            }

            if (i == endPosCoord.Y && j == endPosCoord.X)
            {
                Console.Write("E");
            }
        }

        Console.Write("\r\n");
    }
}


int[][] PrepareMap(string inputData)
{
    var dataSplit = inputData.Split("\r\n");
    var output = new int[dataSplit.Length][];

    for (var i = 0; i < dataSplit.Length; i++)
    {
        var rowData = dataSplit[i].ToCharArray();
        output[i] = new int[rowData.Length];
        for (var j = 0; j < output[i].Length; j++)
        {
            var symbol = rowData[j].ToString();
            output[i][j] = symbol switch
            {
                "#" => -1,
                "." => 999999,
                "S" => 0,
                "E" => -999999,
                _ => output[i][j]
            };
        }
    }

    return output;
}


class Coord
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }
}