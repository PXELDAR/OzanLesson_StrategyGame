using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseAction : MonoBehaviour //Abtract sýnýflar sasdece bir þeyleri tanýmlamak için kullanýlýr.
{
    protected Unit unit;
    protected bool isActive;// protected keywordu sadece subclasslerden görünür.

    protected virtual void Awake() //Virtual fonksiyonlarýn içi dolu olabilir
    {
        unit= GetComponent<Unit>();
    }

    abstract public string GetActionName(); //Abtract fonksyionlarýn için boþ olur.
    
}
