namespace Day07;

class DirContents
{
    public HashSet<string> Directories { get; private set; }
    public Dictionary<string, int> Files { get; private set; }

    public DirContents()
    {
        Directories = new HashSet<string>() { "/" };
        Files = new Dictionary<string, int>();
    }

    public int CalculateDirSize(string dir, int? maxSize = null)
    {
        var totalSize = Files.Where(f => f.Key.StartsWith(dir)).Select(f => f.Value).Sum();

        if (maxSize is not null)
        {
            if (totalSize <= maxSize)
            {
                return totalSize;
            }
            else
            {
                return 0;
            }
        }

        return totalSize;
    }
}

class Program
{
    static void Main()
    {
        var puzzleInput = System.IO.File.ReadAllLines("input.txt");

        var dirContents = new DirContents();
        var currentDirectory = "/";

        foreach (var line in puzzleInput)
        {
            var args = line.Split(' ', StringSplitOptions.TrimEntries);

            if (args[0] == "$")
            {
                if (args[1] == "cd")
                {
                    if (args[2] == "..")
                    {
                        if (currentDirectory != "/")
                        {
                            currentDirectory = Path.GetDirectoryName(currentDirectory);
                        }
                    }
                    else
                    {
                        if (currentDirectory != args[2])
                        {
                            currentDirectory = Path.Join(currentDirectory, args[2]);
                        }
                    }
                }
            }
            else
            {
                if (args[0] == "dir")
                {
                    dirContents.Directories.Add(Path.Join(currentDirectory, args[1]));
                }
                else
                {
                    dirContents.Files[Path.Join(currentDirectory, args[1])] = int.Parse(args[0]);
                }
            }
        }

        var totals = dirContents.Directories.Select(d => dirContents.CalculateDirSize(d, 100000)).Sum();

        Console.WriteLine($"PartOne: {totals}"); // 1792222

        var totalDisk = 70000000;
        var neededSpace = 30000000;

        var rootSize = dirContents.Files.Select(f => f.Value).Sum();

        List<int> allSizes = new List<int>();
        allSizes.Add(rootSize);
        allSizes.AddRange(dirContents.Directories.Select(d => dirContents.CalculateDirSize(d)));
        allSizes = allSizes.Where(s => s >= neededSpace - (totalDisk - rootSize)).Select(s => s).Order().ToList();

        Console.WriteLine($"PartTwo: {allSizes.First()}"); // 1112963
    }
}
