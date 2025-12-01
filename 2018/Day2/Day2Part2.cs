namespace _2018.Day2;

public class Day2Part2 : Part<string>
{
    public override string Run(string input)
    {
        var rows = input.Split("\r\n");

        var bestWord = "";
        var bestCount = 0;
        
        for(var i = 0; i < rows.Length - 1; i++)
        {
            for (var j = i + 1; j < rows.Length; j++)
            {
                var count = 0;
                var word = "";
                for (var k = 0; k < rows[i].Length; k++)
                {
                    if (rows[i][k] == rows[j][k])
                    {
                        count++;
                        word += rows[i][k];
                    }
                }

                if (count > bestCount)
                {
                    bestCount = count;
                    bestWord = word;

                }
            }
        }


        return bestWord;
    }
}