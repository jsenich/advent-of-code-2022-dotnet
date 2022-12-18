using System.Text.RegularExpressions;


namespace Day15;

class Sensor
{
    public (int x, int y) Coords { get; set; }
    public (int x, int y) BeaconCoords { get; set; }
    public int Distance
    {
        get
        {
            return Math.Abs(Coords.x - BeaconCoords.x) + Math.Abs(Coords.y - BeaconCoords.y);
        }
    }
}



class Program
{

    static int PartOne(string puzzleInput, int y)
    {
        var pattern = @"Sensor at x=(?<x1>-?\d+), y=(?<y1>-?\d+): closest beacon is at x=(?<x2>-?\d+), y=(?<y2>-?\d+)";
        var coordinates = new HashSet<(int x, int y)>();
        var beacons = new HashSet<(int x, int y)>();

        foreach (Match m in Regex.Matches(puzzleInput, pattern, RegexOptions.Multiline))
        {
            var sensor = new Sensor
            {
                Coords = (int.Parse(m.Groups["x1"].Value), int.Parse(m.Groups["y1"].Value)),
                BeaconCoords = (int.Parse(m.Groups["x2"].Value), int.Parse(m.Groups["y2"].Value))
            };

            beacons.Add((sensor.BeaconCoords.x, sensor.BeaconCoords.y));
            var distance = sensor.Distance;

            var nextX = distance - Math.Abs(y - sensor.Coords.y);
            var start = sensor.Coords.x - nextX;
            var end = sensor.Coords.x + nextX;
            if (start < end)
            {
                foreach (var x in Enumerable.Range(start, end - start + 1))
                {
                    coordinates.Add((x, y));
                }
            }
        }

        return coordinates.Except(beacons).Count();
    }

    static void Main()
    {
        var puzzleInput = File.ReadAllText("input.txt");
        int startY = 2000000;

        // var puzzleInput = """
        // Sensor at x=2, y=18: closest beacon is at x=-2, y=15
        // Sensor at x=9, y=16: closest beacon is at x=10, y=16
        // Sensor at x=13, y=2: closest beacon is at x=15, y=3
        // Sensor at x=12, y=14: closest beacon is at x=10, y=16
        // Sensor at x=10, y=20: closest beacon is at x=10, y=16
        // Sensor at x=14, y=17: closest beacon is at x=10, y=16
        // Sensor at x=8, y=7: closest beacon is at x=2, y=10
        // Sensor at x=2, y=0: closest beacon is at x=2, y=10
        // Sensor at x=0, y=11: closest beacon is at x=2, y=10
        // Sensor at x=20, y=14: closest beacon is at x=25, y=17
        // Sensor at x=17, y=20: closest beacon is at x=21, y=22
        // Sensor at x=16, y=7: closest beacon is at x=15, y=3
        // Sensor at x=14, y=3: closest beacon is at x=15, y=3
        // Sensor at x=20, y=1: closest beacon is at x=15, y=3
        // """;

        // int startY = 10;


        Console.WriteLine($"Hello, World!: {PartOne(puzzleInput, startY)}"); // 4861076
    }
}
