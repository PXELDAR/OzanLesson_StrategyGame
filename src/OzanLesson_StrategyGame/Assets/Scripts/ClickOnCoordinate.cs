using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCoordinate : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 worldPosition;
    private Vector3 clickedWorldPosition;
    
    
    
    float width;
    float height;
    float size;

    private void OnEnable()
    {

        width = GridSystem.Instance.width;
        height = GridSystem.Instance.height;
        size = GridSystem.Instance.size;

        
    }


    void Update()
    {
        DebugWhenClickedOnCoordinate();
    }

    private void DebugWhenClickedOnCoordinate()
    {
        
        mousePosition = Input.mousePosition;
        clickedWorldPosition = new Vector3(width, height, mousePosition.z);
        mousePosition = clickedWorldPosition;
        worldPosition= Camera.main.ScreenToViewportPoint(mousePosition);    

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log($"You clicked on {worldPosition}");
        }
    }
}
