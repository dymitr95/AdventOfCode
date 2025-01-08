const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var coordinates = PrepareCoords(dataString);
var map = PrepareMap(71, 71, coordinates, 1024);


//PrintMap(map);





DateTime startTime = DateTime.Now;
var result = 0;
var lastCoord = new Coord(0, 0);

var newMap = ResetMap(map);

var nextByte = 1024;

while (true)
{
    newMap = ResetMap(newMap);
    var nextByteCoord = coordinates[nextByte];
    newMap[nextByteCoord.Y][nextByteCoord.X] = -1;
    nextByte++;
    
    result = FindPath(newMap);

    if (result == 999999)
    {
        lastCoord = nextByteCoord;
        break;
    }
    
}

DateTime endTime = DateTime.Now;
TimeSpan duration = endTime - startTime;
double milliseconds = duration.TotalMilliseconds;
Console.WriteLine(result);
Console.WriteLine($"{lastCoord.X},{lastCoord.Y}");
Console.WriteLine($"Runtime: {milliseconds} ms");


int[][] ResetMap(int[][] map)
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            if (i == 0 && j == 0)
            {
                continue;
            }

            if (map[i][j] != -1)
            {
                map[i][j] = 999999;
            }
        }
    }

    return map;
}

int FindPath(int[][] map)
{
    var startPos = new Coord(0, 0);
    var endPos = new Coord(map.Length - 1, map[0].Length - 1);

    map[startPos.Y][startPos.X] = 0;
    
    var stack = new Stack<Coord>();

    stack.Push(startPos);
    
    while (stack.Count > 0)
    {

        var actualPos = stack.Pop();
        var actualPathPrice = map[actualPos.Y][actualPos.X];

        //UP
        if (actualPos.Y > 0)
        {
            var nextCellPrice = map[actualPos.Y - 1][actualPos.X];
            if (nextCellPrice != -1 && nextCellPrice > actualPathPrice + 1)
            {
                map[actualPos.Y - 1][actualPos.X] = actualPathPrice + 1;
                stack.Push(new Coord(actualPos.X, actualPos.Y - 1));
            }
        }
        
        //DOWN
        if (actualPos.Y < map.Length - 1)
        {
            var nextCellPrice = map[actualPos.Y + 1][actualPos.X];
            if (nextCellPrice != -1 && nextCellPrice > actualPathPrice + 1)
            {
                map[actualPos.Y + 1][actualPos.X] = actualPathPrice + 1;
                stack.Push(new Coord(actualPos.X, actualPos.Y + 1));
            }
        }
        
        //LEFT
        if (actualPos.X > 0)
        {
            var nextCellPrice = map[actualPos.Y][actualPos.X - 1];
            if (nextCellPrice != -1 && nextCellPrice > actualPathPrice + 1)
            {
                map[actualPos.Y][actualPos.X - 1] = actualPathPrice + 1;
                stack.Push(new Coord(actualPos.X - 1, actualPos.Y));
            }
        }
        
        //RIGHT
        if (actualPos.X < map[0].Length - 1)
        {
            var nextCellPrice = map[actualPos.Y][actualPos.X + 1];
            if (nextCellPrice != -1 && nextCellPrice > actualPathPrice + 1)
            {
                map[actualPos.Y][actualPos.X + 1] = actualPathPrice + 1;
                stack.Push(new Coord(actualPos.X + 1, actualPos.Y));
            }
        }

    }


    return map[endPos.Y][endPos.X];
}


void PrintMap(int[][] map)
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            if (map[i][j] == -1)
            {
                Console.Write("#");
                continue;
            }

            if (map[i][j] > 0 && map[i][j] < 999999)
            {
                Console.Write("0");
                continue;
            }
            
            Console.Write(".");
        }
        
        Console.Write("\r\n");
    }
}

int[][] PrepareMap(int sizeX, int sizeY, List<Coord> coords, int bytesCount)
{
    var output = new int[sizeY][];
    
    for (var i = 0; i < sizeY; i++)
    {
        output[i] = new int[sizeX];
        for (var j = 0; j < output[i].Length; j++)
        {
            output[i][j] = 999999;
        }
    }

    for (var i = 0; i < bytesCount; i++)
    {
        var coord = coords[i];

        output[coord.Y][coord.X] = -1;
    }

    return output;
}

List<Coord> PrepareCoords(string inputString)
{
    var output = new List<Coord>();
    var dataSplit = inputString.Split("\r\n");
    foreach (var row in dataSplit)
    {
        var coordsString = row.Split(',');
        var coordX = Convert.ToInt32(coordsString[0]);
        var coordY = Convert.ToInt32(coordsString[1]);
        
        output.Add(new Coord(coordX, coordY));
    }

    return output;
}

public class Coord
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coord(int x, int y)
    {
        X = x;
        Y = y;
    }
}