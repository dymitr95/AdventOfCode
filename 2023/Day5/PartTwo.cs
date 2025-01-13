namespace Day5;

public class PartTwo
{
    public ulong Run(string input)
    {
        var seeds = GetSeeds(input);
        var maps = new List<List<Map>>();

        var mapsInput = input.Split("\r\n\r\n");
        for (var i = 1; i < mapsInput.Length; i++)
        {
            maps.Add(GetMap(mapsInput[i].Split(":\r\n")[1]));
        }

        ulong min = 0;

        for (var i = 0; i < seeds.Count; i += 2)
        {
            
            var range = seeds[i + 1];
            for (var j = seeds[i]; j < seeds[i] + range; j++)
            {
                var number = j;
                foreach (var map in maps)
                {
                    var res = GetNumber(number, map);
                    number = res;
                }

                if (min == 0)
                {
                    min = number;
                }
                else if (min > number)
                {
                    min = number;
                }
            }
        }


        return min;
    }


    private ulong GetNumber(ulong sourceNumber, List<Map> map)
    {
        foreach (var mapElement in map)
        {
            if (sourceNumber >= (ulong)mapElement.Source &&
                sourceNumber <= (ulong)mapElement.Source + (ulong)mapElement.Length)
            {
                return sourceNumber + (ulong)(mapElement.Destination - mapElement.Source);
            }
        }

        return sourceNumber;
    }


    private List<ulong> GetSeeds(string input)
    {
        var output = new List<ulong>();
        var seedsRow = input.Split("\r\n")[0];
        var seeds = seedsRow.Split(": ")[1];

        output.AddRange(seeds.Split(" ").Select(s => Convert.ToUInt64(s)));

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