namespace Day1;

public class PartTwo
{
    public int Run(string input)
    {
        var result = 0;
        var position = 0;

        foreach (var parenthesis in input)
        {
            position++;
            if (parenthesis == '(')
            {
                result++;
            }
            else
            {
                result--;
            }

            if (result == -1)
            {
                return position;
            }
        }


        return position;
    }
}