using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day06;

public class Day6Part1 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0L;

        var problemsList = ParseInput(rows);

        for (var i = 0; i < problemsList[0].Length; i++)
        {
            var operation = problemsList[^1][i];
            var problemResult = long.Parse(problemsList[^2][i]);
            for (var j = problemsList.Length - 3; j >= 0; j--)
            {
                if (operation == "+")
                {
                    problemResult += long.Parse(problemsList[j][i]);
                }
                else
                {
                    problemResult *= long.Parse(problemsList[j][i]);
                }
            }

            result += problemResult;
        }
        
        return result;
    }


    private static string[][] ParseInput(string[] rows)
    {
        var problemsList = new string[rows.Length][];

        for (var i = 0; i < rows.Length; i++)
        {
            var data = Regex.Split(rows[i], @"\s+").Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

            problemsList[i] = data;

        }

        return problemsList;
    }
    
}