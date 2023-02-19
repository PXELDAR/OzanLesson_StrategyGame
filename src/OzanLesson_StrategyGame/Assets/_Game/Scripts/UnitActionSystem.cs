using UnityEngine;
using UnityEngine.Serialization;

public class UnitActionSystem : MonoBehaviour
{
    [SerializeField] private Unit selectedUnit;
    [SerializeField] private LayerMask unitLayerMask;
    private bool _isBusy;
    public static UnitActionSystem Instance { get; private set; }
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
        if (Instance != null)
        {
            Debug.LogError("Birden fazla unit action system olusturuldu!");
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Update()
    {
        if (_isBusy)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (TryHandleUnitSelection()) return;
            GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.GetPosition());
            if (selectedUnit)
            {
                if (selectedUnit.GetMoveAction().IsValidActionPosition(mouseGridPosition))
                {
                    SetBusy();
                    selectedUnit.GetMoveAction().Move(mouseGridPosition, ClearSetBusy);
                }
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

        return false; // eger raycast hicbirine carpmadiysa false
    }

    public void SetSelectedUnit(Unit unit)
    {
        selectedUnit = unit;
        SelectedUnitChange(selectedUnit);
    }

    public void SetBusy()
    {
        _isBusy = true;
    }

    public void ClearSetBusy()
    {
        _isBusy = false;
    }

    public Unit GetSelectedUnit()
    {
        return selectedUnit;
    }
}