namespace Day2;

public class PartOne
{
    public int Run(string inputData)
    {
        var result = 0;

        var rows = GetGames(inputData);

        for (var i = 0; i < rows.Length; i++)
        {
            var games = rows[i].Split(": ")[1].Split("; ");

            var pass = true;
            for (var j = 0; j < games.Length; j++)
            {

                if (!pass)
                {
                    break;
                }
                
                var dices = games[j].Split(", ");
                
                foreach (var dice in dices)
                {
                    var diceValues = dice.Split(" ");

                    if (diceValues[1] == "blue" && Convert.ToInt32(diceValues[0]) > 14)
                    {
                        pass = false;
                        break;
                    }
                    if (diceValues[1] == "red" && Convert.ToInt32(diceValues[0]) > 12)
                    {
                        pass = false;
                        break;
                    }
                    if (diceValues[1] == "green" && Convert.ToInt32(diceValues[0]) > 13)
                    {
                        pass = false;
                        break;
                    }
                    
                }

            }

            if (pass)
            {
                result += i + 1;
            }
            
        }


        return result;
    }


    private string[] GetGames(string input)
    {
        return input.Split("\r\n");
    }
    
}