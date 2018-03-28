using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int Rows;
    private static int Cols;
    private static char[][] Labyrinth;
    private static readonly List<char> Path = new List<char>();

    public static void Main()
    {
        Rows = int.Parse(Console.ReadLine());
        Cols = int.Parse(Console.ReadLine());

        Labyrinth = new char[Rows][];
        for (int i = 0; i < Rows; i++)
        {
            Labyrinth[i] = Console.ReadLine().ToCharArray();
        }

        FindPathsInLabyrinth(0, 0, 'S');
    }

    private static void FindPathsInLabyrinth(int row, int col, char direction)
    {
        if (!IsInBounds(row, col))
        {
            return;
        }

        Path.Add(direction);

        if (IsExit(row, col))
        {
            Console.WriteLine(string.Join("", Path.Skip(1)));
        }
        else if (IsFree(row, col))
        {
            Labyrinth[row][col] = '+';
            FindPathsInLabyrinth(row, col + 1, 'R');
            FindPathsInLabyrinth(row + 1, col, 'D');
            FindPathsInLabyrinth(row, col - 1, 'L');
            FindPathsInLabyrinth(row - 1, col, 'U');
            Labyrinth[row][col] = '-';
        }

        Path.RemoveAt(Path.Count - 1);
    }

    private static bool IsFree(int row, int col)
    {
        return Labyrinth[row][col] == '-';
    }

    private static bool IsExit(int row, int col)
    {
        return Labyrinth[row][col] == 'e';
    }

    private static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < Rows && col >= 0 && col < Cols;
    }
}