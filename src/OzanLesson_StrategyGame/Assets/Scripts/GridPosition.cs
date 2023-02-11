using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPosition
{
    public int x;
    public int z;

    public GridPosition(int x, int z) 
    {
        this.x = x;
        this.z = z;
    }

    public override bool Equals(object obj)
    {
        return obj is GridPosition position && x == position.x && z== position.z;
    }

    public override string ToString()
    {
        //return $"Bu gridin x de�eri : {x} , z de�eri : {z}"; //string interpolasyonu
        return $"X:{x},Z:{z}";

    }
    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }

    public static GridPosition operator + (GridPosition a, GridPosition b)
    //operator keywordu struct'�n i�inde yeni bir operat�r tan�mlamak i�in kullan�l�r
    {
        return new GridPosition(a.x + b.x, a.z+b.z);
    }

    public static GridPosition operator - (GridPosition a, GridPosition b)
    {
        return new GridPosition(a.x - b.x, a.z - b.z);
    }

    public static bool operator == (GridPosition a, GridPosition b)
    {
        return a.x ==b.x && a.z ==b.z;
    }

    public static bool operator != (GridPosition a, GridPosition b)
    {
        return !(a == b);
    }


}