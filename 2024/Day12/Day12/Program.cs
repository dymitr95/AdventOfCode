const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var result = 0;

var map = PrepareMap(dataString);
var visitedCoordinates = new List<Coordinates>();

var garden = PreparePlots(map);

for (var i = 0; i < garden.Length; i++)
{
    for (var j = 0; j < garden[i].Length; j++)
    {
        if (garden[i][j] == null)
        {
            continue;
        }

        var perimeter = CalculatePerimeter(garden[i][j]);
        ResetPlants();
        var area = CalculateArea(garden[i][j], 0, "s");

        result += perimeter * area;
        RemovePlots();
    }
}

void ResetPlants()
{
    for (var i = 0; i < garden.Length; i++)
    {
        for (var j = 0; j < garden[i].Length; j++)
        {
            if (garden[i][j] == null)
            {
                continue;
            }

            garden[i][j].Reset();
        }
    }
}

//result = CalculateArea(garden[1][3], 0, "s");


void RemovePlots()
{
    foreach (var coordinates in visitedCoordinates)
    {
        garden[coordinates.Y][coordinates.X] = null;
    }

    visitedCoordinates = new List<Coordinates>();
}

int CalculatePerimeter(Plot plot)
{
    if (plot.IsVisited)
    {
        return 0;
    }

    visitedCoordinates.Add(new Coordinates(plot.X, plot.Y));
    plot.IsVisited = true;

    var localResult = 1;

    if (plot.Top != null)
    {
        localResult += CalculatePerimeter(plot.Top);
    }

    if (plot.Bottom != null)
    {
        localResult += CalculatePerimeter(plot.Bottom);
    }

    if (plot.Left != null)
    {
        localResult += CalculatePerimeter(plot.Left);
    }

    if (plot.Right != null)
    {
        localResult += CalculatePerimeter(plot.Right);
    }

    return localResult;
}

int CalculateArea(Plot plot, int sides, string direction)
{
    if (plot.IsVisited)
    {
        return sides;
    }

    plot.IsVisited = true;


    sides += 4 - plot.Neighbours();


    if (plot.Top != null)
    {
        if (plot.Left == null && plot.Top.IsVisited && plot.Top.Left == null)
        {
            sides--;
        }
        if (plot.Right == null && plot.Top.IsVisited && plot.Top.Right == null)
        {
            sides--;
        }
    }
    
    if (plot.Bottom != null)
    {
        if (plot.Left == null && plot.Bottom.IsVisited && plot.Bottom.Left == null)
        {
            sides--;
        }
        if (plot.Right == null && plot.Bottom.IsVisited && plot.Bottom.Right == null)
        {
            sides--;
        }
    }
    
    if (plot.Left != null)
    {
        if (plot.Top == null && plot.Left.IsVisited && plot.Left.Top == null)
        {
            sides--;
        }
        if (plot.Bottom == null && plot.Left.IsVisited && plot.Left.Bottom == null)
        {
            sides--;
        }
    }
    
    if (plot.Right != null)
    {
        if (plot.Top == null && plot.Right.IsVisited && plot.Right.Top == null)
        {
            sides--;
        }
        if (plot.Bottom == null && plot.Right.IsVisited && plot.Right.Bottom == null)
        {
            sides--;
        }
    }
    

    if (plot.Top != null)
    {
        sides = CalculateArea(plot.Top, sides, "t");
    }

    if (plot.Bottom != null)
    {
        sides = CalculateArea(plot.Bottom, sides, "b");
    }

    if (plot.Left != null)
    {
        sides = CalculateArea(plot.Left, sides, "l");
    }

    if (plot.Right != null)
    {
        sides = CalculateArea(plot.Right, sides, "r");
    }

    return sides;
}

int CalculateSidesToRemove(Plot plot, string direction)
{
    var sides = 0;

    switch (direction)
    {
        case "t":
            return sides;
        case "b":
            return sides;
        case "r":
            return sides;
        case "l":
            return sides;
        default:
            return sides;
    }
}

Plot[][] PreparePlots(string[][] map)
{
    var plots = new Plot[map.Length][];

    for (var i = 0; i < map.Length; i++)
    {
        plots[i] = new Plot[map[i].Length];

        for (var j = 0; j < map[i].Length; j++)
        {
            var plot = new Plot(map[i][j], j, i);

            plots[i][j] = plot;

            if (j != 0)
            {
                if (plots[i][j - 1].Value == plot.Value)
                {
                    plot.Left = plots[i][j - 1];
                    plots[i][j - 1].Right = plot;
                }
            }

            if (i != 0)
            {
                if (plots[i - 1][j].Value == plot.Value)
                {
                    plot.Top = plots[i - 1][j];
                    plots[i - 1][j].Bottom = plot;
                }
            }
        }
    }

    return plots;
}

string[][] PrepareMap(string inputData)
{
    var inputDataSplit = inputData.Split("\r\n");
    var output = new string[inputDataSplit.Length][];

    for (var i = 0; i < output.Length; i++)
    {
        var inputRow = inputDataSplit[i].ToCharArray();
        output[i] = new string[inputRow.Length];

        for (var j = 0; j < output[i].Length; j++)
        {
            output[i][j] = inputRow[j].ToString();
        }
    }

    return output;
}

Console.WriteLine(result);

class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class Plot
{
    public int X { get; set; }
    public int Y { get; set; }

    public string Value { get; set; }

    public Plot? Top { get; set; }
    public Plot? Bottom { get; set; }
    public Plot? Right { get; set; }
    public Plot? Left { get; set; }

    public bool IsVisited { get; set; }

    public Plot()
    {
    }

    public Plot(string value, int x, int y)
    {
        Value = value;
        X = x;
        Y = y;
        IsVisited = false;
    }

    public void Reset()
    {
        IsVisited = false;
    }

    public int Neighbours()
    {
        var result = 0;
        if (Top != null)
        {
            result++;
        }
        if (Bottom != null)
        {
            result++;
        }
        if (Left != null)
        {
            result++;
        }
        if (Right != null)
        {
            result++;
        }

        return result;
    }
}