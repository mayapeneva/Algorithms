using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int Steps;
    private static Stack<int> Source;
    private static readonly Stack<int> Spare = new Stack<int>();
    private static readonly Stack<int> Destination = new Stack<int>();

    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        Source = new Stack<int>(Enumerable.Range(1, n).Reverse());

        PrintSteps();
        SwapDisks(Source, Destination, Spare, n);
    }

    private static void SwapDisks(Stack<int> source, Stack<int> destination, Stack<int> spare, int count)
    {
        if (count == 1)
        {
            Swap(source, destination);
        }
        else
        {
            SwapDisks(source, spare, destination, count - 1);
            Swap(source, destination);
            SwapDisks(spare, destination, source, count - 1);
        }
    }

    private static void Swap(Stack<int> source, Stack<int> destination)
    {
        Steps++;
        destination.Push(source.Pop());
        Console.WriteLine($"Step #{Steps}: Moved disk");
        PrintSteps();
    }

    private static void PrintSteps()
    {
        Console.WriteLine($"Source: {string.Join(", ", Source.Reverse())}");
        Console.WriteLine($"Destination: {string.Join(", ", Destination.Reverse())}");
        Console.WriteLine($"Spare: {string.Join(", ", Spare.Reverse())}");
        Console.WriteLine();
    }
}