// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;

var cwd = System.IO.Directory.GetCurrentDirectory();
// var dataFile = Path.Combine(cwd) + "/data/day1.sample.txt";
var dataFile = Path.Combine(cwd) + "/data/day1.txt";
Console.WriteLine($"Data file: {dataFile}");
var sr = new StreamReader(dataFile);

var contents = sr.ReadToEnd();
var lines = contents.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
Console.WriteLine(lines.Length);

int[] left = new int[lines.Length];
int[] right = new int[lines.Length];

for(int i = 0; i < lines.Length; i++)
{
    var foo = lines[i].Split(new string[] { "   " }, StringSplitOptions.RemoveEmptyEntries);
    left[i] = Int32.Parse(foo[0]);
    right[i] = Int32.Parse(foo[1]);
}

Array.Sort(left);
Array.Sort(right);

var total = 0;
for(int i = 0; i < lines.Length; i++)
{
    total += Math.Abs(left[i] - right[i]);
}

Console.WriteLine($@"Part 1: {total}");

total = 0;
foreach(int leftVal in left) {
    var results = Array.FindAll(right, (x) => x == leftVal);
    total += leftVal * results.Count();
}

Console.WriteLine($@"Part 2: {total}");