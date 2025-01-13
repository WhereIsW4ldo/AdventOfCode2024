using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions.TestingHelpers;
using AdventOfCode;
using AdventOfCode.Day1;
using AdventOfCode.Day1.DTO;
using Xunit;

namespace AdventOfCodeTests;

[ExcludeFromCodeCoverage]
public class Day1Test
{
    private readonly MockFileSystem _fileSystem = new();
    private readonly FileParser _fileParser;
    private readonly Day1DataService _day1DataService = new();
    private readonly IExecutor _executor;

    public Day1Test()
    {
        _executor = new Day1Executor(_fileSystem);
        _fileParser = new FileParser(_fileSystem);
    }

    [Fact]
    public async Task FileParser_ParseFile_WhenFileContainsData_ShouldReturnFileData()
    {
        // Arrange
        var mockFileData = new MockFileData("3   4\n4   3\n2   5\n1   3\n3   9\n3   3");
        _fileSystem.AddFile("input.txt", mockFileData);
        
        // Act
        var result = await _fileParser.ParseFile("input.txt");

        // Assert
        Assert.NotEmpty(result.LeftData);
        Assert.NotEmpty(result.RightData);
        Assert.Equal(6, result.LeftData.Length);
        Assert.Equal(6, result.RightData.Length);
        Assert.Equal(1, result.LeftData[0]);
        Assert.Equal(3, result.RightData[0]);
    }
    
    [Fact]
    public void DataService_GetResultPart1_WhenFileContainsData_ShouldReturnResult()
    {
        // Arrange
        var fileData = new FileData
        {
            LeftData =
            [
                1, 2, 3, 3, 3, 4
            ],
            RightData =
            [
                3, 3, 3, 4, 5, 9
            ]
        };
        
        // Act
        var result = _day1DataService.GetResultPart1(fileData);

        // Assert
        Assert.Equal(11, result);
    }
    
    [Fact]
    public void DataService_GetResultPart2_WhenFileContainsData_ShouldReturnResult()
    {
        // Arrange
        var fileData = new FileData
        {
            LeftData =
            [
                1, 2, 3, 3, 3, 4
            ],
            RightData =
            [
                3, 3, 3, 4, 5, 9
            ]
        };
        
        // Act
        var result = _day1DataService.GetResultPart2(fileData);

        // Assert
        Assert.Equal(31, result);
    }
    
    [Fact]
    public async Task Day1Executor_Part1_ExecuteAsync_ShouldReturnResult()
    {
        // Arrange
        var mockFileData = new MockFileData("3   4\n4   3\n2   5\n1   3\n3   9\n3   3");
        _fileSystem.AddFile("input.txt", mockFileData);
        
        // Act
        var result = await _executor.ExecutePart1Async("input.txt");
        
        // Assert
        Assert.Equal(11, result);
    }
    
    [Fact]
    public async Task Day1Executor_Part2_ExecuteAsync_ShouldReturnResult()
    {
        // Arrange
        var mockFileData = new MockFileData("3   4\n4   3\n2   5\n1   3\n3   9\n3   3");
        _fileSystem.AddFile("input.txt", mockFileData);
        
        // Act
        var result = await _executor.ExecutePart2Async("input.txt");
        
        // Assert
        Assert.Equal(31, result);
    }
}