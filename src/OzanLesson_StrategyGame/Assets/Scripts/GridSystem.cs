using UnityEngine;

public class GridSystem
{
    public readonly int width;
    public readonly int height;
    public readonly float size;
    private GridObject[,] gridObjectsArray;

    public GridSystem(int width, int height, float size) //constructor
    {
        this.width = width; // x axis
        this.height = height; // y axis
        this.size = size; // z axis
        gridObjectsArray = new GridObject[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                gridObjectsArray[x, z] = new GridObject(gridPosition);
            }
        }
    }

    public void CreateGridDebug(Transform debugPrefab)
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform debugTransform =
                    GameObject.Instantiate(debugPrefab, GetWorldPosition(gridPosition), Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
            }
        }
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        Vector3 pos = new Vector3(gridPosition.x, 0, gridPosition.z) * size;
        return pos;
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectsArray[gridPosition.x, gridPosition.z]; //variable casting
    }

    public bool IsGridPositionValid(GridPosition gridPosition)
    {
        if (gridPosition.x >= 0 && gridPosition.z >= 0 && gridPosition.x < width && gridPosition.z < height)
        {
            return true;
        }

        return false;

        // return gridPosition.x >= 0 && gridPosition.z >= 0 && gridPosition.x < width && gridPosition.z < height; // ikisi ayni sekilde calisir
    }
}