using var input = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 4096);
using var output = new StreamWriter(Console.OpenStandardOutput());

var employees = new List<string>();
var newEmployees = new List<string>();
var result = new List<int>();
var m = int.Parse(input.ReadLine());
for (var i = 0; i < m; i++)
{
    employees.Add(input.ReadLine());
}

var l = int.Parse(input.ReadLine());
for (var i = 0; i < l; i++)
{
    newEmployees.Add(input.ReadLine());
}

foreach (var e in newEmployees)
{
    var isSame = false;

    foreach (var log in employees.Where(log => e.Length == log.Length))
    {
        if (e == log)
        {
            result.Add(1);
            break;
        }

        isSame = CheckLogin(e, log);

        if (isSame)
            break;
    }

    result.Add(isSame ? 1 : 0);
}

foreach (var v in result)
{
    output.WriteLine(v);
}

bool CheckLogin(string curLogin, string existingLogin)
{
    var diffCount = 0;
    var firstDiffIndex = -1;

    for (var i = 0; i < curLogin.Length; i++)
    {
        if (curLogin[i] != existingLogin[i])
        {
            diffCount++;

            switch (diffCount)
            {
                case > 2:
                    return false;
                case 1:
                    firstDiffIndex = i;
                    break;
            }
        }
    }

    return diffCount == 2 && curLogin[firstDiffIndex] == existingLogin[firstDiffIndex + 1] &&
           curLogin[firstDiffIndex + 1] == existingLogin[firstDiffIndex];
}