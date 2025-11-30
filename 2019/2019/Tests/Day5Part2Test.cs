using _2019.Day5;

namespace _2019.Tests;

public class Day5Part2Test
{
    private Day5Part2 _part;

    [SetUp]
    public void Setup()
    {
        _part = new Day5Part2();
    }

    [Test]
    public void Test1()
    {
        _part.SetComputerInput(8);
        var res = _part.Run("3,9,8,9,10,9,4,9,99,-1,8");
        Assert.That(res, Is.EqualTo(1));
    }
    
    [Test]
    public void Test2()
    {
        _part.SetComputerInput(9);
        var res = _part.Run("3,9,8,9,10,9,4,9,99,-1,8");
        Assert.That(res, Is.EqualTo(0));
    }
    
    [Test]
    public void Test3()
    {
        _part.SetComputerInput(1);
        var res = _part.Run("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,\n1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,\n999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99");
        Assert.That(res, Is.EqualTo(999));
    }
    
    [Test]
    public void Test4()
    {
        _part.SetComputerInput(8);
        var res = _part.Run("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,\n1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,\n999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99");
        Assert.That(res, Is.EqualTo(1000));
    }
    
    [Test]
    public void Test5()
    {
        _part.SetComputerInput(9);
        var res = _part.Run("3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,\n1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,\n999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99");
        Assert.That(res, Is.EqualTo(1001));
    }
}