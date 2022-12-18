namespace Day18;
class Program
{
    static List<(int x, int y, int z)> CubeFaces((int x, int y, int z) cube)
    {
        return new List<(int x, int y, int z)> {
            {(cube.x + 1, cube.y, cube.z)},
            {(cube.x - 1, cube.y, cube.z)},
            {(cube.x, cube.y + 1, cube.z)},
            {(cube.x, cube.y - 1, cube.z)},
            {(cube.x, cube.y, cube.z + 1)},
            {(cube.x, cube.y, cube.z - 1)}
         };
    }

    static int PartOne(string[] puzzleInput)
    {
        var exposedSides = 0;
        var cubes = new HashSet<(int x, int y, int z)>();
        var coords = puzzleInput.Select(
            line => line.Split(",", 3, StringSplitOptions.TrimEntries)
            switch
            { var coords => (int.Parse(coords[0]), int.Parse(coords[1]), int.Parse(coords[2])) }
        );

        foreach ((int x, int y, int z) cube in coords)
        {
            exposedSides += 6;

            foreach (var face in CubeFaces(cube))
            {
                if (cubes.Contains(face))
                {
                    exposedSides -= 2;
                }
            }
            cubes.Add(cube);
        }

        return exposedSides;
    }


    static void Main(string[] args)
    {
        var puzzleInput = File.ReadAllLines("input.txt");

        // var puzzleInput = """
        // 2,2,2
        // 1,2,2
        // 3,2,2
        // 2,1,2
        // 2,3,2
        // 2,2,1
        // 2,2,3
        // 2,2,4
        // 2,2,6
        // 1,2,5
        // 3,2,5
        // 2,1,5
        // 2,3,5
        // """.Split("\n", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);


        Console.WriteLine($"Part One: {PartOne(puzzleInput)}"); // 3564
    }
}
