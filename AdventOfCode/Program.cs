// See https://aka.ms/new-console-template for more information

using System.IO.Abstractions;
using AdventOfCode.Day1;

var fileSystem = new FileSystem();
var fileParser = new FileParser(fileSystem);

var fileData = await fileParser.ParseFile(Path.Combine("Day1", "Input", "input.txt"));

Console.WriteLine(DataService.GetResultPart2(fileData));