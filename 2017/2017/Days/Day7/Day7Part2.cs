using _2017.Structure;

namespace _2017.Days.Day7;

public class Day7Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var programs = GetPrograms(rows);
        ConnectPrograms(programs, rows);

        var unbalancedProgram = new StackedProgram("",1);

        foreach (var program in programs)
        {
            if (!program.Balanced())
            {
                unbalancedProgram = program;
                break;
            }
        }
        
        return unbalancedProgram.GetTargetWeight();
    }

    private static List<StackedProgram> GetPrograms(string[] rows)
    {
        var programs = new List<StackedProgram>();
        
        foreach (var row in rows)
        {
            var data = row.Split(" -> ");
            
            var programName = data[0].Split(" ")[0];
            
            var programWeightString = data[0].Split(" ")[1];
            var programWeight = Convert.ToInt32(programWeightString.Substring(1, programWeightString.Length - 2));
            
            programs.Add(new StackedProgram(programName, programWeight));
        }

        return programs;
    }

    private static void ConnectPrograms(List<StackedProgram> programs, string[] rows)
    {
        foreach (var row in rows)
        {
            var data = row.Split(" -> ");
            
            if(data.Length == 1) continue;

            var programName = data[0].Split(" ")[0];
            var program = programs.First(p => p.Name == programName);
            
            var connectedPrograms = data[1].Split(", ");
            
            foreach (var connectedProgramName in connectedPrograms)
            {
                var connectedProgram = programs.First(p => p.Name == connectedProgramName);
                program.HeldPrograms.Add(connectedProgram);
            }
        }
    }
    
}

public class StackedProgram(string name, int weight)
{
    public string Name { get; set; } = name;
    private int Weight { get; set; } = weight;
    public List<StackedProgram> HeldPrograms { get; set; } = [];

    private int GetWeight()
    {
        var result = Weight;
        
        if (HeldPrograms.Count == 0)
        {
            return result;
        }

        result += HeldPrograms.Sum(heldProgram => heldProgram.GetWeight());

        return result;
    }

    public bool Balanced()
    {
        if (HeldPrograms.Count == 0)
        {
            return true;
        }

        var weights = new List<int>();

        foreach (var program in HeldPrograms)
        {
            weights.Add(program.GetWeight());
        }

        var val = weights[0];
        foreach (var weight in weights)
        {
            if (weight != val)
            {
                return false;
            }
        }

        return true;
    }

    public int GetTargetWeight()
    {
        var dict = new Dictionary<int, int>();

        foreach (var programWeight in HeldPrograms.Select(program => program.GetWeight()).Where(programWeight => !dict.TryAdd(programWeight, 1)))
        {
            dict[programWeight] += 1;
        }

        var targetWeight = dict.First(p => p.Value == dict.Max(p1 => p1.Value)).Key;
        var badValue = dict.First(p => p.Value == dict.Min(p1 => p1.Value)).Key;

        var unbalancedWeight = HeldPrograms.First(p => p.GetWeight() == badValue).Weight;

        if (badValue > targetWeight)
        {
            return unbalancedWeight - (badValue - targetWeight);
        }
        else
        {
            return unbalancedWeight + (targetWeight - badValue);
        }
    }
}