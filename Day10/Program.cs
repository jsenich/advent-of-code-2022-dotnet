using System.Text;

namespace Day10;
class Program
{
    static int PartOne(string[] puzzleInput)
    {
        int x = 1;
        int cycle = 1;

        var signalStrengths = new List<int>();
        Dictionary<int, int> adds = new Dictionary<int, int>();

        var cycleChecks = new int[] { 20, 60, 100, 140, 180, 220 };
        foreach (var line in puzzleInput)
        {
            if (cycleChecks.Contains(cycle))
            {
                signalStrengths.Add(cycle * x);
            }
            var args = line.Split(" ");
            if (args[0] == "noop")
            {
                cycle++;
            }
            else
            {
                adds[cycle + 1] = int.Parse(args[1]);
                cycle++;
                if (cycleChecks.Contains(cycle))
                {
                    signalStrengths.Add(cycle * x);
                }
            }

            if (adds.ContainsKey(cycle))
            {
                x += adds[cycle];
                cycle++;
            }
        }

        return signalStrengths.Sum();
    }

    static int[] GetSpriteWindow(int startPos)
    {
        return Enumerable.Range(startPos - 1, 3).ToArray();
    }

    static string RenderGrid(string[,] grid)
    {
        var sb = new StringBuilder(string.Empty);
        for (var row = 0; row < grid.GetLength(0); row++)
        {
            for (var col = 0; col < grid.GetLength(1); col++)
            {
                sb.Append(grid[row, col]);
            }
            sb.Append("\n");
        }

        return sb.ToString();
    }

    static string PartTwo(string[] puzzleInput)
    {
        var crt = new string[6, 40];
        int x = 1;
        int cycle = 0;

        Dictionary<int, int> adds = new Dictionary<int, int>();
        Dictionary<int, int> cycleLookup = new Dictionary<int, int>() { { 0, x } };

        foreach (var line in puzzleInput)
        {
            var args = line.Split(" ");
            if (args[0] == "noop")
            {
                cycleLookup[++cycle] = x;
            }
            else
            {
                cycleLookup[++cycle] = x;
                x += int.Parse(args[1]);
                cycleLookup[++cycle] = x;
            }
        }

        var column = 0;
        var row = 0;

        foreach (int key in cycleLookup.Keys.Order())
        {
            if (row > 5) break;

            var sprite = GetSpriteWindow(cycleLookup[(key)]);
            if (sprite.Contains(key % 40))
            {
                crt[row, column] = "#";
            }
            else
            {
                crt[row, column] = ".";
            }

            if (column == 39)
            {
                column = 0;
                row++;

                continue;
            }
            column++;
        }

        return RenderGrid(crt);
    }

    static void Main()
    {
        var puzzleInput = File.ReadAllLines("input.txt");

        Console.WriteLine($"Part One: {PartOne(puzzleInput)}"); // 17940
        Console.WriteLine($"Part Two: \n\n{PartTwo(puzzleInput)}");

        /*
        ####..##..###...##....##.####...##.####.
        ...#.#..#.#..#.#..#....#.#.......#....#.
        ..#..#....###..#..#....#.###.....#...#..
        .#...#....#..#.####....#.#.......#..#...
        #....#..#.#..#.#..#.#..#.#....#..#.#....
        ####..##..###..#..#..##..#.....##..####.
        */

    }
}
