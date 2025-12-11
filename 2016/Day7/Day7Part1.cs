using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _2016.Day7;

public class Day7Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;
        var rows = input.Split("\r\n");

        foreach (var row in rows)
        {

            var hypernetSequences = new List<string>();
            var dataSequences = new List<string>();

            var isHypernetSequence = false;

            var hypernetSequence = "";
            var dataSequence = "";

            foreach (var value in row)
            {
                if (value != '[' && value != ']')
                {
                    if (isHypernetSequence)
                    {
                        hypernetSequence += value;
                    }
                    else
                    {
                        dataSequence += value;
                    }
                    continue;
                }

                if (value == '[')
                {
                    isHypernetSequence = true;
                    dataSequences.Add(dataSequence);
                    dataSequence = "";
                    continue;
                }

                if (value != ']') continue;
                isHypernetSequence = false;
                hypernetSequences.Add(hypernetSequence);
                hypernetSequence = "";
            }

            if (!isHypernetSequence)
            {
                dataSequences.Add(dataSequence);
            }

            var abbaInHypernetSequence = hypernetSequences.Any(Abba);

            if (abbaInHypernetSequence)
            {
                continue;
            }

            if (dataSequences.Any(Abba))
            {
                result++;
            }
        }
        

        return result;
    }

    private static bool Abba(string sequence)
    {
        for (var i = 0; i < sequence.Length - 3; i++)
        {
            var subSequence = sequence.Substring(i, 4);

            if (subSequence[0] == subSequence[3] && subSequence[1] == subSequence[2] &&
                subSequence != new string(subSequence[0], 4))
            {
                return true;
            }
        }

        return false;
    }
}