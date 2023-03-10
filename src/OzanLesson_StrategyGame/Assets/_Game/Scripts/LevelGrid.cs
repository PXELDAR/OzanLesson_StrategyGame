using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField] [Range(2, 20)] public int width;
    [SerializeField] [Range(2, 20)] public int height;
    [SerializeField] [Range(1f, 5f)] public float size;
    [SerializeField] private Transform gridPrefab;
    private GridSystem _levelGridSystem;
    public static LevelGrid Instance;

    private void Awake()
    {
        _levelGridSystem = new GridSystem(width, height, size);
        _levelGridSystem.CreateGridDebug(gridPrefab);
        Instance = this;
    }

    public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition(Mathf.RoundToInt(worldPosition.x / size), Mathf.RoundToInt(worldPosition.z / size));
    }

    public void AddUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = _levelGridSystem.GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public void RemoveUnitAtGridPosition(GridPosition gridPosition, Unit unit)
    {
        GridObject gridObject = _levelGridSystem.GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitgMoveGridPosition(Unit unit, GridPosition fromGridPosition, GridPosition toGridPosition)
    {
        RemoveUnitAtGridPosition(fromGridPosition, unit);
        AddUnitAtGridPosition(toGridPosition, unit);
    }

    public bool IsGridPositionValid(GridPosition gridPosition)
    {
        return _levelGridSystem.IsGridPositionValid(gridPosition);
        //verilen Vektör oyun sinirlari icinde mi?
    }
    //{
    //   return levelGridSystem.IsGridPositionValid(gridPosition); lambda expresion ile ayni anlama geliyor
    //}

    public bool HasAnyUnitOnSelectedGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = _levelGridSystem.GetGridObject(gridPosition);
        return gridObject.HasAnyUnit();
    }

    public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return _levelGridSystem.GetWorldPosition(gridPosition);
    }
}