using System;
using System.Collections.Generic;

public class Program
{
    private const int ChessboardSize = 8;
    private static readonly bool[,] Chessboard = new bool[ChessboardSize, ChessboardSize];
    private static readonly HashSet<int> AttackedColumns = new HashSet<int>();
    private static readonly HashSet<int> AttackedLeftDiagonals = new HashSet<int>();
    private static readonly HashSet<int> AttackedRightDiagonals = new HashSet<int>();

    public static void Main()
    {
        FindPlaceForTheQueen(0);
    }

    private static void FindPlaceForTheQueen(int row)
    {
        if (row == ChessboardSize)
        {
            PrintChessboard();
        }
        else
        {
            for (int col = 0; col < ChessboardSize; col++)
            {
                if (!CheckIfCellIsUnderAttack(row, col))
                {
                    MarkAttackedCells(row, col);
                    FindPlaceForTheQueen(row + 1);
                    UnmarkAttackedCells(row, col);
                }
            }
        }
    }

    private static void UnmarkAttackedCells(int row, int col)
    {
        AttackedColumns.Remove(col);
        AttackedLeftDiagonals.Remove(col - row);
        AttackedRightDiagonals.Remove(row + col);
        Chessboard[row, col] = false;
    }

    private static void MarkAttackedCells(int row, int col)
    {
        AttackedColumns.Add(col);
        AttackedLeftDiagonals.Add(col - row);
        AttackedRightDiagonals.Add(row + col);
        Chessboard[row, col] = true;
    }

    private static bool CheckIfCellIsUnderAttack(int row, int col)
    {
        return AttackedColumns.Contains(col)
               || AttackedLeftDiagonals.Contains(col - row)
               || AttackedRightDiagonals.Contains(row + col);
    }

    private static void PrintChessboard()
    {
        for (int i = 0; i < ChessboardSize; i++)
        {
            for (int j = 0; j < ChessboardSize; j++)
            {
                Console.Write(Chessboard[i, j] ? "* " : "- ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}