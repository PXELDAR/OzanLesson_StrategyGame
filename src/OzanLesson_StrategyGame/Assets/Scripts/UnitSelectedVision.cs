using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectedVision : MonoBehaviour
{
    [SerializeField] Unit unit;
    MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }
    void Start()
    {
        UnitActionSystem.instance.onSelectedUnit += UpdateVisual;
        UpdateVisual(unit);
    }

    private void UpdateVisual(Unit unit)
    {
        if (unit == this.unit)
        {
            meshRenderer.enabled = true;
        }

        else
        {
            meshRenderer.enabled = false;
        }
    }

}
