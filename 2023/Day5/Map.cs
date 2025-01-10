namespace Day5;

public class Map
{
    public long Source { get; set; }
    public long Destination { get; set; }
    public long Length { get; set; }


    public Map(long source, long destination, long length)
    {
        Source = source;
        Destination = destination;
        Length = length;
    }
}