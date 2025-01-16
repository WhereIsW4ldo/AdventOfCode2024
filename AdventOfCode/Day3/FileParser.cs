using System.IO.Abstractions;
using System.Text.RegularExpressions;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day3;

public class FileParser
{
    private readonly FileHelper _fileHelper;
    private readonly Regex _regexPart1 = new(@"mul\((\d+),(\d+)\)", RegexOptions.Compiled | RegexOptions.Singleline);
    private readonly Regex _regexDoDont = new(@"(do\(\)|don't\(\))", RegexOptions.Compiled);
    
    public FileParser(IFileSystem fileSystem)
    {
        _fileHelper = new FileHelper(fileSystem);
    }
    
    public async Task<int> ParseFilePart1(string fileName)
    {
        var sumOfLines = 0;
        
        await _fileHelper.ReadFilePerLineAsync(fileName, line =>
        {
            sumOfLines += ParseLinePart1(line);
        });

        return sumOfLines;
    }
    
    public async Task<int> ParseFilePart2(string fileName)
    {
        var fileContent = await _fileHelper.ReadFileAsync(fileName);

        return ParseLinePart2(fileContent);
    }

    private int ParseLinePart1(string line)
    {
        var result = 0;
        
        var matches = _regexPart1.Matches(line);

        foreach (Match match in matches)
        {
            var firstNumber = match.Groups[1].Captures[0].Value;
            var secondNumber = match.Groups[2].Captures[0].Value;
            result += int.Parse(firstNumber) * int.Parse(secondNumber);
        }
        
        return result;
    }
    
    private int ParseLinePart2(string line)
    {
        var result = 0;
        
        var lines = _regexDoDont.Split(line);

        var isAddition = true;
        
        foreach (var linePart in lines)
        {
            switch (linePart)
            {
                case "do()":
                    isAddition = true;
                    continue;
                case "don't()":
                    isAddition = false;
                    continue;
            }

            var value = ParseLinePart1(linePart);
            
            if (isAddition)
                result += value;
        }
        
        return result;
    }
}