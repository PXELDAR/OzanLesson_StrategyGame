using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitTest : MonoBehaviour
{
    Vector3 targetPosition;
    private bool canMove;
    private float stoppingDistance = 0.1f;
    [SerializeField] private float moveSpeed = 4f;
    GridObject gridToGo;

    void Update()
    {
        if (canMove == true)

        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
            {
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }

            else
            {
                canMove = false;
            }

        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseButton = LevelGrid.instance.GetGridPosition(MouseWorld.GetPosition());
            gridToGo = LevelGrid.instance.levelGridSystem.GetGridObject(mouseButton);
            Move(gridToGo);
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


}
