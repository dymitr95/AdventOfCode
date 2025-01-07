using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using Day13;

const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var machines = PrepareData(dataString);
long result = 0;

foreach (var machine in machines)
{
    var localResult = Calculate(machine);

    if (localResult == -1)
    {
        continue;
    }

    result += localResult;

}

Console.WriteLine(result);

long Calculate(ClawMachine clawMachine)
{
    var determinant = clawMachine.ButtonA.X * clawMachine.ButtonB.Y - clawMachine.ButtonA.Y * clawMachine.ButtonB.X;
    if (determinant is 0) return -1;
    var acNumerator = clawMachine.Prize.X * clawMachine.ButtonB.Y - clawMachine.Prize.Y * clawMachine.ButtonB.X;
    var bcNumerator = clawMachine.Prize.Y * clawMachine.ButtonA.X - clawMachine.Prize.X * clawMachine.ButtonA.Y;
    if (acNumerator % determinant is not 0 || bcNumerator % determinant is not 0) return -1;
    var ac = acNumerator / determinant;
    var bc = bcNumerator / determinant;
    if (ac < 0 || bc < 0)
    {
        return -1;
    }
    return ac * 3 + bc;
}


List<ClawMachine> PrepareData(string inputString)
{
    var dataSplit = inputString.Split("\r\n");
    var clawMachines = new List<ClawMachine>();

    for (var i = 0; i < dataSplit.Length; i += 4)
    {
        var clawMachine = new ClawMachine();

        for (var j = 0; j < 3; j++)
        {
            var row = dataSplit[i + j];
            var rowSplit = row.Split(' ');

            switch (j)
            {
                case 0:
                    clawMachine.ButtonA = GetButtonCoordinates(rowSplit);
                    continue;
                case 1:
                    clawMachine.ButtonB = GetButtonCoordinates(rowSplit);
                    continue;
                case 2:
                    clawMachine.Prize = GetPrizeCoordinates(rowSplit);
                    continue;
            }
        }

        clawMachines.Add(clawMachine);
    }

    return clawMachines;
}

Coordinates GetButtonCoordinates(string[] rowSplit)
{
    var xString = rowSplit[2].Split('+');
    var xValue = Convert.ToInt64(xString[1][..^1]);
    var yString = rowSplit[3].Split('+');
    var yValue = Convert.ToInt64(yString[1]);

    return new Coordinates
    {
        X = xValue,
        Y = yValue
    };
}

Coordinates GetPrizeCoordinates(string[] rowSplit)
{
    var xString = rowSplit[1].Split('=');
    var xValue = Convert.ToInt64(xString[1][..^1]) + 10000000000000;
    var yString = rowSplit[2].Split('=');
    var yValue = Convert.ToInt64(yString[1]) + 10000000000000;

    return new Coordinates
    {
        X = xValue,
        Y = yValue
    };
}

class ClawMachine
{
    public Coordinates ButtonA { get; set; }
    public Coordinates ButtonB { get; set; }
    public Coordinates Prize { get; set; }
}

class Coordinates
{
    public long X { get; set; }
    public long Y { get; set; }
}