namespace Day06;
class Program
{
    static int GetStartPosition(char[] stream, int markerLength)
    {
        int start = 0;

        while (true)
        {
            var window = Enumerable.Range(start, markerLength).Select(i => stream[i]).ToArray();
            HashSet<char> uniqueChars = new HashSet<char>(window);

            if (uniqueChars.Count == markerLength)
            {
                break;
            }

            start++;
        }

        return start + markerLength;
    }

    static void Main(string[] args)
    {
        var puzzleInput = File.ReadAllText("input.txt").TrimEnd().ToArray();

        Console.WriteLine($"PartOne: {GetStartPosition(puzzleInput, 4)}"); // 1909
        Console.WriteLine($"PartTwo: {GetStartPosition(puzzleInput, 14)}"); // 3380
    }
}
