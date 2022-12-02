namespace Day01;
class Program
{
    static int PartOne(string[] puzzleInput)
    {
        int currentElf = 0;
        List<int> elfCalories = new List<int>() { 0 };
        foreach (var line in puzzleInput)
        {
            if (line == "")
            {
                currentElf++;
                elfCalories.Add(0);
                continue;
            }
            elfCalories[currentElf] += Int32.Parse(line);
        }

        return elfCalories.Max();
    }

    static int PartTwo(string[] puzzleInput)
    {
        int currentElf = 0;
        List<int> elfCalories = new List<int>() { 0 };
        foreach (var line in puzzleInput)
        {
            if (line == "")
            {
                currentElf++;
                elfCalories.Add(0);
                continue;
            }
            elfCalories[currentElf] += Int32.Parse(line);
        }
        return elfCalories.OrderDescending().Take(3).Sum();
    }

    static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        Console.WriteLine($"PartOne: {PartOne(input)}");  // 74394
        Console.WriteLine($"PartTwo: {PartTwo(input)}"); // 212836
    }
}
