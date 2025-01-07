const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var result = 0;

var dataString = reader.ReadToEnd();
reader.Close();

var data = PrepareDataArray(dataString);

#region Part One

// for (var i = 0; i < data.Length; i++)
// {
//     for (var j = 0; j < data[i].Length; j++)
//     {
//         if (data[i][j].Equals("X"))
//         {
//             Process(i, j);
//         }
//         
//     }
// }


void Process(int startRow, int startColumn)
{

    //Left to right
    if (data[startRow].Length > startColumn + 3)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow][startColumn + 1] + data[startRow][startColumn + 2] + data[startRow][startColumn + 3]);
    }
    
    //Top to bottom
    if (data.Length > startRow + 3)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow + 1][startColumn] + data[startRow + 2][startColumn] + data[startRow + 3][startColumn]);
    }
    
    //Right to left
    if (startColumn - 3 >= 0)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow][startColumn - 1] + data[startRow][startColumn - 2] + data[startRow][startColumn - 3]);
    }
    
    //Bottom to top
    if (startRow -3 >= 0)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow - 1][startColumn] + data[startRow - 2][startColumn] + data[startRow - 3][startColumn]);
    }
    
    
    
    //Left top to right bottom
    if (startColumn + 3 < data[startRow].Length && startRow + 3 < data.Length)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow + 1][startColumn + 1] + data[startRow + 2][startColumn + 2] + data[startRow + 3][startColumn + 3]);
    }
    
    //Right top to left bottom
    if (startColumn - 3 >= 0 && startRow + 3 < data.Length)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow + 1][startColumn - 1] + data[startRow + 2][startColumn - 2] + data[startRow + 3][startColumn - 3]);
    }
    
    //Right bottom to left top
    if (startColumn - 3 >= 0 && startRow - 3 >= 0)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow - 1][startColumn - 1] + data[startRow - 2][startColumn - 2] + data[startRow - 3][startColumn - 3]);
    }
    
    //Left bottom to right top
    if (startColumn + 3 < data[startRow].Length && startRow - 3 >= 0)
    {
        CheckForXmas(data[startRow][startColumn] + data[startRow - 1][startColumn + 1] + data[startRow - 2][startColumn + 2] + data[startRow - 3][startColumn + 3]);
    }
    
}

void CheckForXmas(string word, bool reverse = false)
{
    if (word.Equals("XMAS") || reverse && word.Equals("SAMX"))
    {
        result++;
    }
}

#endregion

#region Part Two

for (var i = 0; i < data.Length - 2; i++)
{
    for (var j = 0; j < data[i].Length - 2; j++)
    {
        var square = GetSquare(i, j, data);
        ProcessSquare(square);
    }
}

string[][] GetSquare(int startRow, int startColumn, string[][] localData)
{
    var output = new string[3][];

    for (var i = 0; i < 3; i++)
    {
        output[i] = new string[3];
        
        for (var j = 0; j < 3; j++)
        {
            output[i][j] = localData[startRow + i][startColumn + j];
        }
    }

    return output;
}

void ProcessSquare(string[][] square)
{
    if (CheckForMas(square[0][0] + square[1][1] + square[2][2], true) &&
        CheckForMas(square[0][2] + square[1][1] + square[2][0], true))
    {
        result++;
    }
}

bool CheckForMas(string word, bool reverse = false)
{
    return word.Equals("MAS") || reverse && word.Equals("SAM");
}

#endregion


string[][] PrepareDataArray(string localData)
{
    var dataSplit = localData.Split("\r\n");

    var dataArray = new string[dataSplit.Length][];

    for (var i = 0; i < dataArray.Length; i++)
    {
        dataArray[i] = new string[dataSplit[i].Length];

        var letters = dataSplit[i].ToCharArray();

        for (var j = 0; j < letters.Length; j++)
        {
            dataArray[i][j] = letters[j].ToString();
        }
    }

    return dataArray;
}
Console.WriteLine(result);