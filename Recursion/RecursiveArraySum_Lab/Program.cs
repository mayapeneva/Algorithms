using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var sum = Sum(arr, 0);
        Console.WriteLine(sum);
    }

    private static int Sum(int[] arr, int index)
    {
        if (index == arr.Length)
        {
            return 0;
        }

        return arr[index] + Sum(arr, index + 1);
    }
}