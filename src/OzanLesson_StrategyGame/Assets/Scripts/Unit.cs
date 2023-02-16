using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private GridPosition _gridposition;
    private MoveAction _moveAction;

    private void Awake()
    {
        _moveAction = GetComponent<MoveAction>();
    }

    private void Start()
    {
        _gridposition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.AddUnitAtGridPosition(_gridposition, this);
    }

    private void Update()
    {
        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        if (newGridPosition != _gridposition) //her frame hareket eden unit pozisyonunu kontrol ediyoruz
        {
            LevelGrid.Instance.UnitgMoveGridPosition(this, _gridposition, newGridPosition);
            _gridposition = newGridPosition;
        }
    }

    public MoveAction GetMoveAction()
    {
        return _moveAction;
    }

    public GridPosition GetGridPosition()
    {
        return _gridposition;
    }
}