using System.Diagnostics.CodeAnalysis;
using System.IO.Abstractions.TestingHelpers;
using AdventOfCode;
using Xunit;

namespace AdventOfCodeTests;

[ExcludeFromCodeCoverage]
public class Day2Test
{
    private readonly MockFileSystem _fileSystem = new();
    private readonly IExecutor _executor;
    public Day2Test(IExecutor executor)
    {
        _executor = executor;
    }

    [Fact]
    public async Task Day2Test_GivenExampleFile_ReturnsExampleSolution()
    {
        // Arrange
        var fileInfo = new MockFileData("7 6 4 2 1\n1 2 7 8 9\n9 7 6 2 1\n1 3 2 4 5\n8 6 4 4 1\n1 3 6 7 9");
        _fileSystem.AddFile("input.txt", fileInfo);
        
        // Act
        // var result = await _fileParser.ParseFile("input.txt");
        
        // Assert
    }
}