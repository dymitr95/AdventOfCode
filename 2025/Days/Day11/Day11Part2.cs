using _2025.Structure;

namespace _2025.Days.Day11;

public class Day11Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");

        var nodes = ParseInput(rows);

        var startNode = nodes.FirstOrDefault(n => n.Value == "svr");
        var targetNode = nodes.FirstOrDefault(n => n.Value == "out");

        if (startNode == null || targetNode == null)
        {
            return -1;
        }

        var cache = new Dictionary<string, long[]>();

        var result = CountPaths(startNode, targetNode, 0, nodes, [], cache);

        return result;
    }


    private static long CountPaths(Node node, Node target, int state, List<Node> graph,
        List<string> visitedNodes, Dictionary<string, long[]> cache)
    {
        if (!cache.ContainsKey(node.Value))
            cache[node.Value] = new long[4];
        
        if (cache[node.Value][state] != 0)
            return cache[node.Value][state] - 1;


        var newState = state;
        if (node.Value == "fft") newState |= 1;
        if (node.Value == "dac") newState |= 2;


        if (node.Value == target.Value)
        {
            long result = newState == 3 ? 1 : 0;
            cache[node.Value][state] = result + 1;
            return result;
        }

        if (node.ChildrenNodes.Count == 0)
        {
            cache[node.Value][state] = 1;
            return 0;
        }

        long count = 0;

        visitedNodes.Add(node.Value);
        
        foreach (var child in node.ChildrenNodes)
        {
            if (visitedNodes.Contains(child))
            {
                continue;
            }

            var childNode = graph.First(n => n.Value == child);
            count += CountPaths(childNode, target, newState, graph, visitedNodes, cache);
        }
            
        visitedNodes.Remove(node.Value);

        cache[node.Value][state] = count + 1;
        return count;
    }


    private static List<Node> ParseInput(string[] rows)
    {
        var nodes = new List<Node>();

        foreach (var row in rows)
        {
            var data = row.Split(": ");
            var node = new Node(data[0]);
            var children = data[1].Split(" ");

            if (nodes.FirstOrDefault(n => n.Value == node.Value) != null)
            {
                node = nodes.FirstOrDefault(n => n.Value == node.Value);
            }
            else
            {
                nodes.Add(node);
            }

            foreach (var childNode in children)
            {
                if (nodes.FirstOrDefault(n => n.Value == childNode) == null)
                {
                    nodes.Add(new Node(childNode));
                }

                node.ChildrenNodes.Add(childNode);
            }
        }

        return nodes;
    }
}