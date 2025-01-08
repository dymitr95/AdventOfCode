const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();
var guard = new Guard();

var map = PrepareMap(dataString);

var result = 0;

while (guard.PosX >= 0 && guard.PosY >= 0 && guard.PosY < map.Length && guard.PosX < map[0].Length)
{
    if (guard.CanMove(map))
    {
        map[guard.PosY][guard.PosX] = "X";
        guard.Move();
    }
    else
    {
        guard.Rotate();
    }
}

guard.Reset();

for (var i = 0; i < map.Length; i++)
{
    for (var j = 0; j < map[i].Length; j++)
    {
        if (!map[i][j].Equals("X"))
        {
            continue;
        }

        map[i][j] = "0";
        
        while (guard.PosX >= 0 && guard.PosY >= 0 && guard.PosY < map.Length && guard.PosX < map[0].Length)
        {
            if (guard.CanMove(map))
            {
                guard.Move();
            }
            else
            {
                if (guard.IsObstacleVisited())
                {
                    result++;
                    break;
                }
                guard.Rotate();
            }
        }
        
        map[i][j] = "X";
        guard.Reset();

    }
}

string[][] PrepareMap(string inputData)
{
    var dataArr = inputData.Split("\r\n");
    var outputMap = new string[dataArr.Length][];
    for (var i = 0; i < dataArr.Length; i++)
    {
        var row = dataArr[i].ToCharArray();
        outputMap[i] = new string[row.Length];
        for (var j = 0; j < row.Length; j++)
        {
            if (row[j].Equals('^'))
            {
                guard = new Guard(j, i, PositionWay.Front);
                outputMap[i][j] = "X";
            }
            else
            {
                outputMap[i][j] = row[j].ToString();
            }
        }
    }

    return outputMap;
}

//result = map.Sum(t => t.Count(t1 => t1.Equals("X")));



Console.WriteLine(result);


class Guard
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    private int StartPosX { get; set; }
    private int StartPosY { get; set; }
    public PositionWay PositionWay { get; set; }
    private PositionWay StartPositionWay { get; set; }
    
    public List<Obstacle> VisitedObstacles { get; set; }
    public int LoopsCount { get; set; }
    
    public Guard(int posX, int posY, PositionWay positionWay)
    {
        this.PosX = posX;
        this.PosY = posY;
        StartPosX = posX;
        StartPosY = posY;
        this.PositionWay = positionWay;
        StartPositionWay = positionWay;
        LoopsCount = 0;
        VisitedObstacles = new List<Obstacle>();
    }

    public Guard()
    {
        
    }

    public void Rotate()
    {
        this.PositionWay = PositionWay switch
        {
            PositionWay.Front => PositionWay.Right,
            PositionWay.Back => PositionWay.Left,
            PositionWay.Left => PositionWay.Front,
            PositionWay.Right => PositionWay.Back,
            _ => this.PositionWay
        };
    }

    public void Move()
    {
        switch (PositionWay)
        {
            case PositionWay.Front:
                this.PosY -= 1;
                break;
            case PositionWay.Back:
                this.PosY += 1;
                break;
            case PositionWay.Left:
                this.PosX -= 1;
                break;
            case PositionWay.Right:
                this.PosX += 1;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public bool CanMove(string[][] map)
    {
        try
        {
            switch (PositionWay)
            {
                case PositionWay.Front:
                    switch (map[PosY - 1][PosX])
                    {
                        case "#":
                            return false;
                        case "0":
                            LoopsCount++;
                            return false;
                        default:
                            return true;
                    }
                case PositionWay.Back:
                    switch (map[PosY + 1][PosX])
                    {
                        case "#":
                            return false;
                        case "0":
                            LoopsCount++;
                            return false;
                        default:
                            return true;
                    }
                case PositionWay.Left:
                    switch (map[PosY][PosX - 1])
                    {
                        case "#":
                            return false;
                        case "0":
                            LoopsCount++;
                            return false;
                        default:
                            return true;
                    }
                case PositionWay.Right:
                    switch (map[PosY][PosX + 1])
                    {
                        case "#":
                            return false;
                        case "0":
                            LoopsCount++;
                            return false;
                        default:
                            return true;
                    }
                default:
                    return true;
            }
        }
        catch (IndexOutOfRangeException e)
        {
            return true;
        }
    }

    public void Reset()
    {
        PosX = StartPosX;
        PosY = StartPosY;
        PositionWay = StartPositionWay;
        LoopsCount = 0;
        VisitedObstacles = new List<Obstacle>();
    }

    public bool IsObstacleVisited()
    {
        switch (PositionWay)
        {
            case PositionWay.Front:
                if (VisitedObstacles.FirstOrDefault(o =>
                        o.PosX == PosX && o.PosY == PosY - 1 && o.PositionWay == PositionWay) != null)
                {
                    return true;
                }

                VisitedObstacles.Add(new Obstacle(PosX, PosY - 1, PositionWay));
                return false;
            case PositionWay.Back:
                if (VisitedObstacles.FirstOrDefault(o =>
                        o.PosX == PosX && o.PosY == PosY + 1 && o.PositionWay == PositionWay) != null)
                {
                    return true;
                }

                VisitedObstacles.Add(new Obstacle(PosX, PosY + 1, PositionWay));
                return false;
            case PositionWay.Left:
                if (VisitedObstacles.FirstOrDefault(o =>
                        o.PosX == PosX - 1 && o.PosY == PosY && o.PositionWay == PositionWay) != null)
                {
                    return true;
                }

                VisitedObstacles.Add(new Obstacle(PosX - 1, PosY, PositionWay));
                return false;
            case PositionWay.Right:
                if (VisitedObstacles.FirstOrDefault(o =>
                        o.PosX == PosX + 1 && o.PosY == PosY && o.PositionWay == PositionWay) != null)
                {
                    return true;
                }

                VisitedObstacles.Add(new Obstacle(PosX + 1, PosY, PositionWay));
                return false;
            default:
                return true;
        }
    }
}

class Obstacle
{
    public int PosX { get; set; }
    public int PosY { get; set; }
    public PositionWay PositionWay { get; set; }

    public Obstacle(int posX, int posY, PositionWay positionWay)
    {
        PosX = posX;
        PosY = posY;
        PositionWay = positionWay;
    }
}

internal enum PositionWay
{
    Front = 1,
    Back,
    Left,
    Right
}