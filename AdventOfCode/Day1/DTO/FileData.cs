namespace AdventOfCode.Day1.DTO;

public record FileData
{
    public int[] LeftData { get; init; } = [];
    public int[] RightData { get; init; } = [];
};