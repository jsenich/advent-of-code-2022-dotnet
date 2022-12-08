namespace Day08;
class Program
{
    static void Main(string[] args)
    {
        var puzzleInput = File.ReadAllLines("input.txt");
        //         var puzzleInput = """
        // 30373
        // 25512
        // 65332
        // 33549
        // 35390
        // """.Trim().Split("\n");

        var rows = puzzleInput.Length;
        var cols = puzzleInput[0].Length;
        HashSet<string> seenTrees = new HashSet<string>();

        int[,] treeGrid = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                treeGrid[i, j] = int.Parse(puzzleInput[i][j].ToString());
            }
        }

        int visibleTrees = rows * 2 + (cols - 2) * 2;

        for (int i = 1; i < rows - 1; i++)
        {
            var largest = Enumerable.Range(0, rows - 1).Select(x => treeGrid[i, x]).Max();
            var lastTree = treeGrid[i, 0];

            for (int j = 1; j < cols - 1; j++)
            {
                if (treeGrid[i, j] > lastTree)
                {
                    seenTrees.Add(String.Join('-', i.ToString(), j.ToString()));
                    lastTree = treeGrid[i, j];
                    // visibleTrees++;
                    if (treeGrid[i, j] == largest)
                    {
                        break;
                    }
                }
            }

            lastTree = treeGrid[i, cols - 1];
            for (int j = cols - 2; j >= 1; j--)
            {
                if (treeGrid[i, j] > lastTree)
                {
                    seenTrees.Add(String.Join('-', i.ToString(), j.ToString()));
                    lastTree = treeGrid[i, j];
                    // visibleTrees++;
                    if (treeGrid[i, j] == largest)
                    {
                        break;
                    }
                }
            }
        }


        for (int i = 1; i < cols - 1; i++)
        {
            var largest = Enumerable.Range(0, cols - 1).Select(x => treeGrid[x, i]).Max();
            var lastTree = treeGrid[0, i];

            for (int j = 1; j < rows - 1; j++)
            {
                if (treeGrid[j, i] > lastTree)
                {
                    seenTrees.Add(String.Join('-', j.ToString(), i.ToString()));
                    lastTree = treeGrid[j, i];
                    // visibleTrees++;
                    if (treeGrid[j, i] == largest)
                    {
                        break;
                    }
                }
            }

            lastTree = treeGrid[rows - 1, i];
            for (int j = rows - 2; j >= 1; j--)
            {
                if (treeGrid[j, i] > lastTree)
                {
                    seenTrees.Add(String.Join('-', j.ToString(), i.ToString()));
                    lastTree = treeGrid[j, i];
                    // visibleTrees++;
                    if (treeGrid[j, i] == largest)
                    {
                        break;
                    }
                }
            }
        }


        Console.WriteLine($"PartOne: {visibleTrees + seenTrees.Count}"); // 1796


        HashSet<int> scenicScores = new HashSet<int>();


        Console.WriteLine($"PartTwo: {scenicScores.Max()}");
    }
}
