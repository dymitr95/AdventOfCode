using Day5;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();



var partOne = new PartOne();
var firstResult = partOne.Run(dataString);



Console.WriteLine($"First result: {firstResult}");