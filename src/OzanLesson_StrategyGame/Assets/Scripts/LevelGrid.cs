using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField][Range(2, 20)] public int width;
    [SerializeField][Range(2, 20)] public int height;
    [SerializeField][Range(1f, 5f)] public float size;
    [SerializeField] private Transform gridPrefab;
    public GridSystem levelGridSystem { get; private set; }

    public static LevelGrid instance;


    private void Awake()
    {
        levelGridSystem = new GridSystem(width, height, size);
        levelGridSystem.CreateGridDebug(gridPrefab);

        instance = this;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / size), Mathf.RoundToInt(worldPosition.z / size));

    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = levelGridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = levelGridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitgMoveGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);
        AddUnitAtGridPosition(toGridPosition, unit);
    }

    public bool IsGridPositionValid(Vector3 gridPosition) => levelGridSystem.IsGridPositionValid(gridPosition); //verilen Vektör oyun sýnýrlarý içinde mi?
    //{
    //   return levelGridSystem.IsGridPositionValid(gridPosition); lambda expresion ile ayný anlama geliyor
    //}

    public bool HasAnyUnitOnSelectedGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = levelGridSystem.GetGridObject(gridPosition);

        return gridObject.HasAnyUnit();
    }

}
