const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var antennasPositions = new Dictionary<string, List<Position>>();

var map = PrepareMap(dataString);
var antinodesPositions = new List<Position>();

var result = 0;

foreach (var antennaType in antennasPositions.Keys)
{
    var positions = antennasPositions[antennaType];
    for (var i = 0; i < positions.Count - 1; i++)
    {
        for (var j = i + 1; j < positions.Count; j++)
        {
            var actualPosition = positions[i];

            var nextAntennaPosition = positions[j];

            var vector = GetVectorBetweenPoints(actualPosition, nextAntennaPosition);

            try
            {
                for (var k = 1; k < 50; k++)
                {
                    map[actualPosition.Y + vector.ReversedDy * k][actualPosition.X + vector.ReversedDx * k] = "#";
                }
            }
            catch (Exception e)
            {
            }

            try
            {
                for (var k = 1; k < 50; k++)
                {
                    map[nextAntennaPosition.Y + vector.Dy * k][nextAntennaPosition.X + vector.Dx * k] = "#";
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}

for (var i = 0; i < map.Length; i++)
{
    for (var j = 0; j < map[i].Length; j++)
    {
        if (map[i][j] != ".")
        {
            result++;
        }
    }
}


//PrintMap(map);

Console.WriteLine(result);


string[][] PrepareMap(string inputString)
{
    var inputStringSplit = inputString.Split("\r\n");

    var output = new string[inputStringSplit.Length][];

    for (var i = 0; i < inputStringSplit.Length; i++)
    {
        var inputRowArr = inputStringSplit[i].ToCharArray();
        output[i] = new string[inputRowArr.Length];
        for (var j = 0; j < inputRowArr.Length; j++)
        {
            output[i][j] = inputRowArr[j].ToString();


            if (inputRowArr[j].ToString() == ".") continue;

            if (antennasPositions.TryGetValue(output[i][j], out var value))
            {
                value.Add(new Position(j, i));
            }
            else
            {
                antennasPositions.Add(output[i][j], new List<Position>()
                {
                    new(j, i)
                });
            }
        }
    }

    return output;
}

void PrintMap(string[][] map)
{
    for (var i = 0; i < map.Length; i++)
    {
        for (var j = 0; j < map[i].Length; j++)
        {
            Console.Write(map[i][j]);
        }

        Console.Write("\r\n");
    }
}

Vector GetVectorBetweenPoints(Position position1, Position position2)
{
    var dx = position2.X - position1.X;
    var dy = position2.Y - position1.Y;
    var distance = (int)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

    return new Vector(dx, dy, distance);
}

Position FindAntinodePosition(Vector vector, Position antennaPosition, bool reversed = false)
{
    var x = 0;
    var y = 0;
    if (reversed)
    {
        x = antennaPosition.X + vector.Distance * vector.ReversedDx;
        y = antennaPosition.Y + vector.Distance * vector.ReversedDy;
    }
    else
    {
        x = antennaPosition.X + vector.Distance * vector.Dx;
        y = antennaPosition.Y + vector.Distance * vector.Dy;
    }


    return new Position(x, y);
}

class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Vector
{
    public int Dx { get; set; }
    public int Dy { get; set; }
    public int ReversedDx { get; set; }
    public int ReversedDy { get; set; }
    public int Distance { get; set; }

    public Vector(int dx, int dy, int distance)
    {
        Dx = dx;
        Dy = dy;
        Distance = distance;
        ReversedDx = -dx;
        ReversedDy = -dy;
    }
}