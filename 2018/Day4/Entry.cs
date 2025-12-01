namespace _2018.Day4;

public struct Entry(int year, int month, int day, int hour, int minute, string value)
{
    public int Year { get; set; } = year;
    public int Month { get; set; } = month;
    public int Day { get; set; } = day;
    public int Hour { get; set; } = hour;
    public int Minute { get; set; } = minute;
    public string FullRowValue { get; set; } = value;
}