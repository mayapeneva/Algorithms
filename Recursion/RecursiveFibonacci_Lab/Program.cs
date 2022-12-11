namespace RecursiveFibonacci_Lab
{
    using System;

    public class Program
    {
        private static int[] FibonacciNumbers;
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            FibonacciNumbers = new int[n];

            var number = GetFibonacci(n);
            Console.WriteLine(number);
        }

        private static int GetFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            var firstIndex = n - 1;
            var firstNumber = FibonacciNumbers[firstIndex];
            if (firstNumber == default)
            {
                firstNumber = GetFibonacci(firstIndex);
                FibonacciNumbers[firstIndex] = firstNumber;
            }

            var secondIndex = n - 2;
            var secondNumber = FibonacciNumbers[secondIndex];
            if (secondNumber == default)
            {
                secondNumber = GetFibonacci(secondIndex);
                FibonacciNumbers[secondIndex] = secondNumber;
            }

            return firstNumber + secondNumber;
        }
    }
}
