
using JetBrains.Annotations;
using UnityEngine;

public class GridSystem
{

    public int width;
    public int height;
    public float size;
    private GridObject[,] gridObjectsArray;


    private GridSystem() { }
    private static GridSystem instance = null;
    public static GridSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GridSystem();
            }
            return instance;
        }
    }



    public GridSystem(int width, int height, float size) //constructor
    {
        this.width = width; // x axis
        this.height = height; // y axis
        this.size = size; // z axis

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
        Debug.Log(gridObject.x + "," + gridObject.z);
        Vector3 pos = new Vector3 (gridObject.x, 0, gridObject.z) * size;
        Debug.Log(pos);
        return pos;

    }

    public GridObject GetGridObject(Vector3 gridPosition)
    {
        GridObject grid = gridObjectsArray[(int)gridPosition.x, (int)gridPosition.z]; //variable casting

        if(grid != null)
        {
            return grid;
        }

        else
        {
            Debug.Log("Get Grid Object null deðer döndürdü");
            return null;
            
        }
    }
}
