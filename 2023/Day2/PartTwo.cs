namespace Day2;

public class PartTwo
{
    public int Run(string inputData)
    {
        var result = 0;

        var rows = GetGames(inputData);

        for (var i = 0; i < rows.Length; i++)
        {
            var games = rows[i].Split(": ")[1].Split("; ");

            var minBlue = 0;
            var minGreen = 0;
            var minRed = 0;
            
            for (var j = 0; j < games.Length; j++)
            {
                
                var dices = games[j].Split(", ");
                
                foreach (var dice in dices)
                {
                    var diceValues = dice.Split(" ");

                    if (diceValues[1] == "blue")
                    {
                        minBlue = minBlue > Convert.ToInt32(diceValues[0]) ? minBlue : Convert.ToInt32(diceValues[0]);
                    }
                    if (diceValues[1] == "red")
                    {
                        minRed = minRed > Convert.ToInt32(diceValues[0]) ? minRed : Convert.ToInt32(diceValues[0]);
                    }
                    if (diceValues[1] == "green")
                    {
                        minGreen = minGreen > Convert.ToInt32(diceValues[0]) ? minGreen : Convert.ToInt32(diceValues[0]);
                    }
                    
                }

            }

            result += minBlue * minGreen * minRed;

        }


        return result;
    }


    private string[] GetGames(string input)
    {
        return input.Split("\r\n");
    }
}