using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveAction : BaseAction
{
    List<GridPosition> validGridPositionList = new List<GridPosition>();
    [SerializeField] int maxMoveDistance = 1;
    private Vector3 targetPosition;
    float stoppingDistance = .1f;
    float moveSpeed = 5f;
    float rotateSpeed =10f;
    

    protected override void Awake() //Override olduðu zaman super class çalýþmaz.
    {
        base.Awake(); // override fonksiyonlarda "base." ile üst sýnýfýn içindekilere ulaþýlýr.
        targetPosition= transform.position;
    }


    void Update()
    {
        if (!isActive) return; //protection flag

        Vector3 moveDirection = (targetPosition - transform.position).normalized;
        

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            //Burada animator geldiði zaman yürüme animasyonunu aktive ettir.
        }

        else
        {
            isActive = false;
            onActionComplete();
            //Yürüme animasyonunu durdur.
        }

        transform.forward = Vector3.Lerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);


   
    }

    public void Move(GridPosition gridPosition, Action onActionComplete)
    {
        this.onActionComplete= onActionComplete;
        targetPosition = LevelGrid.instance.GetWorldPosition(gridPosition);
        isActive= true;
    }

    public bool IsValidActionPoisiton(GridPosition gridposition)
    {
         validGridPositionList= GetValidActionGridPositionList();
        return validGridPositionList.Contains(gridposition); //dýþarýdan gelen pozisyon bu listede var mý? 
        //contains fonksiyonu true veya false döndürür

    }

    

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();
        GridPosition unitGridposition = unit.GetGridPosition();

        for(int x = -maxMoveDistance; x <= maxMoveDistance; x++)
        {
            for (int z = -maxMoveDistance; z <= maxMoveDistance; z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x, z);
                GridPosition testGridPosition = unitGridposition + offsetGridPosition;

                if (!LevelGrid.instance.IsGridPositionValid(testGridPosition))
                {
                    continue; // for loopunu bir sonraki loopa geçirir.
                }

                if ( unitGridposition == testGridPosition)
                {
                    continue;
                }

                if (LevelGrid.instance.HasAnyUnitOnSelectedGridPosition(testGridPosition))
                {
                    continue;
                }

                validGridPositionList.Add(testGridPosition);
            }
        }

        return validGridPositionList;

    }
    override public string GetActionName()
    {
        return "Move";
    }




}
