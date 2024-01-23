var n = int.Parse(Console.ReadLine());

for (var i = 0; i < n; i++)
{
    Console.ReadLine();
    var sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
    var result = new List<int>();

    for (var j = 0; j < sequence.Count; j++)
    {
        result.Add(sequence[j]);
        if (j + 1 == sequence.Count)
        {
            result.Add(0);
            break;
        }

        var subSeqLength = GetSubSequenceLength(j, 1);
        var k = -1;

        if (subSeqLength == 0)
        {
            k = 1;
            subSeqLength = GetSubSequenceLength(j, -1);
        }
        result.Add(k * subSeqLength);
        j += subSeqLength;
    }
    
    int GetSubSequenceLength(int index, int diffValue)
    {
        var cur = sequence[index] - sequence[index + 1];
        var count = 0;
        while (cur == diffValue)
        {
            count++;
            index++;
            if (index + 1 == sequence.Count)
                break;
            cur = sequence[index] - sequence[index + 1];
        }
        return count;
    }
    Console.WriteLine(result.Count);
    Console.WriteLine(string.Join(' ', result));
}