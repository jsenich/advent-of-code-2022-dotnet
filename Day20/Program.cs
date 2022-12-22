namespace Day20;


public static class MyExtensions
{
    public static void Rotate<T>(this List<T> list, int count)
    {
        if (count == 0) { return; }
        count %= list.Count;
        if (count == 0) return;
        int left = count < 0 ? -count : list.Count + count;
        int right = count > 0 ? count : list.Count - count;

        if (left <= right)
        {
            for (int i = 0; i < left; i++)
            {
                var temp = list[0];
                list.RemoveAt(0);
                list.Add(temp);
            }
        }
        else
        {
            for (int i = 0; i < right; i++)
            {
                var temp = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(0, temp);
            }
        }

    }

    public static void Rotate<T>(this List<T> list, long count)
    {
        if (count == 0) { return; }
        count %= list.Count;
        if (count == 0) return;
        long left = count < 0 ? -count : list.Count + count;
        long right = count > 0 ? count : list.Count - count;

        if (left <= right)
        {
            for (int i = 0; i < left; i++)
            {
                var temp = list[0];
                list.RemoveAt(0);
                list.Add(temp);
            }
        }
        else
        {
            for (int i = 0; i < right; i++)
            {
                var temp = list[list.Count - 1];
                list.RemoveAt(list.Count - 1);
                list.Insert(0, temp);
            }
        }

    }
}

class Program
{
    static int PartOne(string[] puzzleInput)
    {
        var numbers = puzzleInput.Select((n, i) => (i, int.Parse(n))).ToList<(int pos, int n)>();
        var mixedNumbers = numbers.ToList();
        var size = numbers.Count;

        // Console.WriteLine("Start:");
        // Console.WriteLine(String.Join(", ", numbers.Select(x => x.n.ToString())));
        // Console.WriteLine("---------------------");
        // Console.WriteLine("---------------------\n\n");
        //     // var step = String.Join(", ", mixedNumbers.Select(x => x.n.ToString()));
        //     // // steps.Add(step);
        //     // Console.WriteLine(step);
        //     // Console.WriteLine("---------------------");

        // }

        foreach (var num in numbers)
        {
            var currentIndex = mixedNumbers.IndexOf(num);

            mixedNumbers.Rotate(-currentIndex);
            mixedNumbers.RemoveAt(0);
            mixedNumbers.Rotate(-num.n);
            mixedNumbers.Insert(0, num);

            // var step = String.Join(", ", mixedNumbers.Select(x => x.n.ToString()));
            // // steps.Add(step);
            // Console.WriteLine(step);
            // Console.WriteLine("---------------------");

        }


        var zeroStart = mixedNumbers.FindIndex(x => x.n == 0);

        var groove1 = mixedNumbers[(zeroStart + 1000) % size];
        var groove2 = mixedNumbers[(zeroStart + 2000) % size];
        var groove3 = mixedNumbers[(zeroStart + 3000) % size];

        return groove1.n + groove2.n + groove3.n;
    }

    static long PartTwo(string[] puzzleInput)
    {
        var numbers = puzzleInput.Select((n, i) => ((long)i, long.Parse(n) * 811589153)).ToList<(long pos, long n)>();
        var mixedNumbers = numbers.ToList();
        var size = numbers.Count;

        foreach (var _ in Enumerable.Range(0, 10))
        {
            foreach (var num in numbers)
            {
                var currentIndex = mixedNumbers.IndexOf(num);

                mixedNumbers.Rotate(-currentIndex);
                mixedNumbers.RemoveAt(0);
                mixedNumbers.Rotate(-num.n);
                mixedNumbers.Insert(0, num);
            }
        }

        var zeroStart = mixedNumbers.FindIndex(x => x.n == 0);

        var groove1 = mixedNumbers[(zeroStart + 1000) % size];
        var groove2 = mixedNumbers[(zeroStart + 2000) % size];
        var groove3 = mixedNumbers[(zeroStart + 3000) % size];

        return groove1.n + groove2.n + groove3.n;
    }
    static void Main()
    {
        var puzzleInput = File.ReadAllText("input.txt").Trim().Split("\n", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);

        // var puzzleInput = """
        // 1
        // 2
        // -3
        // 3
        // -2
        // 0
        // 4
        // """.Split("\n", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);


        // Console.WriteLine($"Part One: {PartOne(puzzleInput)}"); // 13289
        Console.WriteLine($"Part One: {PartTwo(puzzleInput)}"); //
    }
}

