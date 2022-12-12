using System.Text.RegularExpressions;

namespace Day11;

class Monkey
{
    static Regex startingItemsPattern = new Regex(@"Starting items: (?:(\d+)(?:, )?)+");
    static Regex divisibleByPattern = new Regex(@"Test: divisible by (\d+)");
    static Regex truePattern = new Regex(@"If true: throw to monkey (\d+)");
    static Regex falsePattern = new Regex(@"If false: throw to monkey (\d+)");
    static Regex operationPattern = new Regex(@"Operation: new = (?<left>\w+) (?<operator>[*,+]) (?<right>[\d,\w]+)");



    public List<long> Items { get; private set; }
    public long DivisibleBy { get; private set; }

    public string Operator { get; private set; }

    public string LeftOperand { get; private set; }
    public string RightOperand { get; private set; }

    public int TrueCondition { get; private set; }
    public int FalseCondition { get; private set; }
    public long Inspections { get; set; } = 0;

    public static Monkey FromData(string data)
    {
        var items = startingItemsPattern.Matches(data)[0]
            .Groups[1].Captures
            .Select(x => long.Parse(x.ToString())).ToList();

        var divisibleBy = long.Parse(divisibleByPattern.Match(data).Groups[1].Captures[0].Value);
        var trueCondition = int.Parse(truePattern.Match(data).Groups[1].Captures[0].Value);
        var falseCondition = int.Parse(falsePattern.Match(data).Groups[1].Captures[0].Value);
        var operation = operationPattern.Match(data);

        return new Monkey
        {
            Items = items,
            DivisibleBy = divisibleBy,
            TrueCondition = trueCondition,
            FalseCondition = falseCondition,
            LeftOperand = operation.Groups["left"].Value,
            Operator = operation.Groups["operator"].Value,
            RightOperand = operation.Groups["right"].Value
        };
    }
}

class Program
{
    static long PartOne(string[] monkeyNotes)
    {
        var monkeys = monkeyNotes.Select(d => Monkey.FromData(d)).ToArray();

        foreach (var round in Enumerable.Range(1, 20))
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    long right;
                    if (!long.TryParse(monkey.RightOperand, out right))
                    {
                        right = item;
                    }
                    long worryLevel = monkey.Operator == "+" ? item + right : item * right;
                    worryLevel = (long)(worryLevel / 3);

                    int toMonkey = worryLevel % monkey.DivisibleBy == 0 ? monkey.TrueCondition : monkey.FalseCondition;
                    monkeys[toMonkey].Items.Add(worryLevel);

                    monkey.Inspections++;
                }
                monkey.Items.Clear();
            }
        }

        var topMonkeys = monkeys.OrderByDescending(m => m.Inspections).Take(2).ToArray();
        var monkeyBusiness = topMonkeys[0].Inspections * topMonkeys[1].Inspections;

        return monkeyBusiness;
    }

    static long PartTwo(string[] monkeyNotes)
    {
        var monkeys = monkeyNotes.Select(d => Monkey.FromData(d)).ToArray();
        var mod = monkeys.Select(m => m.DivisibleBy).Aggregate((long)1, (a, b) => a * b);

        foreach (var round in Enumerable.Range(1, 10_000))
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    long right;
                    if (!long.TryParse(monkey.RightOperand, out right))
                    {
                        right = item;
                    }
                    long worryLevel = monkey.Operator == "+" ? item + right : item * right;
                    worryLevel = (long)(worryLevel % mod);

                    int toMonkey = worryLevel % monkey.DivisibleBy == 0 ? monkey.TrueCondition : monkey.FalseCondition;
                    monkeys[toMonkey].Items.Add(worryLevel);

                    monkey.Inspections++;
                }
                monkey.Items.Clear();
            }
        }


        var topMonkeys = monkeys.OrderByDescending(m => m.Inspections).Take(2).ToArray();
        var monkeyBusiness = topMonkeys[0].Inspections * topMonkeys[1].Inspections;

        return monkeyBusiness;
    }

    static void Main()
    {
        var puzzleInput = File.ReadAllText("input.txt");

        var monkeyNotes = puzzleInput.Split(new string[] { "\n\n" }, StringSplitOptions.None);

        Console.WriteLine($"Part One: {PartOne(monkeyNotes)}"); // 72884
        Console.WriteLine($"Part Two: {PartTwo(monkeyNotes)}"); // 15310845153
    }
}
