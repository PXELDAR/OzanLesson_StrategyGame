using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    Vector3 targetPosition;
    private bool canMove;
    private float stoppingDistance = 0.1f;
    [SerializeField] private float moveSpeed = 4f;
    GridPosition gridposition;
    MoveAction moveAction;

    private void Awake()
    {
        moveAction= GetComponent<MoveAction>();
    }

    private void Start()
    {
        gridposition = LevelGrid.instance.GetGridPosition(transform.position);
        LevelGrid.instance.AddUnitAtGridPosition(gridposition,this);
    }

    void Update()
    {
        Vector3 newGridPosition = LevelGrid.instance.GetGridPosition(transform.position);

        if (newGridPosition != gridposition) //her frame hareket eden unit pozisyonunu kontrol ediyoruz
        {
            LevelGrid.instance.UnitgMoveGridPosition(this, gridposition, newGridPosition);
            gridposition= newGridPosition;
        }
    }

    public void Move(GridObject grid)
    {
        targetPosition = LevelGrid.instance.levelGridSystem.GetWorldPosition(grid);

        if (targetPosition == Vector3.zero)
        {
            targetPosition = new Vector3(5, 1, 8);
        }

        canMove = true;
    }

    public MoveAction GetMoveAction()
    {
        return moveAction;
    }

    public GridPosition GetGridPosition()
    {
        return gridposition;
    }


}
