namespace _2019.Day2;

public class Day2Part1 : Part<int>
{
    public override int Run(string input)
    {
        var numbers = input.Split(",");
        var computerInput = new int[numbers.Length];

        for (var i = 0; i < numbers.Length; i++)
        {
            computerInput[i] = Convert.ToInt32(numbers[i]);
        }

        computerInput[1] = 12;
        computerInput[2] = 2;

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