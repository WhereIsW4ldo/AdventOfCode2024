using System.IO.Abstractions;
using AdventOfCode.Helpers;

namespace AdventOfCode.Day2;

public class FileParser
{
    private readonly FileHelper _fileHelper;

    public FileParser(IFileSystem fileSystem)
    {
        _fileHelper = new FileHelper(fileSystem);
    }

    public async Task<int> ParseFilePart1(string fileName)
    {
        var correctLines = 0;
        
        await _fileHelper.ReadFilePerLineAsync(fileName, line =>
        {
            if (IsLineSafe(line, false))
            {
                correctLines++;
            }
        });

        return correctLines;
    }
    
    public async Task<int> ParseFilePart2(string fileName)
    {
        var correctLines = 0;
        
        await _fileHelper.ReadFilePerLineAsync(fileName, line =>
        {
            if (IsLineSafe(line, true))
            {
                correctLines++;
            }
        });

        return correctLines;
    }

    internal static bool IsLineSafe(string line, bool isPart2)
    {
        var numbers = line
            .Split(' ')
            .Where(x => !string.IsNullOrEmpty(x))
            .ToArray();

        bool? numbersGoingUp = null;
        
        for (var i = 0; i < numbers.Length - 1; i++)
        {
            var currentNumber = int.Parse(numbers[i]);
            var nextNumber = int.Parse(numbers[i + 1]);

            var numbersDifference = currentNumber - nextNumber;
            
            var theseNumbersGoingUp = numbersDifference < 0;

            if (Math.Abs(numbersDifference) is < 1 or > 3
                || (numbersGoingUp != null && theseNumbersGoingUp != numbersGoingUp))
            {
                if (!isPart2)
                    return false;

                // part 2
                
                for (var j = i - 1; j <= i + 1; j++)
                {
                    var numbersWithoutCurrentNumber = numbers.Take(j).Concat(numbers.Skip(j + 1));
                    var lineWithoutCurrentNumber = string.Join(" ", numbersWithoutCurrentNumber);

                    if (IsLineSafe(lineWithoutCurrentNumber, false)) return true;
                }

                return false;
            }
            
            numbersGoingUp = theseNumbersGoingUp;
        }

        return true;
    }
}