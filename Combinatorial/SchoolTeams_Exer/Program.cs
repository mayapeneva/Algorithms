namespace SchoolTeams_Exer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private const int MaxGirlsCount = 3;
        private const int MaxBoysCount = 2;

        private static List<string> GirlsCombinations;
        private static List<string> BoysCombinations;

        public static void Main(string[] args)
        {
            var girlsInput = Console.ReadLine();
            var boysInput = Console.ReadLine();

            var girlsNames = girlsInput.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToArray();
            var boysNames = boysInput.Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToArray();

            GirlsCombinations = new List<string>();
            BoysCombinations = new List<string>();

            if (girlsNames.Length > MaxGirlsCount)
            {
                GetCombinations(girlsNames, new string[MaxGirlsCount], MaxGirlsCount, 0, 0);
            }
            else
            {
                GirlsCombinations.Add(girlsInput);
            }

            if (boysNames.Length > MaxBoysCount)
            {
                GetCombinations(boysNames, new string[MaxBoysCount], MaxBoysCount, 0, 0);
            }
            else
            {
                BoysCombinations.Add(boysInput);
            }

            PrintCombinations();
        }

        private static void GetCombinations(string[] names, string[] combination, int maxCount, int border, int index)
        {
            if (index >= maxCount)
            {
                var combinationString = string.Join(", ", combination);
                if (maxCount == MaxGirlsCount)
                {
                    GirlsCombinations.Add(combinationString);
                }
                else
                {
                    BoysCombinations.Add(combinationString);
                }

                return;
            }

            for (int i = border; i < names.Length; i++)
            {
                combination[index] = names[i];
                GetCombinations(names, combination, maxCount, i + 1, index + 1);
            }
        }

        private static void PrintCombinations()
        {
            foreach (var girlsCombination in GirlsCombinations)
            {
                foreach (var boysCombination in BoysCombinations)
                {
                    Console.WriteLine($"{girlsCombination}, {boysCombination}");
                }
            }
        }
    }
}

