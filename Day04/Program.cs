namespace Day04;
class Program
{
    static int PartOne(IEnumerable<string> puzzleInput)
    {
        int overlapCount = 0;

        foreach (var line in puzzleInput)
        {
            var ranges = line.Split(",", StringSplitOptions.TrimEntries).Select(
                pair => pair
                .Split("-", StringSplitOptions.TrimEntries)
                .Select(x => Int32.Parse(x))
                .ToArray()
            ).ToArray();

            var range1 = Enumerable.Range(ranges[0][0], ranges[0][1] - ranges[0][0] + 1);
            var range2 = Enumerable.Range(ranges[1][0], ranges[1][1] - ranges[1][0] + 1);

            if (
                range1.Intersect(range2).Count() == range1.Count() ||
                range2.Intersect(range1).Count() == range2.Count()
            ) { overlapCount++; }
        }

        return overlapCount;
    }

    static int PartTwo(IEnumerable<string> puzzleInput)
    {
        int overlapCount = 0;

        foreach (var line in puzzleInput)
        {
            var ranges = line.Split(",", StringSplitOptions.TrimEntries).Select(
                pair => pair
                .Split("-", StringSplitOptions.TrimEntries)
                .Select(x => Int32.Parse(x))
                .ToArray()
            ).ToArray();

            var range1 = Enumerable.Range(ranges[0][0], ranges[0][1] - ranges[0][0] + 1);
            var range2 = Enumerable.Range(ranges[1][0], ranges[1][1] - ranges[1][0] + 1);

            if (range1.Intersect(range2).Any())
            {
                overlapCount++;
            }
        }

        return overlapCount;
    }

    static void Main(string[] args)
    {
        var input = File.ReadLines("input.txt");

        Console.WriteLine($"PartOne: {PartOne(input)}"); // 498
        Console.WriteLine($"PartTwo: {PartTwo(input)}"); // 859
    }
}
