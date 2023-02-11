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

    public override string ToString()
    {
        string unitString = string.Empty;

        foreach(Unit unit in unitList)
        {
            unitString += unit + "\n";
        }

        return gridPosition.ToString() + "\n" + unitString;
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
