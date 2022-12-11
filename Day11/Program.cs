using System.Text.RegularExpressions;

namespace Day11;


class Monkey
{
    static Regex startingItemsPattern = new Regex(@"Starting items: (?:(\d+)(?:, )?)+");
    static Regex divisibleByPattern = new Regex(@"Test: divisible by (\d+)");
    static Regex truePattern = new Regex(@"If true: throw to monkey (\d+)");
    static Regex falsePattern = new Regex(@"If false: throw to monkey (\d+)");
    static Regex operationPattern = new Regex(@"Operation: new = (?<left>\w+) (?<operator>[*,+]) (?<right>[\d,\w]+)");



    public List<int> Items { get; private set; }
    public int DivisibleBy { get; private set; }

    public string Operator { get; private set; }

    public string LeftOperand { get; private set; }
    public string RightOperand { get; private set; }

    public int TrueCondition { get; private set; }
    public int FalseCondition { get; private set; }
    public int Inspections { get; set; } = 0;

    public static Monkey FromData(string data)
    {
        var items = startingItemsPattern.Matches(data)[0]
            .Groups[1].Captures
            .Select(x => int.Parse(x.ToString())).ToList();

        var divisibleBy = int.Parse(divisibleByPattern.Match(data).Groups[1].Captures[0].Value);
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
    static void Main()
    {
        var puzzleInput = File.ReadAllText("input.txt");
        //         var puzzleInput = """
        // Monkey 0:
        //   Starting items: 79, 98
        //   Operation: new = old * 19
        //   Test: divisible by 23
        //     If true: throw to monkey 2
        //     If false: throw to monkey 3

        // Monkey 1:
        //   Starting items: 54, 65, 75, 74
        //   Operation: new = old + 6
        //   Test: divisible by 19
        //     If true: throw to monkey 2
        //     If false: throw to monkey 0

        // Monkey 2:
        //   Starting items: 79, 60, 97
        //   Operation: new = old * old
        //   Test: divisible by 13
        //     If true: throw to monkey 1
        //     If false: throw to monkey 3

        // Monkey 3:
        //   Starting items: 74
        //   Operation: new = old + 3
        //   Test: divisible by 17
        //     If true: throw to monkey 0
        //     If false: throw to monkey 1
        // """;


        var monkeyNotes = puzzleInput.Split(new string[] { "\n\n" }, StringSplitOptions.None);

        var monkeys = monkeyNotes.Select(d => Monkey.FromData(d)).ToArray();

        foreach (var round in Enumerable.Range(1, 20))
        {
            foreach (var monkey in monkeys)
            {
                foreach (var item in monkey.Items)
                {
                    int right;
                    if (!int.TryParse(monkey.RightOperand, out right))
                    {
                        right = item;
                    }
                    int worryLevel = monkey.Operator == "+" ? item + right : item * right;
                    worryLevel = (int)(worryLevel / 3);

                    int toMonkey = worryLevel % monkey.DivisibleBy == 0 ? monkey.TrueCondition : monkey.FalseCondition;
                    monkeys[toMonkey].Items.Add(worryLevel);

                    monkey.Inspections++;
                }
                monkey.Items.Clear();
            }
        }

        var topMonkeys = monkeys.OrderByDescending(m => m.Inspections).Take(2).ToArray();
        var monkeyBusiness = topMonkeys[0].Inspections * topMonkeys[1].Inspections;

        Console.WriteLine($"Part One: {monkeyBusiness}");
    }
}
