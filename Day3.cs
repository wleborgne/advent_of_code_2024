using System.Text.RegularExpressions;

namespace Advent;

public class Day3
{
  private readonly string rawInput;
  private readonly string[] lines;
  private int total;
  public Day3(string rawInput)
  {
    this.rawInput = rawInput;
    lines = rawInput.Split("\n");
    Console.WriteLine($"Read {lines.Length} lines.");
  }

  public int Part1()
  {
    total = 0;
    var regex = @"mul\(\d{1,3},\d{1,3}\)";

    foreach (var line in lines)
    {
      var matches = Regex.Matches(line, regex).ToArray();
      foreach (var match in matches)
      {
        var nums = match.ToString().Substring(4, match.Length - 5).Split(',');

        total += Int32.Parse(nums[0]) * Int32.Parse(nums[1]);
      }
    }
    return total;
  }

  public int Part2()
  {
    total = 0;
    var regex = @"(?:mul\(\d{1,3},\d{1,3}\)|do\(\)|don't\(\))";
    bool skip = false;
  
    foreach (var line in lines)
    {
      var matches = Regex.Matches(line, regex).ToArray();
      
      foreach (var match in matches)
      {
        if (match.ToString() == @"don't()")
        {
          skip = true;
        }
        else if (match.ToString() == @"do()")
        {
          skip = false;
          continue;
        }
        
        if (skip) continue;

        var nums = match.ToString().Substring(4, match.Length - 5).Split(',');

        total += Int32.Parse(nums[0]) * Int32.Parse(nums[1]);
      }
    }
    return total;  }
}