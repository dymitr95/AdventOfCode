namespace _2021.Day4;

public class Day4Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;
        
        var rows = input.Split("\r\n");
        
        var valuesStr = rows[0].Split(',');
        var values = valuesStr.Select(value => Convert.ToInt32(value)).ToList();

        var boards = new List<Board>();
        PrepareBoards(boards, rows);

        foreach (var value in values)
        {
            foreach (var board in boards)
            {
                var marked = board.MarkNumber(value);
                if(!marked) continue;

                if (!board.IsWon()) continue;
                result = value * board.GetSum();
                return result;
            }
        }
        
        
        return result;
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

public class Board
{
    private int[][] Numbers { get; set; }

    public bool Won { get; set; }
    
    public Board(int rows, int cols)
    {
        Numbers = new int[rows][];
        for (var i = 0; i < rows; i++)
        {
            Numbers[i] = new int[cols];
        }

        Won = false;
    }

    public void AddNumber(int i, int j, int number)
    {
        Numbers[i][j] = number;
    }

    public bool MarkNumber(int number)
    {
        for (var i = 0; i < Numbers.Length; i++)
        {
            for (var j = 0; j < Numbers[i].Length; j++)
            {
                if (Numbers[i][j] != number) continue;
                Numbers[i][j] = -1;
                return true;
            }
        }

        return false;
    }

    public bool IsWon()
    {
        var won = false;
        
        for (var i = 0; i < Numbers.Length; i++)
        {
            for (var j = 0; j < Numbers[i].Length; j++)
            {
                if (Numbers[i][j] != -1)
                {
                    break;
                }

                if (j == Numbers[i].Length - 1)
                {
                    won = true;
                }
            }

            if (won)
            {
                return true;
            }
        }
        
        for (var i = 0; i < Numbers.Length; i++)
        {
            for (var j = 0; j < Numbers[i].Length; j++)
            {
                if (Numbers[j][i] != -1)
                {
                    break;
                }

                if (j == Numbers[i].Length - 1)
                {
                    won = true;
                }
            }

            if (won)
            {
                return true;
            }
        }

        return false;
    }

    public int GetSum()
    {
        var sum = 0;

        for (var i = 0; i < Numbers.Length; i++)
        {
            for (var j = 0; j < Numbers[i].Length; j++)
            {
                if (Numbers[i][j] != -1)
                {
                    sum += Numbers[i][j];
                }
            }
        }

        return sum;
    }
}