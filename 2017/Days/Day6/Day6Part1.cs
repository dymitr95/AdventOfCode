using _2017.Structure;

namespace _2017.Days.Day6;

public class Day6Part1 : Part<int>
{
    
    public override int Run(string input)
    {
        var data = input.Split("\t").Select(s => Convert.ToInt32(s)).ToArray();

        var banks = GetBanks(data);

        var previousStates = new HashSet<string> { GetBanksState(banks) };

        var secondLoop = false;
        
        while (true)
        {
            var bank = GetMemoryBankWithMostBlocks(banks);
            var blocks = bank.Blocks;
            bank.Blocks = 0;
            var currentPosition = bank.Id;

            while (blocks != 0)
            {
                currentPosition += 1;
                currentPosition %= banks.Count;
                banks[currentPosition].Blocks += 1;
                blocks--;
            }
            
            var state = GetBanksState(banks);
            if (!previousStates.Add(state) && !secondLoop)
            {
                break;
            }

            previousStates.Add(state);
        }
        
        return previousStates.Count;
    }

    private static string GetBanksState(List<MemoryBank> banks)
    {
        return string.Join(",", banks.Select(b => b.Blocks.ToString()));
    }

    private static List<MemoryBank> GetBanks(int[] data)
    {
        return data.Select((value, id) => new MemoryBank(id, value)).ToList();
    }

    private static MemoryBank GetMemoryBankWithMostBlocks(List<MemoryBank> banks)
    {
        var orderedBanks = banks.OrderBy(b => b.Blocks).ToList();
        return orderedBanks.First(b => b.Blocks == orderedBanks[^1].Blocks);
    }
    
}

public class MemoryBank(int id, int blocks)
{
    public int Id { get; set; } = id;
    public int Blocks { get; set; } = blocks;
}