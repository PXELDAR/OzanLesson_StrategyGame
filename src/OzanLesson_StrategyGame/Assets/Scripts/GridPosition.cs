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
        //return $"Bu gridin x deðeri : {x} , z deðeri : {z}"; //string interpolasyonu
        return $"X:{x},Z:{z}";

    }
    public override int GetHashCode()
    {
        return HashCode.Combine(x, z);
    }
}
