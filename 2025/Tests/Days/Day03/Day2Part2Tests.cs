using _2025.Days.Day02;
using _2025.Days.Day03;

namespace Tests;

[TestFixture]
public class Day3Part2Tests
{

    [Test]
    public void Test01()
    {
        var part = new Day3Part2();
        var result = part.Run("987654321111111");
        Assert.That(result, Is.EqualTo(987654321111));
    }
    
    [Test]
    public void Test02()
    {
        var part = new Day3Part2();
        var result = part.Run("811111111111119");
        Assert.That(result, Is.EqualTo(811111111119));
    }
    
    [Test]
    public void Test03()
    {
        var part = new Day3Part2();
        var result = part.Run("234234234234278");
        Assert.That(result, Is.EqualTo(434234234278));
    }
    
    [Test]
    public void Test04()
    {
        var part = new Day3Part2();
        var result = part.Run("818181911112111");
        Assert.That(result, Is.EqualTo(888911112111));
    }
}