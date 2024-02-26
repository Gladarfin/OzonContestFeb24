using var input = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 5000000);
using var output = new StreamWriter(Console.OpenStandardOutput());

var s = int.Parse(input.ReadLine());
for (var l = 0; l < s; l++)
{
    var n = int.Parse(input.ReadLine());
    var prices = input.ReadLine().Split(' ').Select(int.Parse).ToList();
    var currentSeason = Enumerable.Range(0, n).ToList();
    
    var result = new int[n];
    
    for (var i = 1; i <= n; i++)
    {
        var nextSeason = new List<int>();
        var seasonCount = 0;
    
        foreach (var val in currentSeason)
        {
            var curValInBounds = InBounds(val, i);
            if (curValInBounds && prices[val - i] < prices[val - i + 1] && prices[val + i - 1] > prices[val + i])
            {
                if (seasonCount == 0)
                {
                    seasonCount = 1;
                }
                else
                {
                    if (nextSeason.Count > 0 && nextSeason[^1] + 2 * i == val)
                    {
                        seasonCount++;
                    }
                    else
                    {
                        seasonCount = 1;
                    }
                }
                nextSeason.Add(val);
                result[i - 1] = Math.Max(result[i - 1], seasonCount);
            }
        }
    
        currentSeason = nextSeason;
    }

    output.WriteLine(string.Join(" ", result));
    continue;
    
    bool InBounds(int val, int i)
    {
        return val - i >= 0 && val + i < n;
    }
    
}