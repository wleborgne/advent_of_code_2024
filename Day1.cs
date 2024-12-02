namespace AdventOfCode;

public class Day1
{
  private string rawInput;
  private int[] left;
  private int[] right;
  private int total;

  public Day1(string rawInput)
  {
    this.rawInput = rawInput;
    var lines = rawInput.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine($"Read {lines.Length} lines.");

    left = new int[lines.Length];
    right = new int[lines.Length];

    for(int i = 0; i < lines.Length; i++)
    {
      var foo = lines[i].Split(new string[] { "   " }, StringSplitOptions.RemoveEmptyEntries);
      left[i] = Int32.Parse(foo[0]);
      right[i] = Int32.Parse(foo[1]);
    }
  }

  public int part1()
  {
    Array.Sort(left);
    Array.Sort(right);

    total = 0;
    for(int i = 0; i < left.Length; i++)
    {
      total += Math.Abs(left[i] - right[i]);
    }

    return total;
  }

  public int part2()
  {
    total = 0;
    foreach(int leftVal in left)
    {
      var results = Array.FindAll(right, (x) => x == leftVal);
      total += leftVal * results.Count();
    }

    return total;
  }
}