namespace Day08;
class Program
{
    static void Main(string[] args)
    {
        var puzzleInput = File.ReadAllLines("input.txt");

        var rows = puzzleInput.Length;
        var cols = puzzleInput[0].Length;

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
            var largest = Enumerable.Range(1, rows - 1).Select(x => treeGrid[i, x]).Max();
            if (largest > treeGrid[i, 0])
            {
                visibleTrees++;
            }

            if (largest > treeGrid[i, cols - 1])
            {
                visibleTrees++;
            }
        }

        for (int i = 1; i < cols - 1; i++)
        {
            var largest = Enumerable.Range(1, cols - 1).Select(y => treeGrid[y, i]).Max();
            if (largest > treeGrid[0, i])
            {
                visibleTrees++;
            }

            if (largest > treeGrid[cols - 1, i])
            {
                visibleTrees++;
            }
        }


        // Console.WriteLine($"PartOne: {}");
        // Console.WriteLine($"PartTwo: {}");
    }
}
