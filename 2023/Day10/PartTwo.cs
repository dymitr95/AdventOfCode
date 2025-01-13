namespace Day10;

public class PartTwo
{
    Dictionary<string, List<List<int>>> Loop = new Dictionary<string, List<List<int>>>();
    
    public int Run(string input)
    {
        var result = 0;

        var inputMap = ParseInput(input);

        var map = PrepareMap(inputMap);

        var startX = 0;
        var startY = 0;

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                if (map[i][j] != "S") continue;
                startX = j;
                startY = i;
                break;
            }
        }
        
        

        if (startY != 0 && map[startY - 1][startX] != ".")
        {
            var res = GetPathLength(map, startX, startY - 1, 0, 'b') / 2;
            if (result < res)
            {
                result = res;
                Loop = new Dictionary<string, List<List<int>>> { { "S", [] } };
                Loop["S"].Add([startX,startY]);
            }
        }

        if (map[startY + 1][startX] != ".")
        {
            var res = GetPathLength(map, startX, startY + 1, 0, 't') / 2;
            if (result < res)
            {
                result = res;
                Loop = new Dictionary<string, List<List<int>>> { { "S", [] } };
                Loop["S"].Add([startX,startY]);
            }
        }

        if (map[startY][startX + 1] != ".")
        {
            var res = GetPathLength(map, startX + 1, startY, 0, 'l') / 2;
            if (result < res)
            {
                result = res;
                Loop = new Dictionary<string, List<List<int>>> { { "S", [] } };
                Loop["S"].Add([startX,startY]);
            }
        }

        if (map[startY][startX - 1] != ".")
        {
            var res = GetPathLength(map, startX - 1, startY, 0, 'r') / 2;
            if (result < res)
            {
                result = res;
                Loop = new Dictionary<string, List<List<int>>> { { "S", [] } };
                Loop["S"].Add([startX,startY]);
            }
        }

        var loopMap = new string[map.Length][];
        for (var i = 0; i < map.Length; i++)
        {
            loopMap[i] = new string[map[i].Length];
            for (var j = 0; j < map[i].Length; j++)
            {
                loopMap[i][j] = ".";
            }
        }

        foreach (var key in Loop.Keys)
        {
            foreach (var coords in Loop[key])
            {
                loopMap[coords[1]][coords[0]] = key;
            }
        }
        
        PrintMap(loopMap);

        return result;
    }


    private int GetPathLength(string[][] map, int x, int y, int length, char way)
    {
        var stack = new Stack<(string[][], int, int, int, char)>();
        stack.Push((map, x, y, length, way));

        while (stack.Count > 0)
        {
            var data = stack.Pop();
            map = data.Item1;
            x = data.Item2;
            y = data.Item3;
            length = data.Item4;
            way = data.Item5;

            length += 1;

            if (Loop.ContainsKey(map[y][x]))
            {
                Loop[map[y][x]].Add([x,y]);
            }
            else
            {
                Loop.Add(map[y][x], []);
                Loop[map[y][x]].Add([x,y]);
            }

            if (map[y][x] == "S")
            {
                return length;
            }

            if (way == 't')
            {
                if (map[y][x] == "|")
                {
                    stack.Push((map, x, y + 1, length, 't'));
                    continue;
                }

                if (map[y][x] == "L")
                {
                    stack.Push((map, x + 1, y, length, 'l'));
                    continue;
                }

                if (map[y][x] == "J")
                {
                    stack.Push((map, x - 1, y, length, 'r'));
                    continue;
                }
            }

            if (way == 'b')
            {
                if (map[y][x] == "|")
                {
                    stack.Push((map, x, y - 1, length, 'b'));
                    continue;
                }

                if (map[y][x] == "7")
                {
                    stack.Push((map, x - 1, y, length, 'r'));
                    continue;
                }

                if (map[y][x] == "F")
                {
                    stack.Push((map, x + 1, y, length, 'l'));
                    continue;
                }
            }

            if (way == 'r')
            {
                if (map[y][x] == "-")
                {
                    stack.Push((map, x - 1, y, length, 'r'));
                    continue;
                }

                if (map[y][x] == "L")
                {
                    stack.Push((map, x, y - 1, length, 'b'));
                    continue;
                }

                if (map[y][x] == "F")
                {
                    stack.Push((map, x, y + 1, length, 't'));
                    continue;
                }
            }

            if (way == 'l')
            {
                if (map[y][x] == "-")
                {
                    stack.Push((map, x + 1, y, length, 'l'));
                    continue;
                }

                if (map[y][x] == "J")
                {
                    stack.Push((map, x, y - 1, length, 'b'));
                    continue;
                }

                if (map[y][x] == "7")
                {
                    stack.Push((map, x, y + 1, length, 't'));
                    continue;
                }
            }
        }

        return -1;
    }

    private void PrintMap(string[][] map)
    {
        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[i].Length; j++)
            {
                Console.Write(map[i][j]);
            }

            Console.Write("\r\n");
        }
    }

    private string[][] ParseInput(string input)
    {
        var splitInput = input.Split("\r\n");
        var output = new string[splitInput.Length][];

        for (var i = 0; i < splitInput.Length; i++)
        {
            output[i] = new string[splitInput[i].Length];
            for (var j = 0; j < output[i].Length; j++)
            {
                output[i][j] = splitInput[i][j].ToString();
            }
        }

        return output;
    }

    private string[][] PrepareMap(string[][] map)
    {
        var output = new string[map.Length][];

        for (var i = 0; i < map.Length; i++)
        {
            output[i] = new string[map[i].Length];
            for (var j = 0; j < map[i].Length; j++)
            {
                output[i][j] = map[i][j];
            }
        }
        
        return output;
    }
}