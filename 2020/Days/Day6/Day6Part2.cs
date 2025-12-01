using System.Text.RegularExpressions;
using _2020.Structure;

namespace _2020.Days.Day6;

public class Day6Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var groupAnswers = new Dictionary<char, int>();
        var groupSize = 0;
        
        var result = 0;
        
        foreach(var row in rows)
        {
            if (row == "")
            {
                result += GetCommonAnswersCount(groupAnswers, groupSize);
                groupSize = 0;
                groupAnswers = [];
                continue;
            }
            
            GetYesAnswers(groupAnswers, row);
            groupSize++;
        }

        result += GetCommonAnswersCount(groupAnswers, groupSize);
        
        return result;
    }


    private static void GetYesAnswers(Dictionary<char, int> groupAnswers, string answers)
    {
        foreach (var answer in answers.Where(answer => !groupAnswers.TryAdd(answer, 1)))
        {
            groupAnswers[answer] += 1;
        }
    }

    private static int GetCommonAnswersCount(Dictionary<char, int> groupAnswers, int groupSize)
    {
        return groupAnswers.Keys.Count(answer => groupAnswers[answer] == groupSize);
    }
}
