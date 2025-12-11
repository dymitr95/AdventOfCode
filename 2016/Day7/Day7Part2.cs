using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace _2016.Day7;

public class Day7Part2 : Part<int>
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

            var babs = new HashSet<string>();

            foreach (var sequenceBabs in dataSequences.Select(GetBabs))
            {
                babs.UnionWith(sequenceBabs);
            }

            if (hypernetSequences.Any(sequence => ContainsBab(sequence, babs)))
            {
                result++;
            }
        }
        

        return result;
    }

    private static HashSet<string> GetBabs(string sequence)
    {
        var babs = new HashSet<string>();
        
        for (var i = 0; i < sequence.Length - 2; i++)
        {
            var subSequence = sequence.Substring(i, 3);

            if (subSequence[0] == subSequence[2] && subSequence[0] != subSequence[1])
            {
               babs.Add($"{subSequence[1]}{subSequence[0]}{subSequence[1]}");           
            }
        }

        return babs;
    }
    
    private static bool ContainsBab(string sequence, HashSet<string> babs)
    {
       
        for (var i = 0; i < sequence.Length - 2; i++)
        {
            var subSequence = sequence.Substring(i, 3);

            if (babs.Contains(subSequence))
            {
                return true;
            }
        }

        return false;
    }
}