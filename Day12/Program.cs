namespace Day12;
class Program
{
    static void Main(string[] args)
    {
        var puzzleInput = File.ReadAllLines(@"input.txt");

        var heightmap = new char[puzzleInput.Length, puzzleInput[0].Length];

        (int y, int x) start;
        (int y, int x) end;

        for (var row = 0; row < heightmap.GetLength(0); row++)
        {
            for (var col = 0; col < heightmap.GetLength(1); col++)
            {
                if (puzzleInput[row][col] == 'S')
                {
                    start = (row, col);
                }
                else if (puzzleInput[row][col] == 'E')
                {
                    end = (row, col);
                }

                heightmap[row, col] = puzzleInput[row][col];
            }
        }


        Console.WriteLine("Hello, World!");
    }
}
