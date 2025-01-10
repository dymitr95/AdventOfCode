using System.Text.RegularExpressions;

namespace Day6;

public class PartOne
{
    public int Run(string input)
    {
        var races = GetRaces(input);

        return races.Aggregate(1, (current, race) => current * GetWaysToWin(race));
    }


    private int GetWaysToWin(Race race)
    {
        var output = 0;

        for (var i = 0; i < race.Time; i++)
        {
            var remainingTime = race.Time - i;
            var speed = i;

            var traveledDistance = remainingTime * speed;
            if (traveledDistance < race.Distance && output == 0 || traveledDistance == race.Distance)
            {
                continue;
            }
            
            if (traveledDistance < race.Distance)
            {
                return output;
            }

            output++;

        }

        return output;
    }


    private List<Race> GetRaces(string input)
    {
        var output = new List<Race>();
        input = Regex.Replace(input, @"\s+", " ");
        input = input.Replace("Time: ", "");
        input = input.Replace(" Distance: ", "/");

        var dataRows = input.Split("/");

        var times = dataRows[0].Split(" ");
        var distances = dataRows[1].Split(" ");

        for (var i = 0; i < times.Length; i++)
        {
            var time = Convert.ToInt32(times[i]);
            var distance = Convert.ToInt32(distances[i]);

            output.Add(new Race(time, distance));
        }


        return output;
    }
}