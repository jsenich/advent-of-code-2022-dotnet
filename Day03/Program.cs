namespace Day03;
class Program
{
    static int PartOne(IEnumerable<string> puzzleInput)
    {
        var priorities = new List<int>();

        foreach (var p in puzzleInput)
        {
            int compartmentSize = p.Length / 2;
            var compartment1 = p.Substring(0, compartmentSize);
            var compartment2 = p.Substring(compartmentSize, p.Length - compartmentSize);

            var common = compartment1.Intersect(compartment2).FirstOrDefault();
            int priority = (int)common % 32;
            if (Char.IsUpper(common))
            {
                priority += 26;
            }

            priorities.Add(priority);
        }

        return priorities.Sum();
    }

    static int PartTwo(IEnumerable<string> puzzleInput)
    {
        var priorities = new List<int>();
        var sacks = new List<string>();

        foreach (var p in puzzleInput)
        {
            sacks.Add(p);
            if (sacks.Count == 3)
            {
                var common = sacks[0].Intersect(sacks[1]).Intersect(sacks[2]).FirstOrDefault();
                int priority = (int)common % 32;
                if (Char.IsUpper(common))
                {
                    priority += 26;
                }

                priorities.Add(priority);
                sacks.Clear();
            }
        }

        return priorities.Sum();
    }

    static void Main(string[] args)
    {
        var input = File.ReadLines("input.txt");

        Console.WriteLine($"PartOne: {PartOne(input)}"); // 8085
        Console.WriteLine($"PartTwo: {PartTwo(input)}"); // 2515
    }
}
