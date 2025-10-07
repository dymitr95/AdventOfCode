namespace _2018.Day4;

public class Guard(int id)
{
    public int Id { get; set; } = id;
    private Dictionary<int, int> SleepingMinutes { get; set; } = new();

    public void Sleep(int start, int end)
    {
        for (var i = start; i < end; i++)
        {
            if (!SleepingMinutes.TryAdd(i, 1))
            {
                SleepingMinutes[i] += 1;
            }
        }
    }

    public int SleepingTime()
    {
        return SleepingMinutes.Values.Sum();
    }

    public int MostSleepingMinute()
    {
        var maxResult = -1;
        var lastMinute = -1;
        foreach (var minute in SleepingMinutes.Keys.Where(minute => SleepingMinutes[minute] > maxResult))
        {
            lastMinute = minute;
            maxResult = SleepingMinutes[minute];
        }

        return lastMinute;
    }

    public int MostSleepingTimeOnMinute(int minute)
    {
        return SleepingMinutes[minute];
    }
}