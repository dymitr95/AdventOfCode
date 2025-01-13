namespace Day7;

public class CustomComparer : IComparer<string>
{
    private static readonly Dictionary<char, int> CharRank = new()
    {
        { 'A', 1 }, { 'K', 2 }, { 'Q', 3 }, { 'T', 4 },
        { '9', 5 }, { '8', 6 }, { '7', 7 }, { '6', 8 }, { '5', 9 },
        { '4', 10 }, { '3', 11 }, { '2', 12 }, { 'J', 13 }
    };

    public int Compare(string x, string y)
    {
        for (var i = 0; i < Math.Min(x.Length, y.Length); i++)
        {
            var charX = x[i];
            var charY = y[i];

            if (CharRank.TryGetValue(charX, out var rankX) && CharRank.TryGetValue(charY, out var rankY))
            {
                if (rankX != rankY)
                {
                    return rankX.CompareTo(rankY);
                }
            }
            else
            {
                return charX.CompareTo(charY);
            }
        }
        
        return x.Length.CompareTo(y.Length);
    }
}