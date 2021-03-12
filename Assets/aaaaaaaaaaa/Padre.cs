using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padre : MonoBehaviour
{
    [SerializeField] protected int number;
    
    protected virtual void IncreaseNumber()
    {
        Debug.Log(number + gameObject.name);
        number++;
    }
}
