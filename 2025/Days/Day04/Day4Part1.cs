using _2025.Structure;

namespace _2025.Days.Day04;

public class Day4Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0;

        var map = GetMap(rows);

        for (var i = 0; i < map.Length; i++)
        {
            for (var j = 0; j < map[0].Length; j++)
            {
                if (map[i][j] == ".")
                {
                    continue;
                }

                if (CanAccess(i, j, map))
                {
                    result++;
                }
            }
        }
        
        return result;
    }


    private static string[][] GetMap(string[] rows)
    {
        var result = new string[rows.Length][];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = new string[rows[i].Length];
            var data = rows[i].ToCharArray();
            
            for (var j = 0; j < result[i].Length; j++)
            {
                result[i][j] = data[j].ToString();
            }
        }

        return result;
    }

    private static bool CanAccess(int posX, int posY, string[][] map)
    {
        var neighborsCount = GetNeighborsCount(posX, posY, map, false);

        return neighborsCount - 1 < 4;
    }


    private static int GetNeighborsCount(int posX, int posY, string[][] map, bool exit)
    {
        var count = 0;

        if (map[posX][posY] == "@")
        {
            count++;
        }
        
        if (posX - 1 >= 0 && map[posX - 1][posY] == "@")
        {
            count++;
        }

        if (posX + 1 < map[0].Length && map[posX + 1][posY] == "@")
        {
            count++;
        }

        if (exit)
        {
            return count;
        }
        
        if (posY - 1 >= 0)
        {
            count += GetNeighborsCount(posX, posY - 1, map, true);
        }
        
        if (posY + 1 < map.Length)
        {
            count += GetNeighborsCount(posX, posY + 1, map, true);
        }

        return count;
    }
    
}