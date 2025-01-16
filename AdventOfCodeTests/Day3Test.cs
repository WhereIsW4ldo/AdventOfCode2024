using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions.TestingHelpers;
using AdventOfCode;
using AdventOfCode.Day3;
using Xunit;

namespace AdventOfCodeTests;

[ExcludeFromCodeCoverage]
public class Day3Test
{
    private readonly IExecutor _executor;
    private readonly FileParser _fileParser;
    private readonly MockFileSystem _fileSystem = new();
    
    public Day3Test()
    {
        _executor = new Day3Executor(_fileSystem);
        _fileParser = new FileParser(_fileSystem);
    }
    
    [Fact]
    public async Task Day3Test_Part1_GivenExampleFile_ReturnsExampleSolution()
    {
        // Arrange
        _fileSystem.AddFile("input.txt", new MockFileData("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))"));
        
        // Act
        var result = await _executor.ExecutePart1Async("input.txt");
        
        // Assert
        Assert.Equal(161, result);
    }
    
    [Fact]
    public async Task Day3Test_Part2_GivenExampleFile_ReturnsExampleSolution()
    {
        // Arrange
        _fileSystem.AddFile("input.txt", new MockFileData("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"));
        
        // Act
        var result = await _executor.ExecutePart2Async("input.txt");
        
        // Assert
        Assert.Equal(48, result);
    }
}