const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var dataString = reader.ReadToEnd();
reader.Close();


var gatesValues = PrepareGatesValues(dataString);
var equations = PrepareEquations(dataString);

var result = "";

for (var i = 2; i < 45; i++)
{
    var gateNumber = i.ToString();
    if (gateNumber.Length == 1)
    {
        gateNumber = "0" + gateNumber;
    }
    
    var equation = equations["z" + gateNumber];
    
    if (equation.Operation != "XOR")
    {
        result += $"z{gateNumber}\r\n";
        continue;
    }

    var equationOne = equations[equation.GateOne];
    var equationTwo = equations[equation.GateTwo];


    var notOpenGateName =
        GetNameIfNotOpenGates(equation.GateOne, equation.GateTwo, equationOne, equationTwo, gateNumber);

    if (notOpenGateName != "")
    {
        result += $"{notOpenGateName}\r\n";
        continue;
    }

    var nextEquation = equationOne.Operation == "OR" ? equationOne : equationTwo;

    var nextEquationOne = equations[nextEquation.GateOne];
    var nextEquationTwo = equations[nextEquation.GateTwo];

    if (nextEquationOne.Operation != "AND")
    {
        result += $"{nextEquation.GateOne}\r\n";
        continue;
    }
    
    if (nextEquationTwo.Operation != "AND")
    {
        result += $"{nextEquation.GateTwo}\r\n";
    }
}

var resArr = result.Split("\r\n");

Array.Sort(resArr);

result = string.Join(",", resArr);

Console.WriteLine(result);

string GetNameIfNotOpenGates(string eqOneName, string eqTwoName, Equation equationOne, Equation equationTwo, string index)
{
    if (equationOne.GateOne == "x" + index && equationOne.GateTwo == "y" + index || 
        equationOne.GateTwo == "x" + index && equationOne.GateOne == "y" + index)
    {
        if (equationOne.Operation != "XOR")
        {
            return eqOneName;
        }
    }else if (equationOne.Operation != "OR")
    {
        return eqOneName;
    }
    
    if (equationTwo.GateOne == "x" + index && equationTwo.GateTwo == "y" + index || 
        equationTwo.GateTwo == "x" + index && equationTwo.GateOne == "y" + index)
    {
        if (equationTwo.Operation != "XOR")
        {
            return eqTwoName;
        }
    }else if (equationTwo.Operation != "OR")
    {
        return eqTwoName;
    }

    return "";
}

// while (true)
// {
//     var dictEquations = new Dictionary<string, Equation>(equations);
//
//     if (dictEquations.Count == 0)
//     {
//         break;
//     }
//     
//     foreach (var equationResult in dictEquations.Keys)
//     {
//         var equation = dictEquations[equationResult];
//         if (!gatesValues.ContainsKey(equation.GateOne) || !gatesValues.ContainsKey(equation.GateTwo))
//         {
//             continue;
//         }
//
//         var res = equation.GetEquationResult(gatesValues[equation.GateOne], gatesValues[equation.GateTwo]);
//         gatesValues.Add(equationResult, res);
//         equations.Remove(equationResult);
//     }
// }
//
// var ZGates = gatesValues.Where(g => g.Key.StartsWith("z")).ToDictionary(g => g.Key, g => g.Value);
//
// var ZGatesAlphabetically = ZGates.Keys.ToList();
// ZGatesAlphabetically.Sort();
//
// var result = "";
//
// foreach (var gate in ZGatesAlphabetically)
// {
//     result += Convert.ToInt32(ZGates[gate]);
// }
//
// Console.WriteLine(GetDecimalValue(result));

ulong GetDecimalValue(string binary)
{
    ulong result = 0;

    var arr = binary.ToCharArray();

    for (var i = 0; i < arr.Length; i++)
    {
        if (arr[i].ToString() == "1")
        {
            result += (ulong)Math.Pow(2, i);   
        }
    }
    
    return result;
}

Dictionary<string, bool> PrepareGatesValues(string inputData)
{
    var gates = inputData.Split("\r\n\r\n")[0];

    var gatesValues = gates.Split("\r\n");

    return gatesValues.Select(gateValue => 
        gateValue.Split(": ")).ToDictionary(gateValueSplit => gateValueSplit[0], gateValueSplit => Convert.ToBoolean(Convert.ToInt32(gateValueSplit[1])));
}



Dictionary<string, Equation> PrepareEquations(string inputData)
{
    var output = new Dictionary<string, Equation>();
    
    var equations = inputData.Split("\r\n\r\n")[1];
    var equationsValues = equations.Split("\r\n");

    foreach (var equationValue in equationsValues)
    {
        var equationResult = equationValue.Split(" -> ")[1];

        var equationStr = equationValue.Split(" -> ")[0];
        var equationOperators = equationStr.Split(" ");

        var equation = new Equation(equationOperators[0], equationOperators[2], equationOperators[1]);
        output.Add(equationResult, equation);
    }
    
    return output;
}


class Equation
{
    public string GateOne { get; set; }
    public string GateTwo { get; set; }
    public string Operation { get; set; }

    public Equation(string gateOne, string gateTwo, string operation)
    {
        GateOne = gateOne;
        GateTwo = gateTwo;
        Operation = operation;
    }


    public bool GetEquationResult(bool gateOne, bool gateTwo)
    {
        return Operation switch
        {
            "AND" => gateOne && gateTwo,
            "OR" => gateOne || gateTwo,
            "XOR" => gateOne ^ gateTwo,
            _ => false
        };
    }
}

