// See https://aka.ms/new-console-template for more information
namespace AdventOfCode;

using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        string filename;
        string dayNumber = args[0];
        string sample = args[1];

        if (sample == "true")
        {
            filename = $"/data/day{dayNumber}.sample.txt";
        }
        else
        {
            filename = $"/data/day{dayNumber}.txt";
        }

        var cwd = System.IO.Directory.GetCurrentDirectory();
        var dataFile = Path.Combine(cwd) + filename;

        Console.WriteLine($"Using data file: {dataFile}");
        var sr = new StreamReader(dataFile);
        var contents = sr.ReadToEnd();

        var day = new Day1(contents);

        Console.WriteLine($@"Part 1: {day.part1()}");
        Console.WriteLine($@"Part 2: {day.part2()}");
    }
}