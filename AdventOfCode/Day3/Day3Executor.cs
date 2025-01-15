using System.IO.Abstractions;

namespace AdventOfCode.Day3;

public class Day3Executor : IExecutor
{
    private readonly FileParser _fileParser;

    public Day3Executor(IFileSystem fileSystem)
    {
        _fileParser = new FileParser(fileSystem);
    }

    public async Task<int> ExecutePart1Async(string filePath)
    {
        return await _fileParser.ParseFilePart1(filePath);
    }

    public async Task<int> ExecutePart2Async(string filePath)
    {
        throw new NotImplementedException();
    }
}