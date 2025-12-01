using _2022.Structure;

namespace _2022.Days.Day6;

public class Day6Part1 : Part<int>
{
    public override int Run(string input)
    {

        for (var i = 0; i < input.Length - 3; i++)
        {
            var letters = new HashSet<char>();
            
            for (var j = i; j < i + 4; j++)
            {
                letters.Add(input[j]);
            }

            if (letters.Count == 4)
            {
                return i + 4;
            }
        }
        
        return 0;
    }
}