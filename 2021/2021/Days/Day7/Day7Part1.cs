using _2021.Structure;

namespace _2021.Days.Day7;

public class Day7Part1 : Part<int>
{
    public override int Run(string input)
    {
        var whalesPositions = new List<int>(input.Split(',').Select(x => Convert.ToInt32(x)));

        var checkedPositions = new Dictionary<int, int>();

        foreach (var position in whalesPositions)
        {
            if(checkedPositions.ContainsKey(position)) continue;
            
            var fuel = whalesPositions.Sum(whale => Math.Abs(whale - position));
            checkedPositions.Add(position, fuel);
        }
        
        return checkedPositions.Values.Min();
    }

 
    
}