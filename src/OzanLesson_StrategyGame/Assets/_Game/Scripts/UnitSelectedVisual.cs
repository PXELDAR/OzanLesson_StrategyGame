using UnityEngine;

public class UnitSelectedVisual : MonoBehaviour
{
    [SerializeField] private Unit unit;
    private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        UnitActionSystem.Instance.onSelectedUnit += UpdateVisual;
        UpdateVisual(UnitActionSystem.Instance.GetSelectedUnit());
    }

    private void UpdateVisual(Unit unit)
    {
        _meshRenderer.enabled = unit == this.unit;
    }
}