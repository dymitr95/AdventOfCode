using System.Security.Cryptography;
using System.Text;

namespace Day4;

public class PartOne
{

    public int Run(string input)
    {
        var result = 0;


        while (true)
        {
            var data = input + result;
            var hash = GetMd5Hash(data);
            if (hash.StartsWith("00000"))
            {
                break;
            }

            result++;
        }

        return result;
    }


    private string GetMd5Hash(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes(input);
        var hashBytes = MD5.HashData(inputBytes);

        var sb = new StringBuilder();
        foreach (var b in hashBytes)
        {
            sb.Append(b.ToString("x2"));
        }

        var hash = sb.ToString();
        return hash;
    }

}