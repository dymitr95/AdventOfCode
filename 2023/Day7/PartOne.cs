namespace Day7;

public class PartOne
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
            if (IsFiveOfAKind(card))
            {
                combinations["FiveOfAKind"].Add(card);
                continue;
            }

            if (IsFourOfAKind(card))
            {
                combinations["FourOfAKind"].Add(card);
                continue;
            }
            
            if (IsFullHouse(card))
            {
                combinations["FullHouse"].Add(card);
                continue;
            }
            
            if (IsThreeOfAKind(card))
            {
                combinations["ThreeOfAKind"].Add(card);
                continue;
            }
            
            if (IsTwoPair(card))
            {
                combinations["TwoPair"].Add(card);
                continue;
            }
            
            if (IsOnePair(card))
            {
                combinations["OnePair"].Add(card);
                continue;
            }
            
            combinations["HighCard"].Add(card);
        }

        return combinations;
    }


    private bool IsFiveOfAKind(string cards)
    {
        return cards.All(c => c == cards[0]);
    }
    
    private bool IsFourOfAKind(string cards)
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

            if (dict[card] == 4)
            {
                return true;
            }
        }

        return false;
    }

    private bool IsFullHouse(string cards)
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

        return hasTwo && hasThree;
    }

    private bool IsThreeOfAKind(string cards)
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

            if (dict[card] == 3)
            {
                return true;
            }
        }

        return false;
    }
    
    private bool IsTwoPair(string cards)
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
    
    private bool IsOnePair(string cards)
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

            if (dict[card] == 2)
            {
                return true;
            }
        }

        return false;
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
        var output = new Dictionary<string, List<string>>();
        
        output.Add("FiveOfAKind", new List<string>());
        output.Add("FourOfAKind", new List<string>());
        output.Add("FullHouse", new List<string>());
        output.Add("ThreeOfAKind", new List<string>());
        output.Add("TwoPair", new List<string>());
        output.Add("OnePair", new List<string>());
        output.Add("HighCard", new List<string>());
        
        return output;
    }

}