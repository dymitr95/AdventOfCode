using System.Text.RegularExpressions;
using _2020.Structure;

namespace _2020.Days.Day4;

public class Day4Part2 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var passports = new List<NewPassport>();
        
        GetPassports(passports, rows);

        result = passports.Count(p => p.IsValid());
        
        return result;
    }

    private static void GetPassports(List<NewPassport> passports, string[] values)
    {
        var passport = new NewPassport();
        foreach (var value in values)
        {
            if (value == "")
            {
                passports.Add(passport);
                passport = new NewPassport();
                continue;
            }

            var properties = value.Split(' ');
            foreach (var property in properties)
            {
                var data = property.Split(':');
                passport.AddField(data[0], data[1]);
            }
        }
        
        passports.Add(passport);
    }
}

public class NewPassport
{
    private Dictionary<string, string> Fields { get; set; } = [];

    public void AddField(string field, string value)
    {
        Fields.Add(field, value);
    }

    public bool IsValid()
    {
        if (!ContainsRequiredFields()) return false;
        if (!ByrIsValid()) return false;
        if (!IyrIsValid()) return false;
        if (!EyrIsValid()) return false;
        if (!HgtIsValid()) return false;
        if (!HclIsValid()) return false;
        if (!EclIsValid()) return false;

        return PidIsValid();
    }

    private bool ContainsRequiredFields()
    {
        return Fields.ContainsKey("byr") && Fields.ContainsKey("iyr") && Fields.ContainsKey("eyr") && Fields.ContainsKey("hgt")
               && Fields.ContainsKey("hcl") && Fields.ContainsKey("ecl") && Fields.ContainsKey("pid");
    }

    private bool ByrIsValid()
    {
        return Regex.IsMatch(Fields["byr"], @"^(19[2-9][0-9]|200[0-2])$");
    }
    
    private bool IyrIsValid()
    {
        return Regex.IsMatch(Fields["iyr"], @"^(201[0-9]|2020)$");
    }
    
    private bool EyrIsValid()
    {
        return Regex.IsMatch(Fields["eyr"], @"^(202[0-9]|2030)$");
    }
    
    private bool HgtIsValid()
    {
        return Regex.IsMatch(Fields["hgt"], @"^((1[5-8][0-9]|19[0-3])cm|(59|6[0-9]|7[0-6])in)$");
    }
    
    private bool HclIsValid()
    {
        return Regex.IsMatch(Fields["hcl"], @"^#[0-9a-fA-F]{6}$");
    }
    
    private bool EclIsValid()
    {
        return Regex.IsMatch(Fields["ecl"], @"^(amb|blu|brn|gry|grn|hzl|oth)$");
    }
    
    private bool PidIsValid()
    {
        return Regex.IsMatch(Fields["pid"], @"^\d{9}$");
    }
}