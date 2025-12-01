namespace _2019.Day4;

public class Day4Part1 : Part<int>
{
   
    public override int Run(string input)
    {
        var result = 0;

        var range = input.Split("-");
        var start = Convert.ToInt32(range[0]);
        var end = Convert.ToInt32(range[1]);

        for (var i = start; i <= end; i++)
        {
            if (VerifyPassword(i.ToString()))
            {
                result++;
            }
        }
        
        return result;
    }

    private static bool VerifyPassword(string password)
    {
        var haveDouble = false;
        
        for (var i = 1; i < password.Length; i++)
        {
            if (password[i] == password[i - 1])
            {
                haveDouble = true;
                continue;
            }

            if (Convert.ToInt32(password[i].ToString()) < Convert.ToInt32(password[i - 1].ToString()))
            {
                return false;
            }
        }

        return haveDouble;
    }
    
}