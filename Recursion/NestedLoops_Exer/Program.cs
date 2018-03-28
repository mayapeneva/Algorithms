using System;

public class Program
{
    private static int Count;

    public static void Main()
    {
        Count = int.Parse(Console.ReadLine());
        var arr = new int[Count];
        PrintCombinations(arr, 0);
    }

    private static void PrintCombinations(int[] arr, int index)
    {
        if (index == Count)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = 1; i <= Count; i++)
        {
            arr[index] = i;
            PrintCombinations(arr, index + 1);
        }
    }
}