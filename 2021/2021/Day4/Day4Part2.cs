namespace _2021.Day4;

public class Day4Part2 : Part<int>
{
  public override int Run(string input)
    {
        var result = 0;
        
        var rows = input.Split("\r\n");
        
        var valuesStr = rows[0].Split(',');
        var values = valuesStr.Select(value => Convert.ToInt32(value)).ToList();

        var boards = new List<Board>();
        PrepareBoards(boards, rows);

        var results = new List<int>();

        foreach (var value in values)
        {
            foreach (var board in boards)
            {
                if(board.Won) continue;
                
                var marked = board.MarkNumber(value);
                if(!marked) continue;

                if (!board.IsWon()) continue;
                board.Won = true;
                result = value * board.GetSum();
                results.Add(result);
            }
        }
        
        
        return results[^1];
    }

    private void PrepareBoards(List<Board> boards, string[] boardsValues)
    {
        var board = new Board(5, 5);
        var row = 0;

        for (var i = 2; i < boardsValues.Length; i++)
        {
            var rowStr = boardsValues[i];

            if (string.IsNullOrEmpty(rowStr))
            {
                row = 0;
                boards.Add(board);
                board = new Board(5, 5);
                continue;
            }

            var numbers = rowStr.Split(' ');
            var col = 0;
            foreach (var number in numbers)
            {
                if(number == "") continue;
                board.AddNumber(row, col,Convert.ToInt32(number));
                col++;
            }

            row++;
        }
        boards.Add(board);
    }
}
