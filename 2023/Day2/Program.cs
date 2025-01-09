using Day2;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();


var partOne = new PartOne();
var partOneResult = partOne.Run(dataString);

var partTwo = new PartTwo();
var partTwoResult = partTwo.Run(dataString);


Console.WriteLine($"Part one result: {partOneResult}");
Console.WriteLine($"Part two result: {partTwoResult}");
