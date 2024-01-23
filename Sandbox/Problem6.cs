using System.Text;

var n = int.Parse(Console.ReadLine());

for (var i = 0; i < n; i++)
{
    var result = new List<StringBuilder> { new() };
    var cursorPos = 0;
    var currentString = 0;
    var curString = Console.ReadLine();

    foreach (var symbol in curString)
    {
        if (IsDigitOrLowerCase(symbol))
        {
            result[currentString].Insert(cursorPos, symbol);
            cursorPos++;
            continue;
        }

        if (symbol == 76)
        {
            cursorPos = cursorPos > 0 ? cursorPos - 1 : 0;
            continue;
        }

        if (symbol == 82)
        {
            cursorPos = cursorPos == result[currentString].Length ? cursorPos : cursorPos + 1;
            continue;
        }

        if (symbol == 85)
        {
            if (currentString > 0)
            {
                currentString -= 1;
                cursorPos = UpdateCursorPosition(cursorPos, result[currentString].Length);
            }

            continue;
        }

        if (symbol == 68)
        {
            if (currentString < result.Count - 1)
            {
                currentString += 1;
                cursorPos = UpdateCursorPosition(cursorPos, result[currentString].Length);
            }

            continue;
        }

        if (symbol == 66)
        {
            cursorPos = 0;
            continue;
        }

        if (symbol == 69)
        {
            cursorPos = result[currentString].Length;
            continue;
        }

        if (cursorPos == result[currentString].Length)
        {
            result.Insert(currentString + 1, new StringBuilder());
        }
        else
        {
            var subLength = result[currentString].Length - cursorPos;
            var tmpStr = result[currentString].ToString(cursorPos, subLength);
            result[currentString].Remove(cursorPos, subLength);
            result.Insert(currentString + 1, new StringBuilder(tmpStr));
        }

        cursorPos = 0;
        currentString++;
    }
    result.Add(new StringBuilder("-"));
    foreach (var str in result)
    {
        Console.WriteLine(str.ToString());
    }
    
    bool IsDigitOrLowerCase(char symbol)
    {
        return (symbol >= 48 && symbol <= 57) || (symbol >= 97 && symbol <= 122);
    }

    int UpdateCursorPosition(int curPos, int length)
    {
        return curPos > length ? length : curPos;
    }
}