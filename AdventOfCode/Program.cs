using System.IO.Abstractions;
using AdventOfCode.Day1;
using AdventOfCode.Day2;
using AdventOfCode.Day3;

var fileSystem = new FileSystem();

var day3Executor = new Day3Executor(fileSystem);
var result = await day3Executor.ExecutePart2Async(Path.Combine("Day3", "Input", "input.txt"));

Console.WriteLine(result);