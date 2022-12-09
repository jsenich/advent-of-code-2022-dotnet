namespace Day09;
class Program
{

    static int PartOne(string[] puzzleInput)
    {
        HashSet<(int, int)> tailPositions = new HashSet<(int, int)>() { (0, 0) };

        int headX = 0;
        int headY = 0;
        int tailX = 0;
        int tailY = 0;

        foreach (var move in puzzleInput)
        {
            var args = move.Split(' ');
            var count = int.Parse(args[1]);

            while (count > 0)
            {
                switch (args[0])
                {
                    case "R":
                        headX++;
                        break;
                    case "L":
                        headX--;
                        break;
                    case "D":
                        headY++;
                        break;
                    case "U":
                        headY--;
                        break;
                }
                count--;

                if (headY == tailY)
                {
                    if (tailX < headX - 1)
                    {
                        tailX++;
                    }
                    else if (tailX > headX + 1)
                    {
                        tailX--;
                    }
                }
                else
                {
                    if (headX == tailX)
                    {
                        if (tailY < headY - 1)
                        {
                            tailY++;
                        }
                        else if (tailY > headY + 1)
                        {
                            tailY--;
                        }
                    }
                    else
                    {
                        if (Math.Abs(tailX - headX) + Math.Abs(tailY - headY) > 2)
                        {
                            if (args[0] == "U" && (headX - 1 == tailX || headX + 1 == tailX))
                            {
                                tailX = headX;
                                tailY = headY + 1;
                            }
                            else if (args[0] == "D" && (headX - 1 == tailX || headX + 1 == tailX))
                            {
                                tailX = headX;
                                tailY = headY - 1;
                            }
                            else if (args[0] == "L" && (headY + 1 == tailY || headY - 1 == tailY))
                            {
                                tailX = headX + 1;
                                tailY = headY;
                            }
                            else if (args[0] == "R" && (headY + 1 == tailY || headY - 1 == tailY))
                            {
                                tailX = headX - 1;
                                tailY = headY;
                            }
                        }
                    }
                }

                tailPositions.Add((tailY, tailX));
            }
        }

        return tailPositions.Count;
    }

    static void Main()
    {
        var puzzleInput = File.ReadAllLines("input.txt");

        //         var puzzleInput = """
        // R 4
        // U 4
        // L 3
        // D 1
        // R 4
        // D 1
        // L 5
        // R 2
        // """.Split('\n', StringSplitOptions.TrimEntries);


        Console.WriteLine($"PartOne: {PartOne(puzzleInput)}"); // 6190
    }
}
