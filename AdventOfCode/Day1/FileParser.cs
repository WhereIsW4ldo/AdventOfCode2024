using System.IO.Abstractions;
using AdventOfCode.Day1.DTO;
using AdventOfCode.Helpers;
using FileSystem = System.IO.Abstractions.FileSystem;

namespace AdventOfCode.Day1;

public class FileParser
{
    private readonly FileHelper _fileHelper;

    public FileParser(IFileSystem fileSystem)
    {
        _fileHelper = new FileHelper(fileSystem);
    }
    
    public async Task<FileData> ParseFile(string fileName)
    {
        var leftNumbers = new List<int>();
        var rightNumbers = new List<int>();
        
        await _fileHelper.ReadFilePerLine(fileName, line =>
        {
            var numbers = line
                .Split(' ')
                .Where(x => !string.IsNullOrEmpty(x))
                .ToArray();
                
            leftNumbers.Add(int.Parse(numbers[0]));
            rightNumbers.Add(int.Parse(numbers[1]));
        });
        
        return new FileData
        {
            LeftData = leftNumbers.Order().ToArray(),
            RightData = rightNumbers.Order().ToArray()
        };
    }
}