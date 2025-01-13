using System.IO.Abstractions;
using AdventOfCode.Day1;

var fileSystem = new FileSystem();

var day1Executor = new Day1Executor(fileSystem);
var result = await day1Executor.ExecutePart1Async(Path.Combine("Day1", "Input", "input.txt"));

Console.WriteLine(result);