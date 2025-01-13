namespace Day7;

public class PartTwo
{

  public int Run(string input)
    {
        var result = 0;

        var cardsAndBids = PrepareCardsAndBids(input);
        var cards = cardsAndBids.Keys.ToList();

        var combinations = ProcessCards(cards);

        var rank = cards.Count;
        
        foreach (var combination in combinations)
        {
            combination.Value.Sort(new CustomComparer());
            foreach (var comb in combination.Value)
            {
                result += cardsAndBids[comb] * rank;
                rank--;
            }
        }
        
        return result;
    }


    private Dictionary<string, List<string>> ProcessCards(List<string> cards)
    {
        var combinations = PrepareCombinations();

        foreach (var card in cards)
        {
            var jCount = card.Count(l => l == 'J');
            if (IsFiveOfAKind(card, jCount))
            {
                combinations["FiveOfAKind"].Add(card);
                continue;
            }

            if (IsFourOfAKind(card, jCount))
            {
                combinations["FourOfAKind"].Add(card);
                continue;
            }

            if (IsFullHouse(card, jCount))
            {
                combinations["FullHouse"].Add(card);
                continue;
            }
            
            if (IsThreeOfAKind(card, jCount))
            {
                combinations["ThreeOfAKind"].Add(card);
                continue;
            }
            
            if (IsTwoPair(card, jCount))
            {
                combinations["TwoPair"].Add(card);
                continue;
            }
            
            if (IsOnePair(card, jCount))
            {
                combinations["OnePair"].Add(card);
                continue;
            }
            
            combinations["HighCard"].Add(card);
        }

        return combinations;
    }


    private bool IsFiveOfAKind(string cards, int jCount)
    {
        if (jCount is 5 or 4)
        {
            return true;
        }
        
        var dict = new Dictionary<char, int>();
        foreach (var card in cards)
        {
            if (dict.ContainsKey(card))
            {
                dict[card]++;
            }
            else
            {
                dict.Add(card, 1);
            }
        }

        return dict.Where(count => count.Key != 'J').Any(count => count.Value + jCount == 5);
    }
    
    private bool IsFourOfAKind(string cards, int jCount)
    {
        var dict = new Dictionary<char, int>();
        foreach (var card in cards)
        {
            if (dict.ContainsKey(card))
            {
                dict[card]++;
            }
            else
            {
                dict.Add(card, 1);
            }
        }

        return dict.Where(count => count.Key != 'J').Any(count => count.Value + jCount == 4);
    }

    private bool IsFullHouse(string cards, int jCount)
    {
        var dict = new Dictionary<char, int>();
        foreach (var card in cards)
        {
            if (dict.ContainsKey(card))
            {
                dict[card]++;
            }
            else
            {
                dict.Add(card, 1);
            }
        }

        var hasTwo = false;
        var hasThree = false;
        
        foreach (var key in dict.Keys)
        {
            if (dict[key] == 2)
            {
                hasTwo = true;
            }

            if (dict[key] == 3)
            {
                hasThree = true;
            }
        }

        if (hasThree && jCount == 1)
        {
            return true;
        }

        var twosCount = dict.Count(count => count.Key != 'J' && count.Value == 2);
        if (twosCount == 2 && jCount == 1)
        {
            return true;
        }

        return hasTwo && hasThree;
    }

    private bool IsThreeOfAKind(string cards, int jCount)
    {
        var dict = new Dictionary<char, int>();
        foreach (var card in cards)
        {
            if (dict.ContainsKey(card))
            {
                dict[card]++;
            }
            else
            {
                dict.Add(card, 1);
            }
        }

        return dict.Where(count => count.Key != 'J').Any(count => count.Value + jCount == 3);
    }
    
    private bool IsTwoPair(string cards, int jCount)
    {
        var dict = new Dictionary<char, int>();
        foreach (var card in cards)
        {
            if (dict.ContainsKey(card))
            {
                dict[card]++;
            }
            else
            {
                dict.Add(card, 1);
            }
        }

        var firstCard = ' ';
        var hasTwoFirst = false;
        
        var hasTwoSecond = false;
        
        foreach (var key in dict.Keys)
        {
            if (dict[key] == 2 && !hasTwoFirst)
            {
                hasTwoFirst = true;
                firstCard = key;
                continue;
            }

            if (dict[key] == 2 && !hasTwoSecond && key != firstCard)
            {
                hasTwoSecond = true;
            }
        }

        return hasTwoFirst && hasTwoSecond;
    }
    
    private bool IsOnePair(string cards, int jCount)
    {
        var dict = new Dictionary<char, int>();
        foreach (var card in cards)
        {
            if (dict.ContainsKey(card))
            {
                dict[card]++;
            }
            else
            {
                dict.Add(card, 1);
            }
        }

        return dict.Where(count => count.Key != 'J').Any(count => count.Value + jCount == 2);
    }

    private Dictionary<string, int> PrepareCardsAndBids(string input)
    {
        var output = new Dictionary<string, int>();

        var data = input.Split("\r\n");

        foreach (var row in data)
        {
            var cards = row.Split(" ")[0];
            var bid = Convert.ToInt32(row.Split(" ")[1]);
            output.Add(cards, bid);
        }


        return output;
    }
    private Dictionary<string, List<string>> PrepareCombinations()
    {
        var output = new Dictionary<string, List<string>>
        {
            { "FiveOfAKind", new List<string>() },
            { "FourOfAKind", new List<string>() },
            { "FullHouse", new List<string>() },
            { "ThreeOfAKind", new List<string>() },
            { "TwoPair", new List<string>() },
            { "OnePair", new List<string>() },
            { "HighCard", new List<string>() }
        };

        return output;
    }
    
}