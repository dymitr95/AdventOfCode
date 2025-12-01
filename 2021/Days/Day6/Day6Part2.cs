using _2021.Structure;

namespace _2021.Days.Day6;

public class Day6Part2 : Part<ulong>
{
  public override ulong Run(string input)
    {
        var numbers = input.Split(",");
        
        var fishes = numbers.Select(number => Convert.ToInt32(number)).ToList();

        var numbersCountInitStart = new Dictionary<int, ulong>
        {
            {0,0},
            {1,0},
            {2,0},
            {3,0},
            {4,0},
            {5,0},
            {6,0},
            {7,0},
            {8,0}
        };

        var numbersCount = new Dictionary<int, ulong>(numbersCountInitStart);
        var numbersCountInit = new Dictionary<int, ulong>(numbersCountInitStart);
        
        foreach (var fish in fishes)
        {
            numbersCountInit[fish] += 1;
        }
        
        for (var i = 0; i < 32; i++)
        {
            numbersCount[0] += numbersCountInit[8] + numbersCountInit[1];
            numbersCount[1] += numbersCountInit[0] + numbersCountInit[2];
            numbersCount[2] += numbersCountInit[1] + numbersCountInit[3];
            numbersCount[3] += numbersCountInit[2] + numbersCountInit[4];
            numbersCount[4] += numbersCountInit[3] + numbersCountInit[5];
            numbersCount[5] += numbersCountInit[4] + numbersCountInit[6];
            numbersCount[6] += numbersCountInit[0] + numbersCountInit[5] + numbersCountInit[7];
            numbersCount[7] += numbersCountInit[6];
            numbersCount[8] += numbersCountInit[0] + numbersCountInit[7];

            numbersCountInit = new Dictionary<int, ulong>(numbersCount);
            numbersCount = new Dictionary<int, ulong>(numbersCountInitStart);
        }

        return numbersCountInit.Keys.Aggregate<int, ulong>(0, (current, number) => (ulong)(current + numbersCountInit[number]));
    }
    
}