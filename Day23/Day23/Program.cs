const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var computersNames = PrepareComputersNames(dataString);
var computers = PrepareComputers(computersNames);
ConnectComputers(dataString, computers);

var connections = new HashSet<string>();

foreach (var computer in computers)
{
    foreach (var connectedComputer in computer.ConnectedComputers)
    {
        foreach (var lastComputer in connectedComputer.ConnectedComputers)
        {
            if (lastComputer.ConnectedComputers.FirstOrDefault(c => c.Name == computer.Name) != null)
            {
                connections.Add($"{computer.Name},{connectedComputer.Name},{lastComputer.Name}");
            }
        }    
    }
    
}

var result = 0;

foreach (var connection in connections)
{
    Console.WriteLine(connection);
}

Console.WriteLine(result / 12);

HashSet<string> PrepareComputersNames(string inputData)
{

    var output = new HashSet<string>();

    var dataSplit = inputData.Split("\r\n");

    foreach (var dataRow in dataSplit)
    {
        var computersRow = dataRow.Split("-");

        output.Add(computersRow[0]);
        output.Add(computersRow[1]);
    }


    return output;
}

List<Computer> PrepareComputers(HashSet<string> names)
{
    return names.Select(name => new Computer(name)).ToList();
}


void ConnectComputers(string inputData, List<Computer> computers)
{
    var dataSplit = inputData.Split("\r\n");

    foreach (var dataRow in dataSplit)
    {
        var computersRow = dataRow.Split("-");

        var computerOne = computers.FirstOrDefault(c => c.Name == computersRow[0]);
        var computerTwo = computers.FirstOrDefault(c => c.Name == computersRow[1]);

        computerOne.ConnectedComputers.Add(computerTwo);
        computerTwo.ConnectedComputers.Add(computerOne);
    }
}


class Computer
{
    public string Name { get; set; }
    
    public HashSet<Computer> ConnectedComputers { get; set; }

    public Computer(string name)
    {
        Name = name;
        ConnectedComputers = new HashSet<Computer>();
    }
}