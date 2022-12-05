using System.Text.RegularExpressions;

namespace Day05;
class Program
{

    static string PartOne(string puzzleInput)
    {
        var data = puzzleInput.Split(
            new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries
        );

        var stackData = data[0];
        var moveData = data[1];

        List<List<string>> stacks = new List<List<string>>();
        List<string> lines = stackData.Split("\n", StringSplitOptions.None)
            .Where(l => !l.StartsWith(" 1"))
            .Select(l => l).ToList();

        int colCount = lines[lines.Count - 1].Trim()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries).Length;

        for (int i = 0; i < colCount; i++)
        {
            stacks.Add(new List<string>());
        }

        foreach (var line in lines)
        {
            int counter = 0;
            var s = new List<string>();
            foreach (var c in line)
            {
                if (counter != 0 && counter % 4 == 0)
                {
                    s.Add("-");
                }
                else
                {
                    s.Add(c.ToString());
                }
                counter++;
            }
            var l = String.Join("", s)
                .Split("-", StringSplitOptions.None)
                .Select(s => s.Replace("[", " ").Replace("]", " "))
                .ToList();

            for (int i = 0; i < l.Count; i++)
            {
                var c = l[i].Trim();
                if (c == "")
                {
                    continue;
                }
                stacks[i].Add(c);
            }
        }

        Regex regex = new Regex(@"\d+");
        foreach (var move in moveData.Trim().Split("\n"))
        {
            var matches = regex.Matches(move).Select(x => Int32.Parse(x.Value)).ToArray();
            for (int i = 0; i < matches[0]; i++)
            {
                stacks[matches[2] - 1].Insert(0, stacks[matches[1] - 1][0]);
                stacks[matches[1] - 1].RemoveAt(0);
            }
        }

        string result = String.Join("", stacks.Select(s => s[0]).ToArray());

        return result;
    }

    static string PartTwo(string puzzleInput)
    {
        var data = puzzleInput.Split(
            new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries
        );

        var stackData = data[0];
        var moveData = data[1];

        List<List<string>> stacks = new List<List<string>>();
        List<string> lines = stackData.Split("\n", StringSplitOptions.None)
            .Where(l => !l.StartsWith(" 1"))
            .Select(l => l).ToList();

        int colCount = lines[lines.Count - 1].Trim()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries).Length;

        for (int i = 0; i < colCount; i++)
        {
            stacks.Add(new List<string>());
        }

        foreach (var line in lines)
        {
            int counter = 0;
            var s = new List<string>();
            foreach (var c in line)
            {
                if (counter != 0 && counter % 4 == 0)
                {
                    s.Add("-");
                }
                else
                {
                    s.Add(c.ToString());
                }
                counter++;
            }
            var l = String.Join("", s)
                .Split("-", StringSplitOptions.None)
                .Select(s => s.Replace("[", " ").Replace("]", " "))
                .ToList();

            for (int i = 0; i < l.Count; i++)
            {
                var c = l[i].Trim();
                if (c == "")
                {
                    continue;
                }
                stacks[i].Add(c);
            }
        }

        Regex regex = new Regex(@"\d+");
        foreach (var move in moveData.Trim().Split("\n"))
        {
            var matches = regex.Matches(move).Select(x => Int32.Parse(x.Value)).ToArray();
            stacks[matches[2] - 1].InsertRange(0, stacks[matches[1] - 1].GetRange(0, matches[0]));
            stacks[matches[1] - 1].RemoveRange(0, matches[0]);
        }

        string result = String.Join("", stacks.Select(s => s[0]).ToArray());

        return result;
    }

    static void Main(string[] args)
    {
        var input = File.ReadAllText("input.txt");

        Console.WriteLine($"PartOne: {PartOne(input)}"); // PTWLTDSJV
        Console.WriteLine($"PartTwo: {PartTwo(input)}"); // WZMFVGGZP
    }
}
