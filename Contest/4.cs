using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

var n = int.Parse(input.ReadLine());

for (var i = 0; i < n; i++)
{
    var nm = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
    var warehouse = new char[nm[0]][];

    for (var j = 0; j < nm[0]; j++)
    {
        warehouse[j] = input.ReadLine().ToCharArray();
    }

    var isFirst = true;

    for (var j = 0; j < nm[0]; j++)
    {
        for (var k = 0; k < nm[1]; k++)
        {
            if (warehouse[j][k] == 'A' || warehouse[j][k] == 'B')
            {
                var curChar = char.ToLower(warehouse[j][k]);

                if (isFirst)
                {
                    isFirst = false;
                    if (j == 0 && k == 0)
                        continue;
                    var curJ = j - 1;
                    var curK = k - 1;

                    if (j - 1 > 0 && warehouse[j - 1][k] == '#')
                    {
                        warehouse[j][curK--] = curChar;
                    }

                    while (curJ >= 0)
                    {
                        warehouse[curJ--][curK] = curChar;
                    }

                    while (curK >= 0)
                    {
                        warehouse[0][curK--] = curChar;
                    }

                    continue;
                }

                if (j == nm[0] - 1 && k == nm[1] - 1)
                    break;
                var curN = j + 1;
                var curM = k + 1;

                if (curN < nm[0] && warehouse[curN][k] == '#')
                {
                    warehouse[j][curM++] = curChar;
                }
                
                while (curN < nm[0])
                {
                    warehouse[curN++][curM] = curChar;
                }

                while (curM < nm[1])
                {
                    warehouse[nm[0] - 1][curM++] = curChar;
                }

                break;
            }
        }
    }

    for (var j = 0; j < nm[0]; j++)
    {
        output.WriteLine(warehouse[j]);
    }
}