using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _2016.Day5;

public class Day5Part2 : Part<string>
{
    public override string Run(string input)
    {
        var result = new char[8];
        var inserted = 0;
        
        for (var i = 0;; i++)
        {
            var hash = GetMd5Hash(input + i);
            
            if (!hash.StartsWith("00000")) continue;
            if(hash[5] < 48 || hash[5] > 55) continue;
            
            var position = Convert.ToInt32(hash[5].ToString());
            
            if(result[position] != 0) continue;
            
            var symbol = hash[6];
            result[position] = symbol;
            inserted++;
            if(inserted == 8) break;
        }
        
        
        
        return string.Join("", result);
    }

    private static string GetMd5Hash(string input)
    {
        using var md5 = MD5.Create();
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        
        var sb = new StringBuilder();
        foreach (byte b in hashBytes)
            sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
    
}