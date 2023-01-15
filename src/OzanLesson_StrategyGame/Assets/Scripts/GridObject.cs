using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    public int x = 1;
    public int z = 1;
    


    
    public GridObject(int x, int z)
    {
        this.x = x;
        this.z = z;
        

    
    }

    override public string ToString()
    {
        //return $"Bu gridin x deðeri : {x} , z deðeri : {z}"; //string interpolasyonu
        return $"X:{x},Z:{z}";

    }

    
}
