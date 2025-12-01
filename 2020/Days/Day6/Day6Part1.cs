using _2020.Structure;

namespace _2020.Days.Day6;

public class Day6Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var groupAnswers = new HashSet<char>();
        var result = 0;
        
        foreach(var row in rows)
        {
            if (row == "")
            {
                result += groupAnswers.Count;
                groupAnswers = [];
            }
            
            GetYesAnswers(groupAnswers, row);
        }

        result += groupAnswers.Count;
        
        return result;
    }


    private static void GetYesAnswers(HashSet<char> groupAnswers, string answers)
    {
        foreach (var answer in answers)
        {
            groupAnswers.Add(answer);
        }
    }
}