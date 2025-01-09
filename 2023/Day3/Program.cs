using Day3;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();


var partOne = new PartOne();
partOne.Run(dataString);