using System.Text;

var n = int.Parse(Console.ReadLine());

for (var i = 0; i < n; i++)
{
    var result = new StringBuilder();
    var currentString = new StringBuilder(Console.ReadLine());
    var isCorrect = true;
    while (currentString.Length > 0)
    {
        if (currentString.Length < 4)
        {
            isCorrect = false;
            break;
        }

        if (char.IsLetter(currentString[0]) && char.IsNumber(currentString[1]))
        {
            //2nd-pattern
            if (char.IsLetter(currentString[2]) && char.IsLetter(currentString[3]))
            {
                result.Append(currentString.ToString(0, 4) + ' ');
                currentString.Remove(0, 4);
                continue;
            }

            //1st pattern
            if (currentString.Length < 5)
            {
                isCorrect = false;
                break;
            }

            if (char.IsNumber(currentString[2])
                && char.IsLetter(currentString[3])
                && char.IsLetter(currentString[4]))
            {
                result.Append(currentString.ToString(0, 5) + ' ');
                currentString.Remove(0, 5);
                continue;
            }

            isCorrect = false;
            break;
        }

        isCorrect = false;
        break;
    }

    Console.WriteLine(isCorrect ? 
        result.ToString().Remove(result.Length - 1) : 
        ((char)45).ToString());

}