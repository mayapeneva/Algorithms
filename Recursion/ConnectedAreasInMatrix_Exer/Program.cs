using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static int Rows;
    private static int Cols;
    private static char[][] Matrix;
    private static readonly HashSet<Area> Areas = new HashSet<Area>();

    public static void Main()
    {
        Rows = int.Parse(Console.ReadLine());
        Cols = int.Parse(Console.ReadLine());
        ReadMatrix();

        for (int r = 0; r < Rows; r++)
        {
            for (int c = 0; c < Cols; c++)
            {
                TraverseMatrix(r, c);
            }
        }

        PrintResult();
    }

    private static void TraverseMatrix(int row, int col)
    {
        if (!IsInBounds(row, col) || IsWall(row, col) || IsVisited(row, col))
        {
            return;
        }

        var area = new Area(row, col);
        CreateArea(area, row, col);
        Areas.Add(area);
    }

    private static void CreateArea(Area area, int row, int col)
    {
        if (!IsInBounds(row, col) || IsWall(row, col) || IsVisited(row, col))
        {
            return;
        }

        Matrix[row][col] = '+';
        area.Size++;

        CreateArea(area, row, col + 1);
        CreateArea(area, row + 1, col);
        CreateArea(area, row, col - 1);
        CreateArea(area, row - 1, col);
    }

    private static bool IsWall(int row, int col)
    {
        return Matrix[row][col] == '*';
    }

    private static bool IsVisited(int row, int col)
    {
        return Matrix[row][col] == '+';
    }

    private static bool IsInBounds(int row, int col)
    {
        return row >= 0 && row < Rows && col >= 0 && col < Cols;
    }

    private static void ReadMatrix()
    {
        Matrix = new char[Rows][];
        for (int i = 0; i < Rows; i++)
        {
            Matrix[i] = Console.ReadLine().ToCharArray();
        }
    }

    private static void PrintResult()
    {
        Console.WriteLine($"Total areas found: {Areas.Count}");
        var count = 1;
        foreach (var area in Areas.OrderBy(a => a))
        {
            Console.WriteLine($"Area #{count++} at ({area.Row}, {area.Col}), size: {area.Size}");
        }
    }
}