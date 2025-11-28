using _2020.Structure;

namespace _2020.Days.Day4;

public class Day4Part1 : Part<int>
{
    public override int Run(string input)
    {
        var result = 0;

        var rows = input.Split("\r\n");

        var passports = new List<Passport>();
        
        GetPassports(passports, rows);

        result = passports.Count(p => p.IsValid());
        
        return result;
    }

    private static void GetPassports(List<Passport> passports, string[] values)
    {
        var passport = new Passport();
        foreach (var value in values)
        {
            if (value == "")
            {
                passports.Add(passport);
                passport = new Passport();
                continue;
            }

            var properties = value.Split(' ');
            foreach (var property in properties)
            {
                var data = property.Split(':');
                passport.AddField(data[0]);
            }
        }
        
        passports.Add(passport);
    }
}

public class Passport
{
    private List<string> Fields { get; set; } = [];

    public void AddField(string field)
    {
        Fields.Add(field);
    }

    public bool IsValid()
    {
        return Fields.Contains("byr") && Fields.Contains("iyr") && Fields.Contains("eyr") && Fields.Contains("hgt")
               && Fields.Contains("hcl") && Fields.Contains("ecl") && Fields.Contains("pid");
    }
}