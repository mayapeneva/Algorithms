namespace PermutationsWithoutRepetition_Lab
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] elements;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(e => e.Trim()).ToArray();

            Permutate(0);
        }

        public static void Permutate(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Permutate(index + 1);
            for (int i = index + 1; i < elements.Length; i++)
            {
                Swap(index, i);
                Permutate(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index1, int index2)
        {
            var temp = elements[index1];
            elements[index1] = elements[index2];
            elements[index2] = temp;
        }
    }
}

//namespace PermutationsWithoutRepetitions_Lab
//{
//    using System;
//    using System.Linq;

//    public class Program
//    {
//        private static string[] elements;
//        private static bool[] used;
//        private static string[] permutations;

//        public static void Main(string[] args)
//        {
//            elements = Console.ReadLine().Split().Select(e => e.Trim()).ToArray();
//            used = new bool[elements.Length];
//            permutations = new string[elements.Length];

//            Permutate(0);
//        }

//        public static void Permutate(int index)
//        {
//            if (index >= elements.Length)
//            {
//                Console.WriteLine(string.Join(" ", permutations));
//                return;
//            }

//            for (int i = 0; i < elements.Length; i++)
//            {
//                if (!used[i])
//                {
//                    used[i] = true;
//                    permutations[index] = elements[i];
//                    Permutate(index + 1);

//                    used[i] = false;
//                }
//            }
//        }
//    }
//}
