namespace _2018.Day5;

public class Day5Part1 : Part<int>
{
    public override int Run(string input)
    {
        
        var result = ProcessPolymers(input);
        

        return result;
    }

    private static int ProcessPolymers(string input)
    {
        var result = 0;
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