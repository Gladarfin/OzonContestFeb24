var n = int.Parse(Console.ReadLine());

for (var i = 0; i < n; i++)
{
    var correctShipsNumber = new[] { 4, 3, 2, 1 };
    var ships = Console.ReadLine()
        .Split(' ')
        .Select(int.Parse)
        .OrderBy(x => x)
        .ToArray();
    var isCorrect = true;

    foreach (var ship in ships)
    {
        correctShipsNumber[ship - 1]--;
        if (correctShipsNumber[ship - 1] >= 0)
            continue;

        isCorrect = false;
        break;
    }

    Console.WriteLine(isCorrect ? "YES" : "NO");
}