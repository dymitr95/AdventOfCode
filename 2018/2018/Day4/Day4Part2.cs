using System.Text.RegularExpressions;

namespace _2018.Day4;

public class Day4Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var entries = ParseInput(rows);
        entries = SortInput(entries);
        rows = JoinEntries(entries);
        
        var guards = ReadInput(rows);

        var mostSleepingMinute = 0;
        var mostSleepingTime = 0;
        var maxSleepingGuardId = 0;
        
        foreach (var guard in guards)
        {
            var guarMostSleepingMinute = guard.MostSleepingMinute();
            if(guarMostSleepingMinute == -1) continue;
            if (guard.MostSleepingTimeOnMinute(guarMostSleepingMinute) <= mostSleepingTime) continue;
            mostSleepingTime = guard.MostSleepingTimeOnMinute(guarMostSleepingMinute);
            mostSleepingMinute = guarMostSleepingMinute;
            maxSleepingGuardId = guard.Id;
        }
        
        var result = mostSleepingMinute * maxSleepingGuardId;
        
        return result;
    }

    private List<Guard> ReadInput(string[] rows)
    {
        var guards = new List<Guard>();
        const string timePattern = @"\b\d{1,2}:(\d{1,2})\b";
        Guard? guard = null;
        
        for (var i = 0; i < rows.Length; i++)
        {
            if (rows[i].Contains("Guard"))
            {
                var guardId = Convert.ToInt32(rows[i].Split("#")[1].Split(" ")[0]);
                var existingGuard = guards.FirstOrDefault(g => g.Id == guardId);
                guard = existingGuard ?? new Guard(guardId);
                if (existingGuard == null)
                {
                    guards.Add(guard);
                }
                continue;
            }

            if (rows[i].Contains("falls"))
            {
                var startTime = Convert.ToInt32(Regex.Match(rows[i], timePattern).Groups[1].Value);
                i++;
                var endTime = Convert.ToInt32(Regex.Match(rows[i], timePattern).Groups[1].Value);
                guard?.Sleep(startTime, endTime);
            }
            
        }
        
        return guards;
    }

    private List<Entry> ParseInput(string[] rows)
    {
        var entries = new List<Entry>();

        const string datePattern = @"\b(\d{1,4})-(\d{1,2})\b-(\d{1,2})\b";
        const string timePattern = @"\b(\d{1,2}):(\d{1,2})\b";

        foreach (var row in rows)
        {
            var year = Convert.ToInt32(Regex.Match(row, datePattern).Groups[1].Value);
            var month = Convert.ToInt32(Regex.Match(row, datePattern).Groups[2].Value);
            var day = Convert.ToInt32(Regex.Match(row, datePattern).Groups[3].Value);
            var hour = Convert.ToInt32(Regex.Match(row, timePattern).Groups[1].Value);
            var minute = Convert.ToInt32(Regex.Match(row, timePattern).Groups[2].Value);
            
            entries.Add(new Entry(year, month, day, hour, minute, row));
        }
        
        return entries;
    }

    private List<Entry> SortInput(List<Entry> entries)
    {
        return entries.OrderBy(e => e.Year).ThenBy(e => e.Month).ThenBy(e => e.Day).ThenBy(e => e.Hour)
            .ThenBy(e => e.Minute).ToList();
    }

    private string[] JoinEntries(List<Entry> entries)
    {
        var result = new string[entries.Count];

        for (var i = 0; i < result.Length; i++)
        {
            result[i] = entries[i].FullRowValue;
        }
        
        return result;
    }
}