namespace Advent;

public class Day2
{
  private readonly string rawInput;
  private readonly string[] reports;
  public Day2(string rawInput)
  {
    this.rawInput = rawInput;
    reports = rawInput.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
    Console.WriteLine($"Read {reports.Length} lines.");
  }

  public int Part1()
  {
    var safeCount = 0;

    foreach (var report in reports)
    {
      var sequence = report
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

      int[] diffs = new int[sequence.Length - 1];
      for (int i = 0; i < sequence.Length - 1; i++)
      {
        diffs[i] = sequence[i] - sequence[i + 1];
      }

      if (Array.TrueForAll(diffs, (x) => x < 0) || Array.TrueForAll(diffs, (x) => x > 0))
      {
        if (Array.TrueForAll(diffs, (x) => Math.Abs(x) >= 1 && Math.Abs(x) <= 3))
        {
          safeCount++;
        }
      }
    }
  
    return safeCount;
  }

  public int Part2()
  {
    return 2;
  }
}