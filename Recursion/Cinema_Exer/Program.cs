namespace Cinema_Exer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static List<string> FriendNamesToDistribute;
        private static int AllFriendsCount;
        private static int FriendsToDistributeCount;
        private static string[] RequiredDistributions;

        public static void Main(string[] args)
        {
            FriendNamesToDistribute = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => n.Trim()).ToList();
            AllFriendsCount = FriendNamesToDistribute.Count;
            RequiredDistributions = new string[AllFriendsCount];

            var input = string.Empty;
            while ((input = Console.ReadLine()) != "generate")
            {
                var requirement = input.Split('-', StringSplitOptions.RemoveEmptyEntries).Select(r => r.Trim()).ToArray();

                var place = int.Parse(requirement[1]);
                var friendName = requirement[0];
                RequiredDistributions[place - 1] = friendName;
                FriendNamesToDistribute.Remove(friendName);
            }

            FriendsToDistributeCount = FriendNamesToDistribute.Count;

            PrintDistributions(0);
        }

        private static void PrintDistributions(int index)
        {
            if (index >= FriendsToDistributeCount)
            {
                var variationIndex = 0;
                var distributions = new string[AllFriendsCount];
                for (int j = 0; j < AllFriendsCount; j++)
                {
                    distributions[j] = RequiredDistributions[j] == default 
                        ? FriendNamesToDistribute[variationIndex++] 
                        : RequiredDistributions[j];
                }

                Console.WriteLine(string.Join(" ", distributions));
                return;
            }

            PrintDistributions(index + 1);
            for (int i = index + 1; i < FriendsToDistributeCount; i++)
            {
                Swap(index, i);
                PrintDistributions(index + 1);
                Swap(index, i);
            }
        }

        private static void Swap(int index1, int index2)
        {
            var temp = FriendNamesToDistribute[index1];
            FriendNamesToDistribute[index1] = FriendNamesToDistribute[index2];
            FriendNamesToDistribute[index2] = temp;
        }
    }
}
