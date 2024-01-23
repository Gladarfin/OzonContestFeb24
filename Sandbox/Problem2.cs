var evenNumberOfDays = new List<int>{4,6,9,11};
var n = int.Parse(Console.ReadLine());
for (var i = 0; i < n; i++)
{
    var curDate = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
    var isLeapYear = (curDate[2] % 4 == 0 && curDate[2] % 100 != 0) ||
                     curDate[2] % 400 == 0;

    if (curDate[1] == 2)
    {
        if (curDate[0] < 29 || (curDate[0] == 29 && isLeapYear))
        {
            Console.WriteLine("YES");
            continue;
        }
        Console.WriteLine("NO");
        continue;
    }

    if (!evenNumberOfDays.Contains(curDate[1]))
    {
        Console.WriteLine("YES");
        continue;
    }

    if (curDate[0] < 31)
    {
        Console.WriteLine("YES");
        continue;
    }

    Console.WriteLine("NO");
                
}