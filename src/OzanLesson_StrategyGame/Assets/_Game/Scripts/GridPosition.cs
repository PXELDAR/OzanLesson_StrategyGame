﻿using System;

[Serializable]
public class GridPosition
{
    public readonly int x;
    public readonly int z;

    public GridPosition(int x, int z)
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position && x == position.x && z == position.z;
    }

    public override string ToString()
    {
        //return $"Bu gridin x degeri : {x} , z degeri : {z}"; //string interpolasyonu
        return $"X:{x},Z:{z}";
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public static GridPosition operator +(GridPosition a, GridPosition b)
        //operator keywordu struct'ýn içinde yeni bir operatör tanýmlamak için kullanýlýr
    {
        return new GridPosition(a.x + b.x, a.z + b.z);
    }

    public static GridPosition operator -(GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x - b.x, a.z - b.z);
    }

    public static bool operator ==(GridPosition a, GridPosition b)
    {
        return a.x == b.x && a.z == b.z;
    }

    public static bool operator !=(GridPosition a, GridPosition b)
    {
        return !(a == b);
    }
}