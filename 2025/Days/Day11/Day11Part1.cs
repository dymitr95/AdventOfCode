using _2025.Structure;

namespace _2025.Days.Day11;

public class Day11Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        
        var nodes = ParseInput(rows);

        var startNode = nodes.FirstOrDefault(n => n.Value == "you");
        var targetNode = nodes.FirstOrDefault(n => n.Value == "out");

        if (startNode == null || targetNode == null)
        {
            return -1;
        }
        
        var paths = new List<List<string>>();

        FindPaths(startNode, targetNode, nodes, [], [], paths);

        return paths.Count;
    }


    private static void FindPaths(Node node, Node target, List<Node> graph,
        List<string> visitedNodes, List<string> path, List<List<string>> paths)
    {
        path.Add(node.Value);
        visitedNodes.Add(node.Value);

        if (node.Value == target.Value)
        {
            paths.Add([..path]);
            path.Remove(node.Value);
            visitedNodes.Remove(node.Value);
            return;
        }

        foreach (var child in node.ChildrenNodes)
        {
            if (visitedNodes.Contains(child))
            {
                continue;
            }

            var childNode = graph.First(n => n.Value == child);
            FindPaths(childNode, target, graph, visitedNodes, path, paths);
        }

        path.Remove(node.Value);
        visitedNodes.Remove(node.Value);
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

public class Node(string value)
{
    public string Value { get; set; } = value;
    public List<string> ChildrenNodes { get; set; } = [];
}