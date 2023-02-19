using UnityEngine;

public class MouseWorld : MonoBehaviour
{
    [SerializeField] private LayerMask mouseLayerMask;
    public static MouseWorld Instance;

    private void Awake()
    {
        Instance = this;
    }

    public static Vector3 GetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var raycastHit, float.MaxValue, Instance.mouseLayerMask);
        return raycastHit.point;
    }
}