using System;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : BaseAction
{
    private List<GridPosition> _validGridPositionList = new List<GridPosition>();
    [SerializeField] private int maxMoveDistance = 1;
    private Vector3 _targetPosition;
    private float _stoppingDistance = .1f;
    private float _moveSpeed = 5f;
    private float _rotateSpeed = 10f;

    protected override void Awake() //Override oldugu zaman super class calismaz.
    {
        base.Awake(); // override fonksiyonlarda "base." ile ust sinifin icindekilere ulasslir.
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if (!IsActive) return; //protection flag
        Vector3 moveDirection = (_targetPosition - transform.position).normalized;
        if (Vector3.Distance(transform.position, _targetPosition) > _stoppingDistance)
        {
            transform.position += moveDirection * _moveSpeed * Time.deltaTime;
            //Burada animator geldigi zaman yurume animasyonunu aktive ettir.
        }
        else
        {
            IsActive = false;
            OnActionComplete();
            //Yurume animasyonunu durdur.
        }

        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * _rotateSpeed);
    }

    public void Move(GridPosition gridPosition, Action onActionComplete)
    {
        OnActionComplete = onActionComplete;
        _targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
        IsActive = true;
    }

    public bool IsValidActionPosition(GridPosition gridPosition)
    {
        _validGridPositionList = GetValidActionGridPositionList();
        return _validGridPositionList.Contains(gridPosition); //disaridan gelen pozisyon bu listede var mi? 
        //contains fonksiyonu true veya false dondurur
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridposition = Unit.GetGridPosition();
        for (int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridposition + offsetGridPosition;
                if (!LevelGrid.Instance.IsGridPositionValid(testGridPosition))
                {
                    continue; // for loopunu bir sonraki loopa getirir.
                }

                if (unitGridposition == testGridPosition)
                {
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitOnSelectedGridPosition(testGridPosition))
                {
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;
    }

    public override string GetActionName()
    {
        return "Move";
    }
}