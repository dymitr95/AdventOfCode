
namespace Day8;

public class PartTwo
{
    public ulong Run(string input)
    {
        ulong result = 1;

        var instructions = GetInstructions(input);

        var nodes = PrepareNodes(input);

        var actualKeys = nodes.Keys.Where(k => k.EndsWith('A')).ToList();

        var paths = new List<int>();

        foreach (var key in actualKeys)
        {
            paths.Add(GetPathLength(key, instructions, nodes));
        }

        foreach (var path in paths)
        {
            result = GetLCM((ulong)path, result);
        }

        return result;
    }



    private int GetPathLength(string actualKey, string instructions, Dictionary<string, List<string>> nodes)
    {
        var result = 0;
        while (true)
        {
            foreach (var instruction in instructions.ToCharArray())
            {
                if (actualKey.EndsWith('Z'))
                {
                    return result;
                }

                var node = nodes[actualKey];

                actualKey = instruction == 'L' ? node[0] : node[1];

                result++;
            }
        }
    }

    
    private ulong GetLCM(ulong a, ulong b)
    {
        return a * b / GetGCD(a, b);
    }

    private ulong GetGCD(ulong a, ulong b)
    {
        while (b != 0)
        {
            ulong temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
    

    private string GetInstructions(string input)
    {
        return input.Split("\r\n")[0];
    }


    private Dictionary<string, List<string>> PrepareNodes(string input)
    {
        var output = new Dictionary<string, List<string>>();
        var nodes = input.Split("\r\n\r\n")[1].Split("\r\n");

        foreach (var node in nodes)
        {
            var nodeName = node.Split(" = ")[0];
            var connectedNodes = node.Split(" = ")[1].Replace("(", "").Replace(")", "").Split(", ");
            var list = new List<string>
            {
                connectedNodes[0],
                connectedNodes[1]
            };
            output.Add(nodeName, list);
        }



        return output;
    }
}