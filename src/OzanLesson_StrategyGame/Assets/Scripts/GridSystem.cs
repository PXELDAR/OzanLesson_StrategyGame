
using JetBrains.Annotations;
using UnityEngine;

public class GridSystem
{

    private int width;
    private int height;
    private float size;
    private GridObject[,] gridObjectsArray;

    public GridSystem(int width, int height, float size) //constructor
    {
        this.width = width;
        this.height = height;
        this.size = size;

        gridObjectsArray = new GridObject[width,height];

        for (int x=0; x<width; x++) 
        {
            for(int z=0; z<height; z++) 
            {
                gridObjectsArray[x, z] = new GridObject(x,z);
            }
        
        }
        
    }

    public void CreateGridDebug(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridObject gridObject = new GridObject(x, z);
                Transform debugTransform = GameObject.Instantiate(debugPrefab, GetWorldPosition(gridObject), Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(gridObject);

            }

        }
    }

    public Vector3 GetWorldPosition(GridObject gridObject)

    {
        return new Vector3(gridObject.x, 0, gridObject.z) * size;

    }

}
