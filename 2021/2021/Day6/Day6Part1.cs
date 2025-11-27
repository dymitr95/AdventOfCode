namespace _2021.Day6;

public class Day6Part1 : Part<int>
{
    public override int Run(string input)
    {
        var numbers = input.Split(",");
        
        var fishes = numbers.Select(number => Convert.ToInt32(number)).ToList();

        for (var i = 0; i < 80; i++)
        {
            var newFishes = 0;
            
            for (var j = 0; j < fishes.Count; j++)
            {
                if (fishes[j] > 0)
                {
                    fishes[j]--;
                    continue;
                }

                if (fishes[j] == 0)
                {
                    fishes[j] = 6;
                    newFishes++;
                }
            }

            for (var k = 0; k < newFishes; k++)
            {
                fishes.Add(8);
            }
        }

        return fishes.Count;
    }

 
    
}