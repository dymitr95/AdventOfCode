const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var computersNames = PrepareComputersNames(dataString);
var computers = PrepareComputers(computersNames);
ConnectComputers(dataString, computers);

var computersWithConnections = new Dictionary<string, Dictionary<string, int>>();

foreach (var computer in computers)
{
    var computerConnections = new Dictionary<string, int>();
    foreach (var connectedComputer in computer.ConnectedComputers)
    {
        computerConnections.Add(connectedComputer.Name, 1);
    }
    
    computersWithConnections.Add(computer.Name, computerConnections);
}

foreach (var computerName in computersWithConnections.Keys)
{
    var computerConnectionsDict = computersWithConnections[computerName];

    foreach (var connectedComputerName in computerConnectionsDict.Keys)
    {
        foreach (var connectedComputer in computersWithConnections[connectedComputerName].Keys)
        {
            if (computersWithConnections[computerName].ContainsKey(connectedComputer))
            {
                computersWithConnections[computerName][connectedComputer] += 1;
            }
        }
    }

}

var largestConnection = 0;
var largestComputerCount = 0;
var largestConnectionComputer = "";

foreach (var computer in computersWithConnections.Keys)
{
    var computerWeb = new Dictionary<int, int>();
    foreach (var connectedComputer in computersWithConnections[computer])
    {
        if (computerWeb.ContainsKey(connectedComputer.Value))
        {
            computerWeb[connectedComputer.Value] += 1;
        }
        else
        {
            computerWeb.Add(connectedComputer.Value, 1);
        }
    }

    foreach (var conn in computerWeb)
    {
        if (conn.Key != conn.Value)
        {
            continue;
        }
        if (largestConnection < conn.Key && largestComputerCount < conn.Value)
        {
            largestConnection = conn.Key;
            largestComputerCount = conn.Value;
            largestConnectionComputer = computer;
        }
    }
}


var result = largestConnectionComputer;
foreach (var connectedComputers in computersWithConnections[largestConnectionComputer])
{
    if (connectedComputers.Value == largestConnection)
    {
        result = result + "," + connectedComputers.Key;
    }
}

var answer = result.Split(",");

Array.Sort(answer);

result = string.Join(",", answer);

Console.WriteLine(result);


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