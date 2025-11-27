using System.Reflection;

namespace _2019.Day4;

public class Day4Part2 : Part<int>
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
        var digits = new Dictionary<int, int>();
        
        for (var i = 0; i < password.Length; i++)
        {
            var digit = Convert.ToInt32(password[i].ToString());

            if (!digits.TryAdd(digit, 1))
            {
                digits[digit] += 1;
            }
            
            if(i == 0) continue;
            
            if (Convert.ToInt32(password[i].ToString()) < Convert.ToInt32(password[i - 1].ToString()))
            {
                return false;
            }
        }

        return digits.FirstOrDefault(kv => kv.Value == 2).Value != 0;
    }
    
}