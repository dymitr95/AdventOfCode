using Day3;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();


var partOne = new PartOne();
var resultOne = partOne.Run(dataString);






Console.WriteLine($"Result one: {resultOne}");