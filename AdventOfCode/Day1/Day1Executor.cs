using System.IO.Abstractions;

namespace AdventOfCode.Day1;

public class Day1Executor : IExecutor
{
    private readonly FileParser _fileParser;
    private readonly Day1DataService _day1DataService;

    public Day1Executor(IFileSystem fileSystem)
    {
        _day1DataService = new Day1DataService();
        _fileParser = new FileParser(fileSystem);
    }

    public async Task<int> ExecutePart1Async(string filePath)
    {
        var fileData = await _fileParser.ParseFile(filePath);

        return _day1DataService.GetResultPart1(fileData);
    }

    public async Task<int> ExecutePart2Async(string filePath)
    {
        var fileData = await _fileParser.ParseFile(filePath);

        return _day1DataService.GetResultPart2(fileData);    
    }
}