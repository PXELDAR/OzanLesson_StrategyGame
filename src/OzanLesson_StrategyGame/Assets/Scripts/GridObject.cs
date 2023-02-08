using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GridObject 
{
    private GridPosition gridPosition;
    private List<Unit> unitList;
    


    
    public GridObject(GridPosition gridPosition)
    {
       this.gridPosition = gridPosition;
       unitList= new List<Unit>();
    }

   

    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit) 
    {
        unitList.Remove(unit);
    }

    public List<Unit> GetUnitList()
    {
        return unitList;
    }
    public bool HasAnyUnit()
    {
        return unitList.Count > 0;
    }

    
}
