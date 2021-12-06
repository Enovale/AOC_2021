using System;
using System.IO;

static class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        Console.WriteLine(PartOne(lines));
        Console.WriteLine(PartTwo(lines));
    }

    public static int PartOne(string[] lines)
    {
        var depth = 0;
        var x = 0;
        foreach (var line in lines)
        {
            var amount = int.Parse(line.Substring(line.Length - 1, 1));
            if (line.StartsWith("down"))
                depth += amount;
            else if (line.StartsWith("up"))
                depth -= amount;
            else if (line.StartsWith("forward"))
                x += amount;
        }
        
        return depth * x;
    }

    public static int PartTwo(string[] lines)
    {
        var depth = 0;
        var x = 0;
        var aim = 0;
        foreach (var line in lines)
        {
            var amount = int.Parse(line.Substring(line.Length - 1, 1));
            if (line.StartsWith("down"))
                aim += amount;
            else if (line.StartsWith("up"))
                aim -= amount;
            else if (line.StartsWith("forward"))
            {
                x += amount;
                depth += aim * amount;
            }
        }
        
        return depth * x;
    }
}