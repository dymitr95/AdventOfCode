namespace _2019.Day5;

public class Day5Part2 : Part<int>
{
    public override int Run(string input)
    {
        var numbers = input.Split(",");


        for (var i = 0; i <= 99; i++)
        {
            for (var j = 0; j <= 99; j++)
            {
                var computerInput = GetComputerInput(numbers);
                var result = CalculateResult(computerInput, i, j);
                if (result == 19690720)
                {
                    return 100 * i + j;
                }
            }
        }
        

        return 0;
    }

    private int[] GetComputerInput(string[] numbers)
    {
        var computerInput = new int[numbers.Length];

        for (var i = 0; i < numbers.Length; i++)
        {
            computerInput[i] = Convert.ToInt32(numbers[i]);
        }

        return computerInput;
    }

    private int CalculateResult(int[] computerInput, int noun, int verb)
    {
        computerInput[1] = noun;
        computerInput[2] = verb;
        for (var i = 0; i < computerInput.Length; i += 4)
        {
            var firstIndex = 0;
            var secondIndex = 0;
            var resultIndex = 0;
            switch (computerInput[i])
            {
                case 99:
                    return computerInput[0];
                case 1:
                    firstIndex = computerInput[i + 1];
                    secondIndex = computerInput[i + 2];
                    resultIndex = computerInput[i + 3];
                    computerInput[resultIndex] = computerInput[firstIndex] + computerInput[secondIndex];
                    break;
                case 2:
                    firstIndex = computerInput[i + 1];
                    secondIndex = computerInput[i + 2];
                    resultIndex = computerInput[i + 3];
                    computerInput[resultIndex] = computerInput[firstIndex] * computerInput[secondIndex];
                    break;
            }
        }

        return 0;
    }
}