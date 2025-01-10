namespace Day4;

public class PartOne
{


    public int Run(string input)
    {
        var result = 0;

        var data = PrepareData(input);
        var winningNumbers = data.Item2;
        var numbers = data.Item1;



        for (var i = 0; i < numbers.Count; i++)
        {
            var multiplicator = false;
            var localResult = 0;
            var winningSequence = winningNumbers[i];
            foreach (var number in numbers[i])
            {
                if (!winningSequence.Contains(number))
                {
                    continue;
                }

                if (multiplicator)
                {
                    localResult *= 2;
                }
                else
                {
                    multiplicator = true;
                    localResult += 1;
                }
            }
            
            result += localResult;
        }
        
        
        return result;
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