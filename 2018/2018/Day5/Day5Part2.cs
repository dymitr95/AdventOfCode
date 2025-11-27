namespace _2018.Day5;

public class Day5Part2 : Part<int>
{
    public override int Run(string input)
    {
        
        var minResult = int.MaxValue;
        
        for (var i = 65; i < 91; i++)
        {
            var polymer = Convert.ToChar(i).ToString();
            var lowercasePolymer = Convert.ToChar(i + 32).ToString();
            
            var originalInput = input;
            originalInput = originalInput.Replace(polymer, "").Replace(lowercasePolymer, "");
            
            var result = ProcessPolymers(originalInput);
            if (result < minResult)
            {
                minResult = result;
            }
        }

        return minResult;
    }

    private static int ProcessPolymers(string input)
    {
        var index = 0;
        
        while (true)
        {
            if (index == input.Length - 1)
            {
                break;
            }
            
            var actualPolymerCode = Convert.ToInt32(input[index]);
            var nextPolymerCode = Convert.ToInt32(input[index + 1]);

            if (actualPolymerCode - 32 == nextPolymerCode || actualPolymerCode + 32 == nextPolymerCode)
            {
                input = input.Remove(index, 2);
                if (index != 0)
                {
                    index--;
                }
            }
            else
            {
                index++;
            }
        }
        
        return input.Length;
    }
    
}