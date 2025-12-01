using _2022.Structure;

namespace _2022.Days.Day6;

public class Day6Part2 : Part<int>
{
    public override int Run(string input)
    {

        for (var i = 0; i < input.Length - 13; i++)
        {
            var letters = new HashSet<char>();
            
            for (var j = i; j < i + 14; j++)
            {
                letters.Add(input[j]);
            }

            if (letters.Count == 14)
            {
                return i + 14;
            }
        }
        
        return 0;
    }
}