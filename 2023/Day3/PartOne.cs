namespace Day3;

public class PartOne
{


    public int Run(string inputData)
    {
        var result = 0;
        var valuesAndSymbols = PrepareData(inputData);

        var values = valuesAndSymbols.Item1;
        var symbols = valuesAndSymbols.Item2;

        return result;
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
                    
                    continue;
                }

                symbols.Add(new Coord(j,i));
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
    public string Val { get; set; }
    public HashSet<Coord> Coords { get; set; }


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