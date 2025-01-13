namespace Day1;

public class PartOne
{

    public int Run(string input)
    {
        var result = 0;


        foreach (var parenthesis in input)
        {
            if (parenthesis == '(')
            {
                result++;
            }
            else
            {
                result--;
            }
        }


        return result;
    }

}