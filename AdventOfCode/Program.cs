using System.IO.Abstractions;
using AdventOfCode.Day1;
using AdventOfCode.Day2;

var fileSystem = new FileSystem();

var day2Executor = new Day2Executor(fileSystem);
var result = await day2Executor.ExecutePart2Async(Path.Combine("Day2", "Input", "input.txt"));

Console.WriteLine(result);