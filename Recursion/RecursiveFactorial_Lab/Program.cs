using System;

public class Program
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var number = Factorial(n);
        Console.WriteLine(number);
    }

    private static int Factorial(int n)
    {
        if (n == 0)
        {
            return 1;
        }

        return n * Factorial(n - 1);
    }
}