namespace Day6;

public class Race
{
    public ulong Time { get; set; }
    public ulong Distance { get; set; }



    public Race(ulong time, ulong distance)
    {
        Time = time;
        Distance = distance;
    }
}