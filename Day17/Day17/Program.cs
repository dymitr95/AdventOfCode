const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();

var program = PrepareData(dataString);

DateTime startTime = DateTime.Now;

ulong A = 0;
var position = 0;
//var values = "035430";
var values = "2413754703155530";
values.Reverse();

for (var i = 15; i >= 0; i--)
{
    A <<= 3;

    while (RunProgram(A) != values.Substring(i, values.Length - i))
    {
        A++;
    }
    
    Console.WriteLine(A);
    
}


Console.WriteLine(A);


string RunProgram(ulong aValue)
{
    program.Pointer = 0;
    program.RegisterA.Value = aValue;
    program.RegisterB.Value = 0;
    program.RegisterC.Value = 0;
    program.Result = new List<ulong>();
    program.Output = "";

    while ((int)program.Pointer < program.ProgramValues.Count - 1)
    {
        var instruction = program.ProgramValues[(int)program.Pointer];
        var operand = program.ProgramValues[(int)program.Pointer + 1];

        switch (instruction)
        {
            case 0:
                program.ADV(operand);
                break;
            case 1:
                program.BXL(operand);
                break;
            case 2:
                program.BST(operand);
                break;
            case 3:
                program.JNZ(operand);
                break;
            case 4:
                program.BXC(operand);
                break;
            case 5:
                program.OUT(operand);
                break;
            case 6:
                program.BDV(operand);
                break;
            case 7:
                program.CDV(operand);
                break;
        }
    }

    return program.Output;
}

DateTime endTime = DateTime.Now;
TimeSpan duration = endTime - startTime;
double milliseconds = duration.TotalMilliseconds;
Console.WriteLine(program.Output);
Console.WriteLine($"Runtime: {milliseconds} ms");

MainProgram PrepareData(string inputData)
{
    var program = new MainProgram();

    var dataSplit = inputData.Split("\r\n");

    var registerAData = dataSplit[0].Split(" ");
    program.RegisterA = new Register(Convert.ToUInt64(registerAData[2]));

    var registerBData = dataSplit[1].Split(" ");
    program.RegisterB = new Register(Convert.ToUInt64(registerBData[2]));

    var registerCData = dataSplit[2].Split(" ");
    program.RegisterC = new Register(Convert.ToUInt64(registerCData[2]));

    var programData = dataSplit[4].Split(" ");
    var programValues = programData[1].Split(",");

    program.ProgramValues = new List<ulong>();

    foreach (var programValue in programValues)
    {
        program.ProgramValues.Add(Convert.ToUInt64(programValue));
    }

    return program;
}

class MainProgram
{
    public Register RegisterA { get; set; }
    public Register RegisterB { get; set; }
    public Register RegisterC { get; set; }

    public List<ulong> ProgramValues { get; set; }

    public string Output { get; set; }

    public ulong Pointer { get; set; } = 0;

    public List<ulong> Result = new List<ulong>();

    //Opcode 0
    public void ADV(ulong operand)
    {
        var numerator = RegisterA.Value;
        var denominator = Math.Pow(2, GetComboValue(operand));

        var result = (ulong)Math.Truncate(numerator / denominator);
        RegisterA.Value = result;
        Pointer += 2;
    }

    //Opcode 1
    public void BXL(ulong operand)
    {
        var value = RegisterB.Value;
        var result = value ^ operand;
        RegisterB.Value = result;
        Pointer += 2;
    }

    //Opcode 2
    public void BST(ulong operand)
    {
        RegisterB.Value = GetComboValue(operand) % 8;
        Pointer += 2;
    }

    //Opcode 3
    public void JNZ(ulong operand)
    {
        if (RegisterA.Value == 0)
        {
            Pointer += 2;
            return;
        }

        JumpToNewPointer(operand);
    }

    //Opcode 4
    public void BXC(ulong operand)
    {
        var value1 = RegisterB.Value;
        var value2 = RegisterC.Value;
        RegisterB.Value = value1 ^ value2;
        Pointer += 2;
    }

    //Opcode 5
    public void OUT(ulong operand)
    {
        var result = GetComboValue(operand) % 8;
        Output += result;
        Pointer += 2;
        Result.Add(result);
    }

    //Opcode 6
    public void BDV(ulong operand)
    {
        var numerator = RegisterA.Value;
        var denominator = Math.Pow(2, GetComboValue(operand));

        var result = (ulong)Math.Truncate(numerator / denominator);
        RegisterB.Value = result;
        Pointer += 2;
    }

    //Opcode 7
    public void CDV(ulong operand)
    {
        var numerator = RegisterA.Value;
        var denominator = Math.Pow(2, GetComboValue(operand));

        var result = (ulong)Math.Truncate(numerator / denominator);
        RegisterC.Value = result;
        Pointer += 2;
    }

    private void JumpToNewPointer(ulong operand)
    {
        Pointer = operand;
    }

    public ulong GetComboValue(ulong operand)
    {
        return operand switch
        {
            4 => RegisterA.Value,
            5 => RegisterB.Value,
            6 => RegisterC.Value,
            _ => operand
        };
    }
}

class Register
{
    public ulong Value { get; set; }

    public Register(ulong value)
    {
        Value = value;
    }
}