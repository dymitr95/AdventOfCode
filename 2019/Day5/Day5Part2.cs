namespace _2019.Day5;

public class Day5Part2 : Part<int>
{
    private readonly Queue<int> _computerInput = new();
    
    public override int Run(string input)
    {
        var instructions = input.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        
        SetComputerInput(5);

        var res = RunComputer(instructions, _computerInput);

        return res;
    }

    public void SetComputerInput(int input)
    {
        _computerInput.Enqueue(input);
    }

    private static int RunComputer(List<int> instructions, Queue<int> computerInput)
    {
        var output = new List<int>();
        var currentPosition = 0;

        while (true)
        {
            var instruction = instructions[currentPosition];

            var opcode = instruction % 100;

            var mode1 = (instruction / 100) % 10;
            var mode2 = (instruction / 1000) % 10;
            var mode3 = (instruction / 10000) % 10;

            var firstValue = 0;
            var secondValue = 0;
            var resultValue = 0;

            switch (opcode)
            {
                case 99:
                    return output[^1];
                case 1:
                    firstValue = GetValue(instructions, currentPosition + 1, mode1);
                    secondValue = GetValue(instructions, currentPosition + 2, mode2);
                    resultValue = instructions[currentPosition + 3];

                    instructions[resultValue] = firstValue + secondValue;

                    currentPosition += 4;
                    break;
                case 2:
                    firstValue = GetValue(instructions, currentPosition + 1, mode1);
                    secondValue = GetValue(instructions, currentPosition + 2, mode2);
                    resultValue = instructions[currentPosition + 3];

                    instructions[resultValue] = firstValue * secondValue;

                    currentPosition += 4;
                    break;
                case 3:
                    firstValue = computerInput.Dequeue();
                    resultValue = instructions[currentPosition + 1];
                    instructions[resultValue] = firstValue;

                    currentPosition += 2;
                    break;
                case 4:
                    resultValue = GetValue(instructions, currentPosition + 1, mode1);
                    output.Add(resultValue);

                    currentPosition += 2;
                    break;
                case 5:
                    firstValue = GetValue(instructions, currentPosition + 1, mode1);
                    secondValue = GetValue(instructions, currentPosition + 2, mode2);
                    if (firstValue != 0)
                    {
                        currentPosition = secondValue;
                    }
                    else
                    {
                        currentPosition += 3;
                    }

                    break;
                case 6:
                    firstValue = GetValue(instructions, currentPosition + 1, mode1);
                    secondValue = GetValue(instructions, currentPosition + 2, mode2);
                    if (firstValue == 0)
                    {
                        currentPosition = secondValue;
                    }
                    else
                    {
                        currentPosition += 3;
                    }

                    break;
                case 7:
                    firstValue = GetValue(instructions, currentPosition + 1, mode1);
                    secondValue = GetValue(instructions, currentPosition + 2, mode2);
                    resultValue = instructions[currentPosition + 3];
                    if (firstValue < secondValue)
                    {
                        instructions[resultValue] = 1;
                    }
                    else
                    {
                        instructions[resultValue] = 0;
                    }

                    currentPosition += 4;
                    break;
                case 8:
                    firstValue = GetValue(instructions, currentPosition + 1, mode1);
                    secondValue = GetValue(instructions, currentPosition + 2, mode2);
                    resultValue = instructions[currentPosition + 3];
                    if (firstValue == secondValue)
                    {
                        instructions[resultValue] = 1;
                    }
                    else
                    {
                        instructions[resultValue] = 0;
                    }

                    currentPosition += 4;
                    break;
            }
        }
    }

    private static int GetValue(List<int> instructions, int position, int mode)
    {
        var value = instructions[position];
        return mode == 0 ? instructions[value] : value;
    }
}