namespace Day9;

public class PartTwo
{
    public int Run(string input)
    {
        var result = 0;

        var sequences = GetSequences(input);


        foreach (var sequence in sequences)
        {
            var lastValues = new List<int>();

            var newSequence = sequence;
            lastValues.Add(newSequence[0]);
            
            while (true)
            {
                newSequence = ProcessSequence(newSequence);
                if (newSequence.Count == 0)
                {
                    break;
                }
                if (newSequence.All(v => v == 0))
                {
                    result += Extrapolate(lastValues);
                    break;
                }
                lastValues.Add(newSequence[0]);
            }
        }
        
        return result;
    }


    private int Extrapolate(List<int> numbers)
    {
        var result = 0;

        for (var i = numbers.Count - 1; i >= 0; i--)
        {
            result = numbers[i] - result;
        }

        return result;
    }

    private List<int> ProcessSequence(List<int> sequence)
    {
        var output = new List<int>();

        for (var i = 1; i < sequence.Count; i++)
        {
            output.Add(sequence[i] - sequence[i - 1]);
        }

        return output;
    }


    private List<List<int>> GetSequences(string input)
    {
        var output = new List<List<int>>();

        var data = input.Split("\r\n");

        foreach (var row in data)
        {
            var values = row.Split(" ");
            var sequence = new List<int>();
            foreach (var value in values)
            {
                sequence.Add(Convert.ToInt32(value));
            }
            output.Add(sequence);
        }
        

        return output;
    }
}