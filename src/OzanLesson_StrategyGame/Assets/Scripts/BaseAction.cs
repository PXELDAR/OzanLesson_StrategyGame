using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class BaseAction : MonoBehaviour //Abtract s�n�flar sasdece bir �eyleri tan�mlamak i�in kullan�l�r.
{
    protected Unit unit;
    protected bool isActive;// protected keywordu sadece subclasslerden g�r�n�r.

    protected virtual void Awake() //Virtual fonksiyonlar�n i�i dolu olabilir
    {
        unit= GetComponent<Unit>();
    }

    abstract public string GetActionName(); //Abtract fonksyionlar�n i�in bo� olur.
    
}
