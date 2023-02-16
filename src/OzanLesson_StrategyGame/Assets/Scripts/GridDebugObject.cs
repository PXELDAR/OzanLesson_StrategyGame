using TMPro;
using UnityEngine;

public class GridDebugObject : MonoBehaviour
{
    [SerializeField] private TextMeshPro textMeshPro;
    private GridObject _gridObject;

    public void SetGridObject(GridObject gridObject)
    {
        this._gridObject = gridObject;
        textMeshPro.text = gridObject.ToString();
    }
    
    private void Update()
    {
        textMeshPro.text = _gridObject.ToString();
    }
}