using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var k = int.Parse(Console.ReadLine());
        var combination = new int[k];
        GeneratingCombinations(arr, combination, 0, 0);
    }

    private static void GeneratingCombinations(int[] arr, int[] combination, int border, int index)
    {
        if (index >= combination.Length)
        {
            Console.WriteLine(string.Join(" ", combination));
            return;
        }

        for (int i = border; i < arr.Length; i++)
        {
            combination[index] = arr[i];
            GeneratingCombinations(arr, combination, i + 1, index + 1);
        }
    }
}