using var input = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 4096);
using var output = new StreamWriter(Console.OpenStandardOutput());

//задача довольно похожа на задачу про проверку строки на корректность скобок ( https://leetcode.com/problems/valid-parentheses/ )
//где X - любая открывающаяся скобка, Z - любая закрывающаяся; Y - может быть открывающейся (для Z) и закрывающейся для X

var n = int.Parse(input.ReadLine());

for (var k = 0; k < n; k++)
{
    input.ReadLine();
    var stackX = new List<int>();
    var stackY = new List<int>();

    var isCorrect = true;
    var s1 = input.ReadLine();
    
    for (var i = 0; i < s1.Length; i++)
    {
        switch (s1[i])
        {
            case 'X':
                stackX.Add(i);
                continue;
            case 'Y':
                stackY.Add(i);
                continue;
        }

        if (s1[i] == 'Z')
        {
            if (stackX.Count == 0 && stackY.Count == 0)
            {
                isCorrect = false;
                break;
            }

            switch (stackY.Count)
            {
                case > 0 when stackX.Count > 0 && stackY[0] < stackX[0]:
                    stackY.RemoveAt(0);
                    continue;
                case > 0 when stackY.Count >= stackX.Count:
                    stackY.RemoveAt(0);
                    continue;
            }

            if (stackX.Count > 0)
            {
                stackX.RemoveAt(stackX.Count - 1);
                continue;
            }

            isCorrect = false;
            break;
        }
    }

    while(stackX.Count > 0 && isCorrect)
    {
        if (stackY.Count > 0 && stackX[^1] < stackY[^1])
        {
            stackX.RemoveAt(stackX.Count - 1);
            stackY.RemoveAt(stackY.Count - 1);
            continue;
        }
        isCorrect = false;
    }

    Console.WriteLine(isCorrect ? "Yes" : "No");
}
