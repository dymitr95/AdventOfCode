using _2022.Structure;

namespace _2022.Days.Day5;

public class Day5Part2 : Part<string>
{
   public override string Run(string input)
    {
        var rows = input.Split("\r\n");

        var startCrates = new List<string>();
        var rowsCount = 0;

        foreach (var row in rows)
        {
            var data = row.ToCharArray();
            if (data[1] != '1')
            {
                startCrates.Add(new string(data));
            }
            else
            {
                rowsCount = Convert.ToInt32(data[^2].ToString());
                break;
            }
        }

        var startCratesFormatted = new List<string>();
        
        foreach (var startCrate in startCrates)
        {
            var crate = "";
            for (var i = 1; i < startCrate.Length; i += 4)
            {
                if (startCrate[i] != ' ')
                {
                    crate += startCrate[i] + " ";
                }
                else
                {
                    crate += "# "; 
                }
            }
            
            startCratesFormatted.Add(crate);
        }

        var mainRows = new List<Row>();

        for (var i = 1; i <= rowsCount; i++)
        {
            mainRows.Add(new Row()
            {
                Id = i
            });
        }

        for (var i = startCratesFormatted.Count - 1; i >= 0; i--)
        {
            var data = startCratesFormatted[i].Split(' ');
            var cratesRow = -1;

            foreach (var value in data)
            {
                cratesRow++;
                if (value is "#" or "")
                {
                    continue;
                }

                mainRows[cratesRow].Crates.Push(value);
            }
        }

        MoveCrates(mainRows, rows);

        return mainRows.Aggregate("", (current, row) => current + row.Crates.Pop());
    }


    private static void MoveCrates(List<Row> cratesRows, string[] moves)
    {
        foreach (var move in moves)
        {
            var data = move.Split(" ");
            if (data[0] != "move")
            {
                continue;
            }

            var cratesCount = Convert.ToInt32(data[1]);
            var from = Convert.ToInt32(data[3]);
            var to = Convert.ToInt32(data[5]);

            var cratesToMove = new List<string>();
            
            for (var i = 0; i < cratesCount; i++)
            {
                var crate = cratesRows.First(r => r.Id == from).Crates.Pop();
                cratesToMove.Add(crate);
            }

            for (var i = cratesToMove.Count - 1; i >= 0; i--)
            {
                cratesRows.First(r => r.Id == to).Crates.Push(cratesToMove[i]);
            }
        }
    }
}