using Day1;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var partOne = new PartOne();
var firstResult = partOne.GetSum(dataString);

var partTwo = new PartTwo();
var secondResult = partTwo.GetSum(dataString);


Console.WriteLine($"First result: {firstResult}");
Console.WriteLine($"Second result: {secondResult}");