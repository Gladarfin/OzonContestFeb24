using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());


var n = int.Parse(input.ReadLine());

for (var i = 0; i < n; i++)
{
    var actions = input.ReadLine();
    
    if (actions[0] != 'M' || actions.Length < 2 || actions[^1] != 'D')
    {
        output.WriteLine("NO");
        continue;
    }

    var prevCommand = 'S';
    var isCorrect = true;
    var isStarted = false;
    
    foreach (var c in actions)
    {
        if (c == prevCommand)
        {
            isCorrect = false;
            break;
        }
        
        switch (c)
        {
            case 'M':
                if (!isStarted)
                {
                    isStarted = true;
                    prevCommand = 'M';
                }
                else
                {
                    isCorrect = false;
                }
                break;
            
            case 'R':
                if (!isStarted || prevCommand != 'M')
                {
                    isCorrect = false;
                }
                else
                {
                    prevCommand = 'R';
                }
                break;
            
            case 'C':
                if (isStarted && prevCommand is 'M' or 'R')
                {
                    prevCommand = 'C';
                    isStarted = false;
                }
                else
                {
                    isCorrect = false;
                }
                break;
            
            case 'D':
                if (!isStarted || prevCommand != 'M')
                    isCorrect = false;
                else
                {
                    isCorrect = true;
                    isStarted = false;
                    prevCommand = 'D';
                }
                break;
        }

        if (!isCorrect)
        {
            break;
        }
    }
    
    output.WriteLine(!isCorrect || isStarted ? "NO" : "YES");
}