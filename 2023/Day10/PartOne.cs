namespace Day10;

public class PartOne
{


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

        var results = new List<int>();

        if (map[startY - 1][startX] != ".")
        {
            results.Add(GetPathLength(map, startX, startY - 1, 0, 'b') / 2);
        }
        
        if (map[startY + 1][startX] != ".")
        {
            results.Add(GetPathLength(map, startX, startY + 1, 0, 't') / 2);
        }
        
        if (map[startY][startX + 1] != ".")
        {
            results.Add(GetPathLength(map, startX + 1, startY, 0, 'l') / 2);
        }
        
        if (map[startY][startX - 1] != ".")
        {
            results.Add(GetPathLength(map, startX - 1, startY, 0, 'r') / 2);
        }
        
        return results.Max();
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
            output[i] = new string[splitInput.Length];
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
                if (IsPartOfLoop(map[i][j], map, j, i))
                {
                    output[i][j] = map[i][j];
                }
                else
                {
                    output[i][j] = ".";
                }
            }
        }


        return output;
    }
    
    private bool IsPartOfLoop(string pipe, string[][] map, int x, int y)
    {
        switch (pipe)
        {
            case "S":
            case ".":
                return true;
            case "|":
                return y - 1 >= 0 && (map[y - 1][x] == "|" || map[y - 1][x] == "7" || map[y - 1][x] == "F" || map[y - 1][x] == "S")
                    && y + 1 < map.Length && (map[y + 1][x] == "|" || map[y + 1][x] == "L" || map[y + 1][x] == "J" || map[y + 1][x] == "S");
            case "-":
                return x - 1 >= 0 && (map[y][x - 1] == "-" || map[y][x - 1] == "L" || map[y][x - 1] == "F" || map[y][x - 1] == "S")
                                  && x + 1 < map[0].Length && (map[y][x + 1] == "-" || map[y][x + 1] == "J" || map[y][x + 1] == "7" || map[y][x + 1] == "S");
            case "L":
                return y - 1 >= 0 && (map[y - 1][x] == "|" || map[y - 1][x] == "7" || map[y - 1][x] == "F" || map[y - 1][x] == "S")
                                  && x + 1 < map.Length && (map[y][x + 1] == "-" || map[y][x + 1] == "J" || map[y][x + 1] == "7" || map[y][x + 1] == "S");
            case "J":
                return y - 1 >= 0 && (map[y - 1][x] == "|" || map[y - 1][x] == "7" || map[y - 1][x] == "F" || map[y - 1][x] == "S")
                                  && x - 1 >= 0 && (map[y][x - 1] == "-" || map[y][x - 1] == "L" || map[y][x - 1] == "F" || map[y][x - 1] == "S");
            case "7":
                return x - 1 >= 0 && (map[y][x - 1] == "-" || map[y][x - 1] == "L" || map[y][x - 1] == "F" || map[y][x - 1] == "S")
                                  && y + 1 < map.Length && (map[y + 1][x] == "|" || map[y + 1][x] == "L" || map[y + 1][x] == "J" || map[y + 1][x] == "S");
            case "F":
                return x + 1 < map[0].Length && (map[y][x + 1] == "-" || map[y][x + 1] == "J" || map[y][x + 1] == "7" || map[y][x + 1] == "S")
                                             && y + 1 < map.Length && (map[y + 1][x] == "|" || map[y + 1][x] == "L" || map[y + 1][x] == "J" || map[y + 1][x] == "S");
        }

        return false;
    }
}