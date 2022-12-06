namespace Day06;
class Program
{
    static void Main(string[] args)
    {
        var input = File.ReadAllText("input.txt").TrimEnd().ToArray();

        int start = 0;

        while (true)
        {
            var window = Enumerable.Range(start, 4).Select(i => input[i]).ToArray();
            HashSet<char> uniqueChars = new HashSet<char>(window);

            if (uniqueChars.Count == 4)
            {
                break;
            }
            else
            {
                start++;
            }
        }

        int start2 = 1909;

        while (true)
        {
            var window = Enumerable.Range(start2, 14).Select(i => input[i]).ToArray();
            HashSet<char> uniqueChars = new HashSet<char>(window);

            if (uniqueChars.Count == 14)
            {
                break;
            }
            else
            {
                start2++;
            }
        }

        Console.WriteLine($"PartOne: {start + 4}"); // 1909
        Console.WriteLine($"PartTwo: {start2 + 14}"); // 3380
    }
}
