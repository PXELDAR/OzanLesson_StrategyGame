using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    int width = 1;
    int length = 1;
    int[,] gridArray; // Bu iki boyutlu bir array


    
    public Grid(int width, int length)
    {
        this.width = width;
        this.length = length;
        gridArray = new int[width,length];

        for (int Width = 0 ; Width < width; Width++)
        {
         for (int Length = 0; Length <length; Length++)
            {
                GameObject grid = GameObject.CreatePrimitive(PrimitiveType.Cube);
                grid.transform.position = new Vector3(Width, 1, Length);

            }
        }
    }

    
}
