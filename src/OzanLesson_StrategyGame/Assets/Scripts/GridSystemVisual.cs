using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisual : MonoBehaviour
{
    [SerializeField] Transform gridSystemVisualPrefab;
    GridSystemVisualSingle[,] gridSystemVisualSingleArray;
    void Start()
    {
        gridSystemVisualSingleArray = new GridSystemVisualSingle [LevelGrid.instance.width, LevelGrid.instance.height];

        for (int x = 0; x < LevelGrid.instance.width; x++)
        {
            for (int z = 0; z < LevelGrid.instance.height; z++)
            {
                GridPosition gridPosition = new GridPosition(x, z);
                Transform gridSystemVisualSingle = Instantiate(gridSystemVisualPrefab, LevelGrid.instance.GetWorldPosition(gridPosition), Quaternion.identity);
                gridSystemVisualSingleArray[x, z] = gridSystemVisualSingle.GetComponent<GridSystemVisualSingle>();
            }
        }
    }

   
    void Update()
    {
        UpdateGridVisual();
    }

    private void UpdateGridVisual()
    {
        HideAllGridPosition();
        Unit selectedUnit = UnitActionSystem.instance.GetSelectedUnit();
        

        if(selectedUnit != null)
        {
            ShowGridPositionList(selectedUnit.GetMoveAction().GetValidActionGridPositionList());
        }
    }

    private void ShowGridPositionList(List<GridPosition> gridPositionList)
    {
        foreach (GridPosition gridPosition in gridPositionList)
        {
            gridSystemVisualSingleArray[gridPosition.x, gridPosition.z].Show();
        }
    }

    private void HideAllGridPosition()
    {
        for (int x = 0; x < LevelGrid.instance.width; x++)
        {
            for (int z = 0; z < LevelGrid.instance.height; z++)
            {
                gridSystemVisualSingleArray[x,z].Hide();
            }
        }

    }
}
