using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] TextMeshPro gridDebug;
    GridObject gridObject;
    
    public void SetGridObject(GridObject gridObject)
    {
        this.gridObject= gridObject;
        gridDebug.text = gridObject.ToString();
    }
}
