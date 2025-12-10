using System.Text.RegularExpressions;
using _2025.Structure;

namespace _2025.Days.Day10;

public class Day10Part1 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var result = 0;
        
        var buttons = GetButtonsFromInput(rows);
        var machines = GetLightsFromInput(rows);
        
        for (var i = 0; i < machines.Count; i++)
        {
            var machineButtons = buttons[i];
            var machine = machines[i];
        
            var combinations = GetCombinations(machineButtons);
            
            foreach (var combination in combinations)
            {
                foreach (var button in combination)
                {
                    machine.SwitchLights(button);
                }

                if (machine.InCorrectState())
                {
                    result += combination.Count;
                    break;
                }

                machine.ResetActualState();
            }
            
        }
        
        return result;
    }

    private List<List<Button>> GetCombinations(List<Button> buttons)
    {
        var combinations = new List<List<Button>>();
        var length = buttons.Count;
        
        for (var mask = 1; mask < (1 << length); mask++)
        {
            var buttonsCombination = new List<Button>();
            for (var i = 0; i < length; i++)
            {
                if ((mask & (1 << i)) != 0)
                {
                    buttonsCombination.Add(buttons[i]);
                }
            }
            combinations.Add(buttonsCombination);
        }

        return combinations.OrderBy(c => c.Count).ToList();
    }
    
    private static List<List<Button>> GetButtonsFromInput(string[] rows)
    {
        var buttons = new List<List<Button>>();
        foreach (var row in rows)
        {
            var matches = Regex.Matches(row, @"\(([^)]*)\)");
            var machineButtons = new List<Button>();
            foreach (Match match in matches)
            {
                var lights = match.Groups[1].Value.Split(",");
                var button = new Button();
                foreach (var light in lights)
                {
                    button.AddLight(int.Parse(light));
                }
                machineButtons.Add(button);
            }
            buttons.Add(machineButtons);
        }

        return buttons;
    }

    private static List<MachineLights> GetLightsFromInput(string[] rows)
    {
        return rows.Select(row => Regex.Matches(row, @"\[([^\]]*)\]")).Select(matches => new MachineLights(matches[0].Groups[1].Value)).ToList();
    }
    
}

public readonly record struct Button()
{
    private readonly List<int> _lights = [];

    public void AddLight(int light)
    {
        _lights.Add(light);
    }

    public List<int> GetLights()
    {
        return _lights;
    }
}

public class MachineLights(string targetState)
{
    private string _actualState = new('.', targetState.Length);

    public void SwitchLights(Button button)
    {
        foreach (var light in button.GetLights())
        {
            var arr = _actualState.ToCharArray();
            if (_actualState[light] == '.')
            {
                arr[light] = '#';
            }
            else
            {
                arr[light] = '.';
            }
            _actualState = new string(arr);
        }
    }

    public bool InCorrectState()
    {
        return _actualState == targetState;
    }

    public void ResetActualState()
    {
        _actualState = new string('.', targetState.Length);
    }
}
