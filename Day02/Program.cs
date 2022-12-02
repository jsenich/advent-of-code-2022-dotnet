namespace Day02;
class Program
{
    static int PartOne(string[] puzzleInput)
    {
        int totalScore = 0;

        var scoreMap = new Dictionary<string, int>(){
            {"X", 1},
            {"Y", 2},
            {"Z", 3}
        };

        var lookup = new Dictionary<string, string>() {
            {"X", "A"},
            {"Y", "B"},
            {"Z", "C"}
        };

        foreach (var round in puzzleInput) {
            var players = round.Split(' ', StringSplitOptions.TrimEntries);
            totalScore += scoreMap[players[1]];
            if (players[0] == lookup[players[1]]) {
                totalScore += 3;
            } else if (players[0] == "A" && lookup[players[1]] == "B") {
                totalScore += 6;
            } else if (players[0] == "A" && lookup[players[1]] == "C") {
                totalScore += 0;
            } else if (players[0] == "B" && lookup[players[1]] == "A") {
                totalScore += 0;
            } else if (players[0] == "B" && lookup[players[1]] == "C") {
                totalScore += 6;
            } else if (players[0] == "C" && lookup[players[1]] == "B") {
                totalScore += 0;
            } else if (players[0] == "C" && lookup[players[1]] == "A") {
                totalScore += 6;
            } else {
                totalScore += 0;
            }
        }


        return totalScore;
    }

    static int PartTwo(string[] puzzleInput)
    {
        int totalScore = 0;

        var scoreMap = new Dictionary<string, int>(){
            {"A", 1},
            {"B", 2},
            {"C", 3}
        };

        var strategies = new Dictionary<string, Dictionary<string, string>>();
        strategies.Add("X", new Dictionary<string, string>(){
            {"A", "C"},
            {"B", "A"},
            {"C", "B"}
        });
        strategies.Add("Y", new Dictionary<string, string>(){
            {"A", "A"},
            {"B", "B"},
            {"C", "C"}
        });
        strategies.Add("Z", new Dictionary<string, string>(){
            {"A", "B"},
            {"B", "C"},
            {"C", "A"}
        });


        foreach (var round in puzzleInput) {
            var players = round.Split(' ', StringSplitOptions.TrimEntries);
            totalScore += scoreMap[strategies[players[1]][players[0]]];


            if (players[0] == strategies[players[1]][players[0]]) {
                totalScore += 3;
            } else if (players[0] == "A" && strategies[players[1]][players[0]] == "B") {
                totalScore += 6;
            } else if (players[0] == "A" && strategies[players[1]][players[0]] == "C") {
                totalScore += 0;
            } else if (players[0] == "B" && strategies[players[1]][players[0]] == "A") {
                totalScore += 0;
            } else if (players[0] == "B" && strategies[players[1]][players[0]] == "C") {
                totalScore += 6;
            } else if (players[0] == "C" && strategies[players[1]][players[0]] == "B") {
                totalScore += 0;
            } else if (players[0] == "C" && strategies[players[1]][players[0]] == "A") {
                totalScore += 6;
            } else {
                totalScore += 0;
            }
        }

        return totalScore;
    }

    static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        Console.WriteLine($"PartOne: {PartOne(input)}"); // 14375
        Console.WriteLine($"PartTwo: {PartTwo(input)}"); // 10274
    }
}
