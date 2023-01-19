using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnCoordinate : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector3 worldPosition;
    private Vector3 clickedWorldPosition;
    GridSystem levelGridSystem;
    
    void Start()
    {
        // Transform gridPosition = GetComponent<LevelGrid>().gridPrefab;
        // clickedWorldPosition = gridPosition.position;





    }

    
    void Update()
    {
        DebugWhenClickedOnCoordinate();
    }

    private void DebugWhenClickedOnCoordinate()
    {
        mousePosition = Input.mousePosition;
        clickedWorldPosition = new Vector3(levelGridSystem.width, levelGridSystem.height, mousePosition.z);
        mousePosition = clickedWorldPosition;
        worldPosition= Camera.main.ScreenToViewportPoint(mousePosition);

        
        

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log($"You clicked on {worldPosition}");
        }
    }
}
