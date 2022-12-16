namespace VariationsWithoutRepetitions_Lab
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] elements;
        private static int variationsCount;
        private static string[] variations;
        private static bool[] used;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(e => e.Trim()).ToArray();
            variationsCount = int.Parse(Console.ReadLine());

            variations = new string[variationsCount];
            used = new bool[elements.Length];

            GetVariations(0);
        }

        private static void GetVariations(int index)
        {
            if (index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    GetVariations(index + 1);

                    used[i] = false;
                }
            }
        }
    }
}
