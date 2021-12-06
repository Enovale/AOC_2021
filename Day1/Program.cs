using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

static class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        var part1 = GetPartOneOutput(lines);
        Console.WriteLine(part1);
        var part2 = GetPartTwoOutput(lines);
        Console.WriteLine(part2);
    }

    public static int GetPartOneOutput(string[] lines)
    {
        var amount = 0;
        var prev = "";
        foreach (var measurement in lines)
        {
            if (String.IsNullOrEmpty(prev))
            {
                prev = measurement;
                continue;
            }

            if (int.Parse(measurement) > int.Parse(prev))
            {
                amount++;
            }

            prev = measurement;
        }

        return amount;
    }

    public static int GetPartTwoOutput(string[] lines)
    {
        var indices = new int[3];
        var pointer = 0;
        var prev = 0;
        var amount = 0;
        for (var i = 0; i < lines.Length; i++)
        {
            if (indices[2] == 0)
            {
                indices[pointer] = i;;
                pointer = (pointer + 1) % 3;
                continue;
            }

            var next = int.Parse(lines[indices[0]]) + int.Parse(lines[indices[1]]) + int.Parse(lines[indices[2]]);
            if (next > prev)
            {
                amount++;
            }

            prev = next;
            indices[pointer] = i;
            pointer = (pointer + 1) % 3;
        }

        return amount;
    }
}