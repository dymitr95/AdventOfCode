const string inputFilePath = "./Input/input.txt";

using var reader = new StreamReader(inputFilePath);

var result = 0;

var dataString = reader.ReadToEnd();
reader.Close();

var dataArr = dataString.Split("\r\n\r\n");

var rulesArr = dataArr[0];
var rulesArrSplit = rulesArr.Split("\r\n");

var pagesArr = dataArr[1];
var pagesArrSplit = pagesArr.Split("\r\n");


var rules = new Dictionary<int, List<int>>();
var swap = false;

FillRulesDictionary();

foreach (var pages in pagesArrSplit)
{
    var pagesSplit = pages.Split(',');
    var pagesInt = new int[pagesSplit.Length];
    for (var i = 0; i < pagesSplit.Length; i++)
    {
        pagesInt[i] = Convert.ToInt32(pagesSplit[i]);
    }

    swap = false;
    ProcessPages(pagesInt);
}

void ProcessPages(int[] pages)
{
    for (var i = pages.Length - 1; i >= 0; i--)
    {
        for (var j = i; j >= 0; j--)
        {
            if (!rules.ContainsKey(pages[i])) continue;
            if (rules[pages[i]].Contains(pages[j]))
            {
                swap = true;
                (pages[i], pages[j]) = (pages[j], pages[i]);
                i = pages.Length;
                break;
            }
        }
    }

    if (!swap) return;
    var middleElement = pages[pages.Length / 2];
    result += middleElement;
}


void FillRulesDictionary()
{
    foreach (var ruleArr in rulesArrSplit)
    {
        var ruleArrSplit = ruleArr.Split('|');
        var pageOne = Convert.ToInt32(ruleArrSplit[0]);
        var pageTwo = Convert.ToInt32(ruleArrSplit[1]);

        if (rules.TryGetValue(pageOne, out var value))
        {
            value.Add(pageTwo);
        }
        else
        {
            rules.Add(pageOne, new List<int> { pageTwo });
        }
    }
}

Console.WriteLine(result);