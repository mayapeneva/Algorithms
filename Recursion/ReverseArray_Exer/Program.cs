using System;
using System.Linq;

public class Program
{
    private static string[] Arr;

    public static void Main()
    {
        Arr = Console.ReadLine().Split().ToArray();
        Reverse(Arr.Length - 1);
        Console.WriteLine(string.Join(" ", Arr));
    }

    public static void Reverse(int index)
    {
        if (index == 0)
        {
            return;
        }

        SwapFirstElement(index);
        Reverse(index - 1);
    }

    private static void SwapFirstElement(int index)
    {
        var firstChar = Arr[0];
        for (int i = 1; i <= index; i++)
        {
            Arr[i - 1] = Arr[i];
        }
        Arr[index] = firstChar;
    }
}