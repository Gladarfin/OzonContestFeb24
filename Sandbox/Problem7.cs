var n = int.Parse(Console.ReadLine());
for (var i = 0; i < n; i++)
{
    var pagesToPrint = int.Parse(Console.ReadLine());
    var printedPages = Console.ReadLine();
    var allPages = Enumerable.Range(1, pagesToPrint).ToList();

    var sortedPrintedPages = SortValues(printedPages);
    
    
    foreach (var curPage in sortedPrintedPages.TakeWhile(curPage => allPages.Count != 0))
    {
        if (!curPage.Contains('-'))
        {
            var page = FindClosestToGivenNumber(allPages, int.Parse(curPage));
            if (page != int.Parse(curPage))
                continue;
            var pageIndex = allPages.IndexOf(page);
            if (pageIndex >= 0)
                allPages.RemoveAt(pageIndex);
            continue;
        }

        var left = FindClosestToGivenNumber(allPages, int.Parse(curPage.Split('-')[0]));
        var right = FindClosestToGivenNumber(allPages, int.Parse(curPage.Split('-')[1]), false);

        if (left < 0 || right < 0 || left > right)
            continue;
        if (left == right)
        {
            var index = allPages.IndexOf(right);
            if (index >= 0)
                allPages.RemoveAt(index);
            continue;
        }

        var startIndex = allPages.IndexOf(left);
        var endIndex = allPages.IndexOf(right);
        var count = endIndex - startIndex + 1;

        if (count == 0)
            continue;
        allPages.RemoveRange(startIndex, count);
    }
        
    Console.WriteLine(GetRangesFromList(allPages));
    
    List<string> SortValues(string stringOfPages)
    {
        var tmp = stringOfPages.Split(',').Distinct();

        var result = tmp.OrderBy(s => int.Parse(s.Split('-')[0]))
            .ThenBy(s => s).ToList();
        return result;
    }

    int FindClosestToGivenNumber(List<int> curList, int valueToSearch, bool isLeft = true)
    {
        var orderedList = curList.OrderBy(x => Math.Abs(x - valueToSearch));
        var result = isLeft ? 
            orderedList.FirstOrDefault(x => x >= valueToSearch) : 
            orderedList.FirstOrDefault(x => x <= valueToSearch);

        if (result == default(int))
            return -1;

        return result;
    }

    string GetRangesFromList(IReadOnlyList<int> list)
    {
        var result = new List<string>();
        var i = 0;

        while (i < list.Count)
        {
            var start = list[i];
            var end = start;

            while (i + 1 < list.Count && list[i + 1] - list[i] == 1)
            {
                end = list[i + 1];
                i++;
            }
            var formattedOutput = FormatRangesAsString(Tuple.Create(start, end));
            result.Add(formattedOutput);
            i++;
        }
        return string.Join(",", result);
    }

    string FormatRangesAsString(Tuple<int, int> values)
    {
        return values.Item1 == values.Item2 ? 
            values.Item1.ToString() : 
            $"{values.Item1}-{values.Item2}";
    }
}