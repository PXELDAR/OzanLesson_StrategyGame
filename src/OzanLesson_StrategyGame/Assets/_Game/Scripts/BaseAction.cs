using System;
using UnityEngine;

[Serializable]
public abstract class BaseAction : MonoBehaviour //Abtract siniflar sasdece bir seyleri tanimlamak icin kullanilir.
{
    protected Unit Unit;
    protected bool IsActive; // protected keywordu sadece subclasslerden gorunur.
    protected Action OnActionComplete;

    protected virtual void Awake() //Virtual fonksiyonlarin ici dolu olabilir
    {
        Unit = GetComponent<Unit>();
    }

    public abstract string GetActionName(); //Abtract fonksyionlarin ici bos olur.
}