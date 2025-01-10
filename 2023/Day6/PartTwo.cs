using System.Text.RegularExpressions;

namespace Day6;

public class PartTwo
{
    public ulong Run(string input)
    {
        var race = GetRace(input);

        var result = GetWaysToWin(race);
        
        return result;
    }


    private ulong GetWaysToWin(Race race)
    {
        ulong output = 0;

        for (ulong i = 0; i < race.Time; i++)
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


    private Race GetRace(string input)
    {
        input = Regex.Replace(input, @"\s+", " ");
        input = input.Replace("Time: ", "");
        input = input.Replace(" Distance: ", "/");

        var dataRows = input.Split("/");

        var time = Convert.ToUInt64(dataRows[0].Replace(" ", ""));
        var distance = Convert.ToUInt64(dataRows[1].Replace(" ", ""));

        return new Race(time, distance);
    }
}