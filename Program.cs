// See https://aka.ms/new-console-template for more information
namespace Advent;

using System.Reflection;
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

        string dayClassName = "Advent.Day" + dayNumber;

        // Get the Type dynamically
        Type? type = Type.GetType(dayClassName);

        if (type != null)
        {
            // Create an instance of the class
            object? day = Activator.CreateInstance(type, [contents]);

            // Convert to a dynamic instance so we can easily call methods on it
            // Maybe refactor to a common interface later
            dynamic dynamicDay = day;
            Console.WriteLine($@"Part 1: {dynamicDay.Part1()}");
            Console.WriteLine($@"Part 2: {dynamicDay.Part2()}");
        }
    }
}