namespace _2019.Day5;

public class Day5Part1 : Part<int>
{
    public override int Run(string input)
    {
        var instructions = input.Split(",").Select(x => Convert.ToInt32(x)).ToList();

        var computerInput = new Queue<int>();
        computerInput.Enqueue(1);

        var res = RunComputer(instructions, computerInput);
        
        return res;
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
                    resultValue = instructions[currentPosition + 1];
                    output.Add(instructions[resultValue]);
                    
                    currentPosition += 2;
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