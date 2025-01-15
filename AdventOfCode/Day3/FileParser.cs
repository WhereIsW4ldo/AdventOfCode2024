using System.IO.Abstractions;
using System.Text.RegularExpressions;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day3;

public class FileParser
{
    private readonly FileHelper _fileHelper;
    private readonly Regex _regex = new(@"mul\((\d+),(\d+)\)", RegexOptions.Compiled | RegexOptions.Singleline);

    public FileParser(IFileSystem fileSystem)
    {
        _fileHelper = new FileHelper(fileSystem);
    }
    
    public async Task<int> ParseFilePart1(string fileName)
    {
        var sumOfLines = 0;
        
        await _fileHelper.ReadFilePerLineAsync(fileName, line =>
        {
            sumOfLines += ParseLine(line);
        });

        return sumOfLines;
    }

    private int ParseLine(string line)
    {
        var result = 0;
        
        var matches = _regex.Matches(line);

        foreach (Match match in matches)
        {
            var firstNumber = match.Groups[1].Captures[0].Value;
            var secondNumber = match.Groups[2].Captures[0].Value;
            result += int.Parse(firstNumber) * int.Parse(secondNumber);
        }
        
        return result;
    }
}