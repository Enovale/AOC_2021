using System;
using System.Collections;
using System.IO;

static class Program
{
    public static void Main(string[] args)
    {
        var lines = File.ReadAllLines("input.txt");
        Console.WriteLine(PartOne(lines));
    }

    public static int PartOne(string[] lines)
    {
        var commons = new int[12];
        foreach (var line in lines)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == '1')
                    commons[i]++;
                else
                    commons[i]--;
            }
        }

        var gamma = 0;
        var epsilon = 0;
        for (var i = 0; i < 12; i++)
        {
            if (commons[i] > 0)
                gamma |= Math.Max(1, (int)Math.Pow(2, 11 - i));
            else
                epsilon |= Math.Max(1, (int)Math.Pow(2, 11 - i));
        }

        return gamma * epsilon;
    }
}