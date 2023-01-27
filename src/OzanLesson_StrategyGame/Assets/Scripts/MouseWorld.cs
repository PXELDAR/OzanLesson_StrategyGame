using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] LayerMask MouseLayerMask;
    static MouseWorld instance;

    private void Awake()
    {
        instance = this;
    }
    static public Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, instance.MouseLayerMask);
        // Debug.DrawRay(Camera.main.transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        return raycastHit.point;
        
    }
}
