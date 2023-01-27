using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitTest : MonoBehaviour
{

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mouseButton = LevelGrid.instance.GetGridPosition(MouseWorld.GetPosition());
            Debug.Log($"x: {mouseButton.x} ,z: {mouseButton.z} ");
            transform.position = mouseButton * 3;
            
        }
    }
}
