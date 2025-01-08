const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var map = PrepareMap(dataString);

var startPosCoord = GetStartPosition(map);
var endPosCoord = GetEndPosition(map);
var normalPathCost = GetPathCost(map, startPosCoord);

var cheats = Cheat(map, 20);


int Cheat(int[][] map, int maxDistance)
{
    var cheats = 0;

    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            if (map[i][j] == -1)
            {
                continue;
            }

            for (var k = 0; k < map.Length; k++)
            {
                for (var l = 0; l < map[k].Length; l++)
                {
                    if (map[k][l] == -1)
                    {
                        continue;
                    }
                    
                    var distance = Math.Abs(i - k) + Math.Abs(j - l);
                    if (distance > maxDistance)
                    {
                        continue;
                    }

                    if (map[i][j] + distance < map[k][l])
                    {
                      
                        if (map[k][l] - map[i][j] - distance >= 100)
                        {
                            cheats++;
                        }
                    }
                }
            }
            
        }
    }

    return cheats;
}

Console.WriteLine($"Normal path cost: {normalPathCost}");
Console.WriteLine($"Cheats: {cheats}");

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