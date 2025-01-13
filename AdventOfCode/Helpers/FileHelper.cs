using System.IO.Abstractions;
using System.Text;

namespace AdventOfCode.Helpers;

public class FileHelper
{
    private readonly IFileSystem _fileSystem;

    public FileHelper(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }
    
    public async Task<string> ReadFile(string fileName)
    {
        var contentBuilder = new StringBuilder();

        await ReadFilePerLine(fileName, s =>
        {
            contentBuilder.Append(s);
        });

        return contentBuilder.ToString();
    }

    public async Task ReadFilePerLine(string fileName, Action<string> action)
    {
        await using var fileStream = _fileSystem.File.OpenRead(_fileSystem.Path.GetFullPath(fileName));
        using var streamReader = new StreamReader(fileStream);
        
        while (await streamReader.ReadLineAsync() is { } line)
        {
            action(line);
        }
    }
}