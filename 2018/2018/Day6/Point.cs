namespace _2018.Day6;

public record struct Point(int id, int x, int y)
{
    public int Id { get; set; } = id;
    public int X { get; set; } = x;
    public int Y { get; set; } = y;

}