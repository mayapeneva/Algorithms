namespace NChooseKCount_Lab
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var k = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculateCombinations(n, k));
        }

        private static decimal CalculateCombinations(int n, int k)
        {
            if (k > n)
            {
                return 0;
            }

            if (k == 0 ||  k == n)
            {
                return 1;
            }

            return CalculateCombinations(n - 1, k - 1) + CalculateCombinations(n - 1, k);
        }
    }
}
