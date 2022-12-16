namespace PermutationsWithRepetition_Lab
{
    using System;
    using System.Linq;

    public class Program
    {
        private static string[] elements;

        public static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(e => e.Trim()).ToArray();
            Array.Sort(elements);

            Permutate(0, elements.Length - 1);
        }

        public static void Permutate(int startIndex, int endIndex)
        {
            Console.WriteLine(string.Join(" ", elements));

            for (int left = endIndex - 1; left >= startIndex; left--)
            {
                for (int right = left + 1; right <= endIndex; right++)
                {
                    if (elements[left] != elements[right])
                    {
                        Swap(left, right);
                        Permutate(left + 1, endIndex);
                    }
                }

                var firstElement = elements[left];
                for (int i = left; i <= endIndex - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }

                elements[endIndex] = firstElement;
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

//namespace PermutationsWithRepetition_Lab
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;

//    public class Program
//    {
//        private static string[] elements;

//        public static void Main(string[] args)
//        {
//            elements = Console.ReadLine().Split().Select(e => e.Trim()).ToArray();

//            Permutate(0);
//        }

//        public static void Permutate(int index)
//        {
//            if (index >= elements.Length)
//            {
//                Console.WriteLine(string.Join(" ", elements));
//                return;
//            }

//            HashSet<string> swapped = new HashSet<string>();
//            for (int i = index; i < elements.Length; i++)
//            {
//                if (!swapped.Contains(elements[i]))
//                {
//                    Swap(index, i);
//                    Permutate(index + 1);
//                    Swap(index, i);
//                    swapped.Add(elements[i]);
//                }
//            }
//        }

//        private static void Swap(int index1, int index2)
//        {
//            var temp = elements[index1];
//            elements[index1] = elements[index2];
//            elements[index2] = temp;
//        }
//    }
//}
