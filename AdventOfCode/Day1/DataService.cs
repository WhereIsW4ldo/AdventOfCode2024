using AdventOfCode.Day1.DTO;

namespace AdventOfCode.Day1;

public static class DataService
{
    public static int GetResultPart1(FileData fileData)
    {
        return fileData.LeftData.Select((left, right) => Math.Abs(left - fileData.RightData[right])).Sum();
    }

    public static int GetResultPart2(FileData fileData)
    {
        var result = 0;

        foreach (var leftData in fileData.LeftData)
        {
            var data = leftData;
            var subRes = fileData
                .RightData
                .Count(x => x.Equals(data));

            result += subRes * leftData;
        }

        return result;
    }
}