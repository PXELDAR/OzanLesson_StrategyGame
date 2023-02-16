using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] private Transform gridSystemVisualPrefab;
    private GridSystemVisualSingle[,] gridSystemVisualSingleArray;

    private void Start()
    {
        gridSystemVisualSingleArray = new GridSystemVisualSingle [LevelGrid.Instance.width, LevelGrid.Instance.height];

        for (int x = 0; x < LevelGrid.Instance.width; x++)
        for (int z = 0; z < LevelGrid.Instance.height; z++)
        {
            GridPosition gridPosition = new GridPosition(x, z);
            Transform gridSystemVisualSingle = Instantiate(gridSystemVisualPrefab,
                LevelGrid.Instance.GetWorldPosition(gridPosition), Quaternion.identity);
            gridSystemVisualSingleArray[x, z] = gridSystemVisualSingle.GetComponent<GridSystemVisualSingle>();
        }
    }


    private void Update()
    {
        UpdateGridVisual();
    }

    private void UpdateGridVisual()
    {
        HideAllGridPosition();
        Unit selectedUnit = UnitActionSystem.Instance.GetSelectedUnit();

        if (selectedUnit != null) ShowGridPositionList(selectedUnit.GetMoveAction().GetValidActionGridPositionList());
    }

    private void ShowGridPositionList(List<GridPosition> gridPositionList)
    {
        foreach (GridPosition gridPosition in gridPositionList)
            gridSystemVisualSingleArray[gridPosition.x, gridPosition.z].Show();
    }

    private void HideAllGridPosition()
    {
        for (var x = 0; x < LevelGrid.Instance.width; x++)
        for (var z = 0; z < LevelGrid.Instance.height; z++)
            gridSystemVisualSingleArray[x, z].Hide();
    }
}