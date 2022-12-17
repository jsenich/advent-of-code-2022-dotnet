using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using MoreLinq.Extensions;


namespace Day13;
class Program
{

    static int CompareLists(object left, object right)
    {
        if (left.GetType() == typeof(JValue) && right.GetType() != typeof(JValue))
        {
            left = new JArray(left);
        }
        else if (left.GetType() != typeof(JValue) && right.GetType() == typeof(JValue))
        {
            right = new JArray(right);
        }

        if (left.GetType() == right.GetType() && right.GetType() == typeof(JValue))
        {
            return ((JValue)left).Value<int>() - ((JValue)right).Value<int>();
        }
        else if (left.GetType() == right.GetType() && right.GetType() == typeof(JArray))
        {
            foreach (var pair in ((JArray)left).ZipLongest((JArray)right, (l, r) => (l, r)))
            {
                if (pair.l is null)
                {
                    return -1;
                }
                else if (pair.r is null)
                {
                    return 1;
                }

                var compared = CompareLists(pair.l, pair.r);
                if (compared != 0)
                {
                    return compared;
                }
            }
        }
        return 0;
    }

    static int PartOne(string[] packetPairs)
    {
        int correctIndices = 0;

        foreach ((int i, string pair) in Enumerable.Range(0, packetPairs.Length).Select(i => (i, packetPairs[i])))
        {
            var (left, right) = pair.Split("\n", StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries)
            switch
            { var p => (JsonConvert.DeserializeObject(p[0], typeof(JArray)), JsonConvert.DeserializeObject(p[1], typeof(JArray))) };

            if (CompareLists(left, right) <= 0)
            {
                correctIndices += i + 1;
            }
        }

        return correctIndices;
    }

    static void Main(string[] args)
    {

        var puzzleInput = File.ReadAllText("input.txt");

        // var pairs = """
        // [1,1,3,1,1]
        // [1,1,5,1,1]

        // [[1],[2,3,4]]
        // [[1],4]

        // [9]
        // [[8,7,6]]

        // [[4,4],4,4]
        // [[4,4],4,4,4]

        // [7,7,7,7]
        // [7,7,7]

        // []
        // [3]

        // [[[]]]
        // [[]]

        // [1,[2,[3,[4,[5,6,7]]]],8,9]
        // [1,[2,[3,[4,[5,6,0]]]],8,9]
        // """.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);

        var pairs = puzzleInput.Split(new string[] { "\n\n" }, StringSplitOptions.RemoveEmptyEntries & StringSplitOptions.TrimEntries);



        Console.WriteLine($"Part One: {PartOne(pairs)}"); // 5684
    }
}
