using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _2016.Day5;

public class Day5Part1 : Part<string>
{
    public override string Run(string input)
    {
        var result = "";
        
        for (var i = 0;; i++)
        {
            var hash = GetMd5Hash(input + i);
            if (!hash.StartsWith("00000")) continue;
            result += hash[5];
            if(result.Length == 8) break;
        }
        
        
        
        return result;
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