const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var robots = PrepareMap(dataString);

//var map = PrepareResultMap(robots, 101, 103);

//var result = CalculateSafetyIndex(map);

var result = ChristmasTree(robots);

Console.WriteLine(result);


int ChristmasTree(List<Robot> robots)
{
    int res = 0;


    while (true)
    {
        res++;
        foreach (var robot in robots)
        {
            robot.Move(1);
            robot.Position.Y = (robot.Position.Y % 103 + 103 ) % 103;
            robot.Position.X= (robot.Position.X % 101 + 101 ) % 101;
        }

        var positions = robots.Select(r => (r.Position.X, r.Position.Y)).Distinct().Count();

        if (positions == robots.Count)
        {
            Console.WriteLine();

            for (var y = 0; y < 103; y++)
            {
                for (var x = 0; x < 101; x++)
                {
                    Console.Write(robots.Any(r => r.Position.X == x && r.Position.Y == y) ? '#' : '.');
                }

                Console.WriteLine();
            }

            break;
        }
    }

    return res;
}


int CalculateSafetyIndex(int[][] map)
{
    var result = 1;

    var res1 = CalculateIndexForQuarter(map, new Coordinates { X = 0, Y = 0 }, new Coordinates { X = 50, Y = 51 });
    
    var res2 = CalculateIndexForQuarter(map, new Coordinates { X = 51, Y = 0 }, new Coordinates { X = 101, Y = 51 });
    
    var res3 = CalculateIndexForQuarter(map, new Coordinates { X = 0, Y = 52 }, new Coordinates { X = 50, Y = 103 });
    
    var res4 = CalculateIndexForQuarter(map, new Coordinates { X = 51, Y = 52 }, new Coordinates { X = 101, Y = 103 });
    
    
    return res1 * res2 * res3 * res4;
}


int CalculateIndexForQuarter(int[][] map, Coordinates start, Coordinates end)
{
    var result = 0;

    for (var i = start.Y; i < end.Y; i++)
    {
        for (var j = start.X; j < end.X; j++)
        {
            if (map[i][j] != 0)
            {
                result += map[i][j];
            }
        }
    }

    return result;
}


int[][] PrepareResultMap(List<Robot> robots, int width, int height)
{
    var map = new int[height][];
    
    for (var i = 0; i < height; i++)
    {
        map[i] = new int[width];
        
        for (var j = 0; j < width; j++)
        {
            map[i][j] = 0;
        }
    }

    foreach (var robot in robots)
    {
        robot.Move(100);
        int posY = (robot.Position.Y % height + height ) % height;
        int posX = (robot.Position.X % width + width ) % width;
        map[posY][posX] += 1;
    }

    return map;
}


void ShowMap(List<Robot> robots)
{
    var map = new int[7][];
    
    for (var i = 0; i < 7; i++)
    {
        map[i] = new int[11];
        
        for (var j = 0; j < 11; j++)
        {
            map[i][j] = 0;
        }
    }

    foreach (var robot in robots)
    {
        robot.Move(100);
        int posY = (robot.Position.Y % 7 + 7 ) % 7;
        int posX = (robot.Position.X % 11 + 11 ) % 11;
        map[posY][posX] += 1;
    }
    
    for (var i = 0; i < 7; i++)
    {
        for (var j = 0; j < 11; j++)
        {
            if (map[i][j] == 0)
            {
                Console.Write(".");
            }
            else
            {
                Console.Write(map[i][j]);
            }
        }
        Console.Write('\n');
    }
}



List<Robot> PrepareMap(string inputData)
{
    var robots = new List<Robot>();
    var inputSplit = inputData.Split("\r\n");
    
    foreach(var inputDataRow in inputSplit)
    {
        var dataRowSplit = inputDataRow.Split(' ');
        var dataPositionSplit = dataRowSplit[0].Split('=');
        var dataPositionCoords = dataPositionSplit[1].Split(',');
        
        var dataVelocitySplit = dataRowSplit[1].Split('=');
        var dataVelocityCoords = dataVelocitySplit[1].Split(',');

        var robot = new Robot()
        {
            Position = new Coordinates
            {
                X = Convert.ToInt32(dataPositionCoords[0]),
                Y = Convert.ToInt32(dataPositionCoords[1])
            },
            Velocity = new Coordinates
            {
                X = Convert.ToInt32(dataVelocityCoords[0]),
                Y = Convert.ToInt32(dataVelocityCoords[1])
            }
        };
        
        robots.Add(robot);
    }

    return robots;
}


class Robot
{
    public Coordinates Position { get; set; }
    public Coordinates Velocity { get; set; }


    public void Move(int steps)
    {
        Position.X += Velocity.X * steps;
        Position.Y += Velocity.Y * steps;
    }
}

class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
}