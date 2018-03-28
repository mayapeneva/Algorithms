using System;

public class Program
{
    private static int NumbersCount;
    private static int ElementsCount;

    public static void Main()
    {
        NumbersCount = int.Parse(Console.ReadLine());
        ElementsCount = int.Parse(Console.ReadLine());
        var arr = new int[ElementsCount];
        PrintCombinations(arr, 1, 0);
    }

    private static void PrintCombinations(int[] arr, int border, int index)
    {
        if (index == ElementsCount)
        {
            Console.WriteLine(string.Join(" ", arr));
            return;
        }

        for (int i = border; i <= NumbersCount; i++)
        {
            arr[index] = i;
            PrintCombinations(arr, i + 1, index + 1);
        }
    }
}