using System.IO.Abstractions;

namespace AdventOfCode.Day2;

public class Day2Executor : IExecutor
{
    private readonly FileParser _fileParser;
    
    public Day2Executor(IFileSystem fileSystem)
    {
        _fileParser = new FileParser(fileSystem);
    }
    
    public Task<int> ExecutePart1Async(string filePath)
    {
        return _fileParser.ParseFilePart1(filePath);
    }

    public Task<int> ExecutePart2Async(string filePath)
    {
        return _fileParser.ParseFilePart2(filePath);
    }
}