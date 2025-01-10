namespace Day5;

public class PartOne
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

        var results = new List<long>();
        
        foreach (var seed in seeds)
        {

            var number = seed;
            foreach (var map in maps)
            {
                var res = GetNumber(number, map);
                number = res;
            }
            results.Add(number);
        }
        
        
        return results.Min();
    }



    private long GetNumber(long sourceNumber, List<Map> map)
    {

        foreach (var mapElement in map)
        {
            if (sourceNumber >= mapElement.Source && sourceNumber <= mapElement.Source + mapElement.Length)
            {
                return sourceNumber + (mapElement.Destination - mapElement.Source);
            }
        }
        
        return sourceNumber;
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