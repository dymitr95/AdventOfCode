namespace Day3;

public class PartOne
{
    public int Run(string inputData)
    {
        var result = 0;
        var valuesAndSymbols = PrepareData(inputData);

        var values = valuesAndSymbols.Item1;
        var symbols = valuesAndSymbols.Item2;

        foreach (var value in values)
        {
            foreach (var coord in value.Coords)
            {
                if (IsAdjacentToSymbol(coord, symbols))
                {
                    result += Convert.ToInt32(value.Val);
                    break;
                }
            }
        }

        return result;
    }
    
    
    
    


    private bool IsAdjacentToSymbol(Coord valueCoord, List<Coord> coords)
    {
        //UP
        if (coords.FirstOrDefault(c => c.X == valueCoord.X && c.Y == valueCoord.Y - 1) != null)
        {
            return true;
        }

        //DOWN
        if (coords.FirstOrDefault(c => c.X == valueCoord.X && c.Y == valueCoord.Y + 1) != null)
        {
            return true;
        }

        //LEFT
        if (coords.FirstOrDefault(c => c.X == valueCoord.X - 1 && c.Y == valueCoord.Y) != null)
        {
            return true;
        }

        //RIGHT
        if (coords.FirstOrDefault(c => c.X == valueCoord.X + 1 && c.Y == valueCoord.Y) != null)
        {
            return true;
        }

        //TOP LEFT
        if (coords.FirstOrDefault(c => c.X == valueCoord.X - 1 && c.Y == valueCoord.Y - 1) != null)
        {
            return true;
        }

        //TOP RIGHT
        if (coords.FirstOrDefault(c => c.X == valueCoord.X + 1 && c.Y == valueCoord.Y - 1) != null)
        {
            return true;
        }

        //BOTTOM LEFT
        if (coords.FirstOrDefault(c => c.X == valueCoord.X - 1 && c.Y == valueCoord.Y + 1) != null)
        {
            return true;
        }

        //BOTTOM RIGHT
        if (coords.FirstOrDefault(c => c.X == valueCoord.X + 1 && c.Y == valueCoord.Y + 1) != null)
        {
            return true;
        }

        return false;
    }


    private (List<Value>, List<Coord>) PrepareData(string input)
    {
        var dataSplit = input.Split("\r\n");

        var values = new List<Value>();
        var symbols = new List<Coord>();

        for (var i = 0; i < dataSplit.Length; i++)
        {
            var dataRow = dataSplit[i].ToCharArray();

            Value value = null;

            for (var j = 0; j < dataRow.Length; j++)
            {
                if (dataRow[j] == '.')
                {
                    if (value != null)
                    {
                        values.Add(value);
                        value = null;
                    }

                    continue;
                }

                if (Convert.ToInt32(dataRow[j]) < 48 || Convert.ToInt32(dataRow[j]) > 57)
                {
                    if (value != null)
                    {
                        values.Add(value);
                        value = null;
                    }
                    
                    symbols.Add(new Coord(j, i));
                    
                    continue;
                }

                if (Convert.ToInt32(dataRow[j]) >= 48 && Convert.ToInt32(dataRow[j]) <= 57)
                {
                    if (value == null)
                    {
                        value = new Value();
                        value.Coords.Add(new Coord(j, i));
                        value.Val += dataRow[j].ToString();
                    }
                    else
                    {
                        value.Coords.Add(new Coord(j, i));
                        value.Val += dataRow[j].ToString();
                    }
                    
                }
            }

            if (value != null)
            {
                values.Add(value);
            }
        }

        return (values, symbols);
    }
}

class Value
{
    public int Id { get; set; }
    public string Val { get; set; }
    public HashSet<Coord> Coords { get; set; }

    public Coord GearPosition { get; set; }

    public Value()
    {
        Coords = new HashSet<Coord>();
    }
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