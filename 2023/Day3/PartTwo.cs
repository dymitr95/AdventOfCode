namespace Day3;

public class PartTwo
{
    
    public ulong Run(string inputData)
    {
        ulong result = 0;
        var valuesAndSymbols = PrepareData(inputData);

        var values = valuesAndSymbols.Item1;
        var gears = valuesAndSymbols.Item2;

        var valuesWithGears = new List<Value>();
        
        
        foreach (var value in values)
        {
            foreach (var coord in value.Coords)
            {
                var gearCoord = IsAdjacentToGear(coord, gears);
                if (gearCoord != null)
                {
                    value.GearPosition = gearCoord;
                    valuesWithGears.Add(value);
                    break;
                }
            }
        }
        
        var valuesWithGearsCopy = new List<Value>(valuesWithGears);

        foreach (var value in valuesWithGears)
        {
            var valueCopy = valuesWithGearsCopy.FirstOrDefault(v => v.Id == value.Id);
            if (valueCopy == null)
            {
                continue;
            }
            valuesWithGearsCopy.Remove(valueCopy);

            var secondValue = valuesWithGearsCopy.FirstOrDefault(v =>
                v.GearPosition.X == value.GearPosition.X && v.GearPosition.Y == value.GearPosition.Y);

            if (secondValue == null)
            {
                continue;
            }

            result += Convert.ToUInt64(value.Val) * Convert.ToUInt64(secondValue.Val);
            valuesWithGearsCopy.Remove(secondValue);
        }
        

        return result;
    }


    private Coord? IsAdjacentToGear(Coord valueCoord, List<Gear> gears)
    {
        //UP
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X && c.Coord.Y == valueCoord.Y - 1) != null)
        {
            return new Coord(valueCoord.X, valueCoord.Y - 1);
        }

        //DOWN
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X && c.Coord.Y == valueCoord.Y + 1) != null)
        {
            return new Coord(valueCoord.X, valueCoord.Y + 1);
        }

        //LEFT
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X - 1 && c.Coord.Y == valueCoord.Y) != null)
        {
            return new Coord(valueCoord.X - 1, valueCoord.Y);
        }

        //RIGHT
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X + 1 && c.Coord.Y == valueCoord.Y) != null)
        {
            return new Coord(valueCoord.X + 1, valueCoord.Y);
        }

        //TOP LEFT
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X - 1 && c.Coord.Y == valueCoord.Y - 1) != null)
        {
            return new Coord(valueCoord.X - 1, valueCoord.Y - 1);
        }

        //TOP RIGHT
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X + 1 && c.Coord.Y == valueCoord.Y - 1) != null)
        {
            return new Coord(valueCoord.X + 1, valueCoord.Y - 1);
        }

        //BOTTOM LEFT
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X - 1 && c.Coord.Y == valueCoord.Y + 1) != null)
        {
            return new Coord(valueCoord.X - 1, valueCoord.Y + 1);
        }

        //BOTTOM RIGHT
        if (gears.FirstOrDefault(c => c.Coord.X == valueCoord.X + 1 && c.Coord.Y == valueCoord.Y + 1) != null)
        {
            return new Coord(valueCoord.X + 1, valueCoord.Y + 1);
        }

        return null;
    }


    private (List<Value>, List<Gear>) PrepareData(string input)
    {
        var dataSplit = input.Split("\r\n");

        var values = new List<Value>();
        var gears = new List<Gear>();

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

                    if (dataRow[j] == '*')
                    {
                        gears.Add(new Gear(new Coord(j, i)));
                    }

                    continue;
                }

                if (Convert.ToInt32(dataRow[j]) >= 48 && Convert.ToInt32(dataRow[j]) <= 57)
                {
                    if (value == null)
                    {
                        value = new Value();
                        value.Id = values.Count;
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

        return (values, gears);
    }
}

class Gear
{
    public Coord Coord { get; set; }


    public Gear(Coord coord)
    {
        Coord = coord;
    }
}