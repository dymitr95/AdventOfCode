using System.Text.RegularExpressions;
using _2025.Structure;
using Google.OrTools.LinearSolver;

namespace _2025.Days.Day10;

public class Day10Part2 : Part<int>
{
    public override int Run(string input)
    {
        var rows = input.Split("\r\n");

        var result = 0;

        var buttons = GetButtonsFromInput(rows);
        var machines = GetJoltageFromInput(rows);

        for (var i = 0; i < machines.Count; i++)
        {
            var machineButtons = buttons[i];
            var machine = machines[i];
            var vectorR = machine.GetTargetState();

            var matrixA = new double[vectorR.Length, machineButtons.Count];
            for (var j = 0; j < vectorR.Length; j++)
            {
                for (var k = 0; k < machineButtons.Count; k++)
                {
                    if (machineButtons[k].GetLights().Contains(j))
                    {
                        matrixA[j, k] = 1;
                    }
                }
            }

            var numInputs = machineButtons.Count;
            var numOutputs = vectorR.Length;

            var solver = Solver.CreateSolver("SCIP");

            var x = new Variable[numInputs];
            for (var k = 0; k < numInputs; k++)
                x[k] = solver.MakeIntVar(0, double.PositiveInfinity, $"x{k}");
            
            for (var row = 0; row < numOutputs; row++)
            {
                var expr = new LinearExpr();
                for (var col = 0; col < numInputs; col++)
                    expr += matrixA[row, col] * x[col];
                solver.Add(expr == vectorR[row]);
            }
            
            var total = new LinearExpr();
            for (var k = 0; k < numInputs; k++)
                total += x[k];
            solver.Minimize(total);
            
            var status = solver.Solve();

            if (status == Solver.ResultStatus.OPTIMAL)
            {
                result += (int)solver.Objective().Value();
            }
        }

        return result;
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

    private static List<MachineJoltage> GetJoltageFromInput(string[] rows)
    {
        var joltages = new List<MachineJoltage>();
        foreach (var row in rows)
        {
            var match = Regex.Match(row, @"\{([^\]]*)\}");
            var values = match.Groups[1].Value.Split(",").Select(int.Parse).ToArray();
            joltages.Add(new MachineJoltage(values));
        }

        return joltages;
    }
}

public class MachineJoltage(int[] targetState)
{
    public double[] GetTargetState()
    {
        return targetState.Select(x => (double)x).ToArray();
    }
}