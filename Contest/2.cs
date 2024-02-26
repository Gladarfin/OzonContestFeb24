using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());


var n = int.Parse(input.ReadLine());

for (var i = 0; i < n; i++)
{
    var np = input.ReadLine().Split(' ').Select(double.Parse).ToArray();
    var result = 0.0;

    for (var j = 0; j < np[0]; j++)
    {
        var cur = double.Parse(input.ReadLine()) * np[1] / 100;
        result += cur - Math.Truncate(cur);
    }
    
    output.WriteLine($"{Math.Round(result, 2):0.00}");
}