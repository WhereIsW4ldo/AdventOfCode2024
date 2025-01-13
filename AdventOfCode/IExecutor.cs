namespace AdventOfCode;

public interface IExecutor
{
    Task<int> ExecutePart1Async(string filePath);
    Task<int> ExecutePart2Async(string filePath);
}