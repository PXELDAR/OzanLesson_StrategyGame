using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystemVisualSingle : MonoBehaviour
{
    [SerializeField] MeshRenderer m_Renderer;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Show()
    {
        m_Renderer.enabled = true;
    }

    public void Hide()
    {
        m_Renderer.enabled = false;
    }
}
