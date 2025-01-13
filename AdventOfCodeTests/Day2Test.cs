using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions.TestingHelpers;
using AdventOfCode;
using AdventOfCode.Day2;
using Xunit;

namespace AdventOfCodeTests;

[ExcludeFromCodeCoverage]
public class Day2Test
{
    private readonly MockFileSystem _fileSystem = new();
    private readonly FileParser _fileParser;
    private readonly IExecutor _executor;
    public Day2Test()
    {
        _fileParser = new FileParser(_fileSystem);
        _executor = new Day2Executor(_fileSystem);
    }

    [Fact]
    public async Task Day2Test_Part1_GivenExampleFile_ReturnsExampleSolution()
    {
        // Arrange
        var fileInfo = new MockFileData("7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9");
        _fileSystem.AddFile("input.txt", fileInfo);
        
        // Act
        var result = await _executor.ExecutePart1Async("input.txt");
        
        // Assert
        Assert.Equal(2, result);
    }
    
    [Theory]
    [InlineData("7 6 4 2 1", true)]
    [InlineData("1 2 7 8 9", false)]
    [InlineData("9 7 6 2 1", false)]
    [InlineData("1 3 2 4 5", false)]
    [InlineData("8 6 4 4 1", false)]
    [InlineData("1 3 6 7 9", true)]
    public void Day2Test_Part1_GivenLineExample_ReturnsExpected(string line, bool expected)
    {
        // Arrange
        // Act
        var result = FileParser.IsLineSafe(line, false);
        
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public async Task Day2Test_Part2_GivenExampleFile_ReturnsExampleSolution()
    {
        // Arrange
        var fileInfo = new MockFileData("7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9");
        _fileSystem.AddFile("input.txt", fileInfo);
        
        // Act
        var result = await _executor.ExecutePart2Async("input.txt");
        
        // Assert
        Assert.Equal(4, result);
    }
    
    [Theory]
    [InlineData("7 6 4 2 1", true)]
    [InlineData("1 2 7 8 9", false)]
    [InlineData("9 7 6 2 1", false)]
    [InlineData("1 3 2 4 5", true)]
    [InlineData("8 6 4 4 1", true)]
    [InlineData("1 3 6 7 9", true)]
    [InlineData("2 1 2 3 4", true)]
    public void Day2Test_Part2_GivenLineExample_ReturnsExpected(string line, bool expected)
    {
        // Arrange
        // Act
        var result = FileParser.IsLineSafe(line, true);
        
        // Assert
        Assert.Equal(expected, result);
    }
}