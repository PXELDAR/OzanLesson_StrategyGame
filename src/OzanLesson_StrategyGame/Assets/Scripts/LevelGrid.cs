using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [SerializeField][Range(2,20)] int width;
    [SerializeField][Range(2, 20)] int height;
    [SerializeField][Range(1f, 5f)] float size;
    [SerializeField] Transform gridPrefab;
    GridSystem levelGridSystem;

    private void Awake()
    {
        levelGridSystem= new GridSystem(width, height, size);
        levelGridSystem.CreateGridDebug(gridPrefab);
    }

  
}
