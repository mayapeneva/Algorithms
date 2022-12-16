namespace CombinationsWithRepetition_Lab
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] elements;
        private static int combinationsCount;
        private static string[] combinations;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(e => e.Trim()).ToArray();
            combinationsCount = int.Parse(Console.ReadLine());

            combinations = new string[combinationsCount];

            GetCombinations(0, 0);
        }

        private static void GetCombinations(int border, int index)
        {
            if (index >= combinationsCount)
            {
                Console.WriteLine(string.Join(" ", combinations));
                return;
            }

            for (int i = border; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                GetCombinations(i, index + 1);
            }
        }
    }
}
