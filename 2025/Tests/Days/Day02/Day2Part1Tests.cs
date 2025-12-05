using _2025.Days.Day02;

namespace _2025.Tests.Days.Day02;

[TestFixture]
public class Day2Part1Tests
{

    [Test]
    public void Test1()
    {
        var part = new Day2Part1();
        var result = part.Run("11-22");
        Assert.That(result, Is.EqualTo(33));
    }
    
    [Test]
    public void Test2()
    {
        var part = new Day2Part1();
        var result = part.Run("95-115");
        Assert.That(result, Is.EqualTo(99));
    }
    
    [Test]
    public void Test3()
    {
        var part = new Day2Part1();
        var result = part.Run("222220-222224");
        Assert.That(result, Is.EqualTo(222222));
    }
    
    [Test]
    public void Test4()
    {
        var part = new Day2Part1();
        var result = part.Run("998-1012");
        Assert.That(result, Is.EqualTo(1010));
    }
    
    [Test]
    public void Test5()
    {
        var part = new Day2Part1();
        var result = part.Run("1188511880-1188511890");
        Assert.That(result, Is.EqualTo(1188511885));
    }
    
    [Test]
    public void Test6()
    {
        var part = new Day2Part1();
        var result = part.Run("1698522-1698528");
        Assert.That(result, Is.EqualTo(0));
    }
    
    [Test]
    public void Test7()
    {
        var part = new Day2Part1();
        var result = part.Run("446443-446449");
        Assert.That(result, Is.EqualTo(446446));
    }
    
    [Test]
    public void Test8()
    {
        var part = new Day2Part1();
        var result = part.Run("38593856-38593862");
        Assert.That(result, Is.EqualTo(38593859));
    }
    
    [Test]
    public void Test9()
    {
        var part = new Day2Part1();
        var result = part.Run("565653-565659");
        Assert.That(result, Is.EqualTo(0));
    }
    
    [Test]
    public void Test10()
    {
        var part = new Day2Part1();
        var result = part.Run("824824821-824824827");
        Assert.That(result, Is.EqualTo(0));
    }
    
    [Test]
    public void Test11()
    {
        var part = new Day2Part1();
        var result = part.Run("2121212118-2121212124");
        Assert.That(result, Is.EqualTo(0));
    }
}