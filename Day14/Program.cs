using System.Text.RegularExpressions;

namespace Day14;
class Program
{

    static int PartOne(string[] puzzleInput)
    {
        var regex = new Regex(@"(?:(?<x>\d+),(?<y>\d+))");
        (int x, int y) start = (500, 0);
        var pathPoints = new HashSet<(int x, int y)>();

        foreach (var line in puzzleInput)
        {
            List<(int x, int y)> points = regex.Matches(line).Select(m => (int.Parse(m.Groups["x"].Value), int.Parse(m.Groups["y"].Value))).ToList();

            var left = points.First();
            points.RemoveAt(0);

            foreach (var point in points)
            {
                if (point.x == left.x)
                {
                    var s = Math.Min(left.y, point.y);
                    var count = Math.Max(left.y, point.y) - s;
                    foreach (var y in Enumerable.Range(s, count + 1))
                    {
                        pathPoints.Add((point.x, y));
                    }
                }
                else
                {
                    var s = Math.Min(left.x, point.x);
                    var count = Math.Max(left.x, point.x) - s;
                    foreach (var x in Enumerable.Range(s, count + 1))
                    {
                        pathPoints.Add((x, point.y));
                    }
                }
                left = point;
            }

        }

        var maxY = pathPoints.Select(p => p.y).Max();

        var sandUnits = 0;

        bool sentinel = true;
        while (sentinel)
        {
            var current = start;
            while (true)
            {
                if (!pathPoints.Contains((current.x, current.y + 1)))
                {
                    current.y++;
                }
                else if (!pathPoints.Contains((current.x - 1, current.y + 1)))
                {
                    current.x--;
                    current.y++;
                }
                else if (!pathPoints.Contains((current.x + 1, current.y + 1)))
                {
                    current.x++;
                    current.y++;
                }
                else
                {
                    pathPoints.Add(current);
                    break;
                }
                if (current.y > maxY)
                {
                    sentinel = false;
                    break;
                }
            }

            if (sentinel) sandUnits++;
        }

        return sandUnits;
    }

    static void Main()
    {
        var puzzleInput = File.ReadAllLines("input.txt");

        // var puzzleInput = """
        // 498,4 -> 498,6 -> 496,6
        // 503,4 -> 502,4 -> 502,9 -> 494,9
        // """.Split("\n", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);


        Console.WriteLine($"Part One: {PartOne(puzzleInput)}"); // 625
    }
}
