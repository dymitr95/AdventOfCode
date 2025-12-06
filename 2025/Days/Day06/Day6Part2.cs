using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day06;

public class Day6Part2 : Part<long>
{
    public override long Run(string input)
    {
        var rows = input.Split("\r\n");
        var result = 0L;

        var operations = Regex.Split(rows[^1], @"\s+").Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        
        rows = rows.Take(rows.Length - 1).Select(r => r.Replace(" ", "0")).ToArray();
        
        var problemsList = ParseInput(rows);

        var partialResult = 1L;
        var currentOperatorIndex = 0;
        
        for (var col = 0; col < problemsList[0].Length; col++)
        {
            var column = problemsList.Take(problemsList.Length)
                .Select(r => r[col]).ToArray();

            var numberStr = string.Concat(column.Where(c => c != "0"));

            if (numberStr == "")
            {
                if (operations[currentOperatorIndex] == "+")
                {
                    partialResult -= 1;
                }

                result += partialResult;
                currentOperatorIndex += 1;
                partialResult = 1L;
                continue;
            }

            var number = long.Parse(numberStr);
            
            if (operations[currentOperatorIndex] == "*")
            {
                partialResult *= number;
            }
            else
            {
                partialResult += number;
            }
        }

        if (operations[currentOperatorIndex] == "+")
        {
            partialResult -= 1;
        }
        
        result += partialResult;
        
        return result;
    }


    private static string[][] ParseInput(string[] rows)
    {
        var problemsList = new string[rows.Length][];

        for (var i = 0; i < rows.Length; i++)
        {
            var data = rows[i].ToCharArray().Select(c => c.ToString()).ToArray();
            problemsList[i] = data;
        }

        return problemsList;
    }

    
}