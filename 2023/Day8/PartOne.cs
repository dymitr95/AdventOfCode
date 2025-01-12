namespace Day8;

public class PartOne
{

    public int Run(string input)
    {
        var result = 0;

        var instructions = GetInstructions(input);

        var nodes = PrepareNodes(input);

        var actualKey = "AAA";
        
        while (true)
        {
            foreach (var instruction in instructions.ToCharArray())
            {
                if (actualKey == "ZZZ")
                {
                    return result;
                }

                var node = nodes[actualKey];

                actualKey = instruction == 'L' ? node[0] : node[1];

                result++;
            }
        }
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