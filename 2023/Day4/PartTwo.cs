namespace Day4;

public class PartTwo
{
    public int Run(string input)
    {
        var result = 0;

        var data = PrepareData(input);
        var winningNumbers = data.Item2;
        var numbers = data.Item1;


        var winCount = PrepareWinNumbers(numbers, winningNumbers);
        var cards = new int[winCount.Count];

        for (var i = 0; i < winCount.Count; i++)
        {
            for (var j = cards[i]; j >= 0; j--)
            {
                for (var k = i + 1; k < i + 1 + winCount[i]; k++)
                {
                    cards[k] += 1;
                }
            }
        }
        
        return winCount.Count + cards.Sum();
    }

    private Dictionary<int, int> PrepareWinNumbers(List<List<int>> numbers, List<List<int>> winningNumbers)
    {
        var winCount = new Dictionary<int, int>();

        for (var i = 0; i < numbers.Count; i++)
        {
            winCount.Add(i, 0);
            var winningSequence = winningNumbers[i];
            foreach (var number in numbers[i].Where(number => winningSequence.Contains(number)))
            {
                winCount[i] += 1;
            }
        }

        return winCount;
    }

    private (List<List<int>>, List<List<int>>) PrepareData(string input)
    {
        var winningNumbers = new List<List<int>>();
        var numbers = new List<List<int>>();


        var dataSplit = input.Split("\r\n");

        foreach (var data in dataSplit)
        {
            var winning = new List<int>();
            var numbersList = new List<int>();

            var dataColumns = data.Replace("  ", " ").Split(" | ");

            var winningString = dataColumns[0].Split(": ")[1].Split(" ");
            var numbersString = dataColumns[1].Split(" ");

            winning.AddRange(winningString.Select(winningNumber => Convert.ToInt32(winningNumber)));
            numbersList.AddRange(numbersString.Select(number => Convert.ToInt32(number)));

            winningNumbers.Add(winning);
            numbers.Add(numbersList);
        }

        return (numbers, winningNumbers);
    }
}