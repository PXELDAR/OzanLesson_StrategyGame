using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField][Range(2, 20)] public int width;
    [SerializeField][Range(2, 20)] public int height;
    [SerializeField][Range(1f, 5f)] public float size;
    [SerializeField] private Transform gridPrefab;
    public GridSystem levelGridSystem { get; private set; }

    public static LevelGrid instance;


    private void Awake()
    {
        levelGridSystem = new GridSystem(width, height, size);
        levelGridSystem.CreateGridDebug(gridPrefab);

        instance = this;
    }

    public Vector3 GetGridPosition(Vector3 worldPosition)
    {
        return new Vector3(Mathf.RoundToInt(worldPosition.x / size), 0, Mathf.RoundToInt(worldPosition.z / size));

    }



}
