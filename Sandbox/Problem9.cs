var c = int.Parse(Console.ReadLine());

for (var l = 0; l < c; l++)
{
    var (n, m) = Console.ReadLine().Split(' ') switch
    {
        var a => (int.Parse(a[0]), int.Parse(a[1]))
    };
    var result = new List<int>();
    var field = new char[n][];
	
    for (var i = 0; i < n; i++)
    {
        field[i] = Console.ReadLine().ToCharArray();
    }
	//запускаем рекурсивный обход поля
    CountTables(0, 0, n, m, 0);

    Console.WriteLine(string.Join(' ', result.OrderBy(x => x).ToList()));
    
    //рекурсивный обход таблиц
    void CountTables(int startColumn,int startRow, int endColumn, int endRow,  int curLevel)
    {
        
        //ищем таблицы внутри
        for (var i = startColumn; i < endColumn; i++)
        {
            for (var j = startRow; j < endRow; j++)
            {
                //нашли таблицу
                //1. Добавляем текущий уровень в результат
                //2. Ищем правый нижний край текущей таблицы
                //3. Ищем таблицы внутри
                if (field[i][j] == '*')
                {
                    result.Add(curLevel);
                    var stRow = j;
                    var stCol = i;
                    var downRightCorner = GetDownRightCornerOfTable(i, j);
                    MarkBorderAsVisited(i, j,  downRightCorner.endColumn, downRightCorner.endRow);
                    CountTables(i + 1, j + 1,  downRightCorner.endColumn, downRightCorner.endRow, curLevel + 1);
                    j = downRightCorner.endRow + 1;
                    continue;
                }

                field[i][j] = 'v';
            }
        }
    }

    (int endColumn, int endRow) GetDownRightCornerOfTable(int startColumn, int startRow)
    {
        var endColumn = startColumn;
        var endRow = startRow;

        for (var i = startColumn; i < n; i++)
        {
            if (field[i][startRow] == '*' && i + 1 == n)
            {
                endColumn = i;
                break;
            }

            if (field[i][startRow] == '.')
            {
                endColumn = i - 1;
                break;
            }
        }

        for (var j = startRow; j < m; j++)
        {
            if (field[startColumn][j] == '*' && j + 1 == m)
            {
                endRow = j;
                break;
            }

            if (field[startColumn][j] == '.')
            {
                endRow = j - 1;
                break;
            }
        }

        return new ValueTuple<int, int>(endColumn, endRow);
    }

    void MarkBorderAsVisited(int startColumn, int startRow, int endColumn, int endRow)
    {
        //помечаем нижнюю и верхнюю границы
        for (var i = startColumn; i <= endColumn; i++)
        {
            field[i][endRow] = 'v';
            field[i][startRow] = 'v';
        }
        
        //помечаем правую границу
        for (var j = startRow; j <= endRow; j++)
        {
            field[startColumn][j] = 'v';
            field[endColumn][j] = 'v';
            
        }
    }
}