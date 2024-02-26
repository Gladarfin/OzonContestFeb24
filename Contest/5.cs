using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

using var input = new StreamReader(Console.OpenStandardInput(), Console.InputEncoding, false, 4096);
using var output = new StreamWriter(Console.OpenStandardOutput());

var n = int.Parse(input.ReadLine());
for (var l = 0; l < n; l++)
{
    var json = new StringBuilder();
    var k = int.Parse(input.ReadLine());
    for (var i = 0; i < k; i++)
    {
        json.Append(input.ReadLine());
    }

    var jsonOptions = new JsonSerializerOptions
    {
        MaxDepth = 2048
    };
    
    var file = JsonSerializer.Deserialize<DirClass>(json.ToString(), jsonOptions);
    var result = GetCorruptedFiles(file, false);

    output.WriteLine(result);
    var c = 0;
}

int GetCorruptedFiles(DirClass directory, bool isCorruptedDirectory)
{
    var res = 0;
    if (isCorruptedDirectory)
    {
        if (directory.Files is not null) 
            res += directory.Files.Count();
        
        if (directory.Folders is not null)
        {
            res += directory.Folders.Sum(dir => GetCorruptedFiles(dir, true));
        }
    }
    else
    {
        var containsCorrupted = directory.Files?.FirstOrDefault(x => x.EndsWith(".hack"));
        
        if (containsCorrupted is not null)
        {
                res += directory.Files.Count();
            if (directory.Folders is not null)
                res += directory.Folders.Sum(dir => GetCorruptedFiles(dir, true));
        }
        else if (directory.Folders is not null)
        {
            res += directory.Folders.Sum(folder => GetCorruptedFiles(folder, false));
        }
    }

    return res;
}

public class DirClass
{
    [JsonPropertyName("dir")]
    public string RootDirectory { get; set; }
    [JsonPropertyName("files")]
    public IEnumerable<string>? Files { get; set; }
    [JsonPropertyName("folders")]
    public IEnumerable<DirClass>? Folders { get; set; }
}