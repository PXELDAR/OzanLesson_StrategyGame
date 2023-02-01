using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitActionSystem : MonoBehaviour
{
    Unit selectedUnit;
    [SerializeField] LayerMask unitLayerMask;

    bool isBusy;

    public static UnitActionSystem instance { get; private set; }
    
    public delegate void OnSelectedUnitChange(Unit unit);
    public event OnSelectedUnitChange onSelectedUnit;

    public void SelectedUnitChange(Unit unit)
    {
        /* if(onSelectedUnit != null) //
        {

            onSelectedUnit.Invoke(unit);
        } */

        onSelectedUnit?.Invoke(unit);
    }
    private void Awake()
    {
       
        
        if (instance != null)
        {
            Debug.LogError("Birden fazla unit action system oluþturuldu!");
            Destroy(gameObject);
            return;
            
        }

        instance = this;
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        if (isBusy)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (TryHandleUnitSelection())
            {

            }
        }

        
    }

   public bool TryHandleUnitSelection()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, unitLayerMask))
        {
            if (raycastHit.transform.TryGetComponent<Unit>(out Unit unit)) 
            
            {
                SetSelectedUnit(unit); 
                return true;
            }
            //Unit selectedUnit = raycastHit.transform.GetComponent<Unit>();

            //if (selectedUnit)
            //{
            //    SetSelectedUnit(selectedUnit);

            //}
        }
        return false; // eðer raycast hiçbirine çarpmadýysa false
    }

    public void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        SelectedUnitChange(selectedUnit);
    }
}
