using System;

public class Area : IComparable<Area>
{
    public Area(int row, int col)
    {
        this.Row = row;
        this.Col = col;
    }

    public int Row { get; }
    public int Col { get; }
    public int Size { get; set; }

    public int CompareTo(Area other)
    {
        var compare = other.Size.CompareTo(this.Size);
        if (compare == 0)
        {
            compare = this.Row.CompareTo(other.Row);
        }

        if (compare == 0)
        {
            compare = this.Col.CompareTo(this.Col);
        }

        return compare;
    }
}