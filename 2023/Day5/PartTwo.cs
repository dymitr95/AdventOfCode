namespace Day5;

public class PartTwo
{
    public long Run(string input)
    {
        var seeds = GetSeeds(input);
        var maps = new List<List<Map>>();

        var mapsInput = input.Split("\r\n\r\n");
        for (var i = 1; i < mapsInput.Length; i++)
        {
            maps.Add(GetMap(mapsInput[i].Split(":\r\n")[1]));
        }

        long min = -1;

        for (var i = 0; i < seeds.Count; i += 2)
        {
            var number = seeds[i];
            var range = seeds[i + 1];
            foreach (var map in maps)
            {
                var res = GetNumber(number, range, map);
                number = res;
            }

            if (min == -1)
            {
                min = number;
            }
            else if (min > number)
            {
                min = number;
            }
        }


        return min;
    }


    private long GetNumber(long sourceNumber, long range, List<Map> map)
    {
        var min = sourceNumber;

        foreach (var mapElement in map)
        {
            if (sourceNumber >= mapElement.Source && sourceNumber <= mapElement.Source + mapElement.Length)
            {
                var number = sourceNumber + (mapElement.Destination - mapElement.Source);
                var newRange = range - (mapElement.Source + mapElement.Length - sourceNumber);
                var nextNumber = mapElement.Source + mapElement.Length + 1;
                if (newRange > 0)
                {
                    var res = GetNumber(nextNumber, newRange, map);
                    return number > res ? res : number;
                }
            }
        }

        return min;
    }


    private List<long> GetSeeds(string input)
    {
        var output = new List<long>();
        var seedsRow = input.Split("\r\n")[0];
        var seeds = seedsRow.Split(": ")[1];

        output.AddRange(seeds.Split(" ").Select(s => Convert.ToInt64(s)));

        return output;
    }

    private List<Map> GetMap(string inputMap)
    {
        var output = new List<Map>();

        var rows = inputMap.Split("\r\n");

        foreach (var row in rows)
        {
            var data = row.Split(" ");
            var source = Convert.ToInt64(data[1]);
            var destination = Convert.ToInt64(data[0]);
            var length = Convert.ToInt64(data[2]);

            output.Add(new Map(source, destination, length));
        }


        return output;
    }
}