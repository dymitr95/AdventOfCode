using System.Text.RegularExpressions;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

Int128 result = 0;

var mul = true;

while (reader.ReadLine() is { } line)
{
    const string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don\'t\(\)";
    var matches = Regex.Matches(line, pattern);
    
    foreach (Match match in matches)
    {
        switch (match.Value)
        {
            case "do()":
                mul = true;
                continue;
            case "don't()":
                mul = false;
                continue;
        }

        if (mul)
        {
            result += Convert.ToInt32(match.Groups[1].Value) * Convert.ToInt32(match.Groups[2].Value);
        }
    }
}

Console.WriteLine(result);