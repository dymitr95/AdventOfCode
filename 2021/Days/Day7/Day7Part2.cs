using _2021.Structure;

namespace _2021.Days.Day7;

public class Day7Part2 : Part<int>
{
  public override int Run(string input)
  {
      
      var whalesPositions = new List<int>(input.Split(',').Select(x => Convert.ToInt32(x)));
      var maxWhalePosition = whalesPositions.Max();

      var minFuel = int.MaxValue;
      
      for (var i = 0; i <= maxWhalePosition; i++)
      {
          var fuel = whalesPositions.Select(whale => Math.Abs(whale - i)).Select(steps => steps * (steps + 1) / 2).Sum();
          if (minFuel > fuel)
          {
              minFuel = fuel;
          }
      }
      
      return minFuel;
  }
    
}