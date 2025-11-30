using _2017.Structure;

namespace _2017.Days.Day7;

public class Day7Part1 : Part<string>
{
    
    public override string Run(string input)
    {
        var rows = input.Split("\r\n");

        var programs = new Dictionary<string, int>();

        foreach (var row in rows)
        {
            var data = row.Split(" -> ");
            
            if (!programs.TryAdd(data[0].Split(" ")[0], 1))
            {
                programs[data[0].Split(" ")[0]] += 1;
            }

            if (data.Length == 1)
            {
                continue;
            }

            foreach (var topProgram in data[1].Split(", "))
            {
                if (!programs.TryAdd(topProgram, 1))
                {
                    programs[topProgram] += 1;
                }
            }
        }
        
        return programs.First(p => p.Value == 1).Key;
    }
    
}